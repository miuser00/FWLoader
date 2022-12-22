using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibUsbDotNet.DeviceNotify;
using System.Management;
using System.Text.RegularExpressions;
using System.IO;
using System.IO.Ports;
using Nett;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;
using System.Threading;

//Esp32C3固件下载器 -我抄袭的不仅仅是梦程和晨旭的代码

namespace FWLoader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        Uart uart = new Uart();
        Firmware fw = new Firmware();
        App app = new App();
        //检测到Esp设备接入的旗标
        bool DetectedESP=false;
        //当前执行状态的旗标

        //usb刷新时触发
        private static IDeviceNotifier usbDeviceNotifier = DeviceNotifier.OpenDeviceNotifier();

        /// <summary>
        /// 保存脚本是内部还是外部的选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chb_usePackageScript_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_usePackageScript.Checked == true) chb_useLocalScript.Checked = false; else chb_useLocalScript.Checked = true;
            app.ScriptLocation = chb_useLocalScript.Checked ? "local" : "package";
            WriteToml();
        }
        /// <summary>
        /// 保存脚本是内部还是外部的选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chb_useLocalScript_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_useLocalScript.Checked == true) chb_usePackageScript.Checked = false; else chb_usePackageScript.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            usbDeviceNotifier.Enabled = true;
            //USB设备插入的回调函数
            usbDeviceNotifier.OnDeviceNotify += UsbDeviceNotifier_OnDeviceNotify;
            //刷新设备列表
            refreshPortList();
            //加载配置
            ReadToml();
            

            //自动选择COM口
            if (app.AutoFindESPCOM==true)
            {
                bgw_AutoselectCOM.RunWorkerAsync();
            }


        }


        /// <summary>
        /// USB插入更新的回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsbDeviceNotifier_OnDeviceNotify(object sender, DeviceNotifyEventArgs e)
        {
             refreshPortList();
        }
        private bool refreshLock = false;
        ///<summary>
        ///读取配置文件
        /// </summary>
        private void ReadToml()
        {
            try
            {
                var toml = Toml.ReadFile(Application.StartupPath + "\\" + "config.toml");
                uart.BaudRate = toml.Get<TomlTable>("uart").Get<int>("Baud");
                if (toml.Get<TomlTable>("uart").Get<string>("Parity") == "odd") uart.Parity = Parity.Odd;
                if (toml.Get<TomlTable>("uart").Get<string>("Parity") == "even") uart.Parity = Parity.Even;
                if (toml.Get<TomlTable>("uart").Get<string>("Parity") == "none") uart.Parity = Parity.None;
                uart.DataBits = toml.Get<TomlTable>("uart").Get<int>("DataBits");
                if (toml.Get<TomlTable>("uart").Get<int>("StopBits") == 1) uart.StopBits = StopBits.One;
                if (toml.Get<TomlTable>("uart").Get<int>("StopBits") == 15) uart.StopBits = StopBits.OnePointFive;
                if (toml.Get<TomlTable>("uart").Get<int>("StopBits") == 2) uart.StopBits = StopBits.Two;

                fw.Name = toml.Get<TomlTable>("firmware").Get<string>("Firmware");
                fw.Script = toml.Get<TomlTable>("firmware").Get<string>("Script");
                fw.FsOffset = toml.Get<TomlTable>("firmware").Get<string>("FsOffset");
                fw.FsSize = toml.Get<TomlTable>("firmware").Get<string>("FsSize");
                fw.LuadbOffset = toml.Get<TomlTable>("firmware").Get<string>("LuadbOffset");

                app.AutoFindESPCOM = toml.Get<TomlTable>("app").Get<bool>("AutoFindESPCOM");
                app.AutoDownloadFirmware= toml.Get<TomlTable>("app").Get<bool>("AutoDownloadFirmware");
                app.AutoDownloadScript= toml.Get<TomlTable>("app").Get<bool>("AutoDownloadScript");
                app.FirmwareFile = toml.Get<TomlTable>("app").Get<string>("FirmwareFile");
                app.ScriptPath = toml.Get<TomlTable>("app").Get<string>("ScriptPath");
                app.ScriptLocation = toml.Get<TomlTable>("app").Get<string>("ScriptLocation");

                log("Configuration is downloaded");
                log("Datarate:" + uart.BaudRate+",Parity:"+uart.Parity.ToString()+",Databits:"+uart.DataBits.ToString()+",Stopbits:"+uart.StopBits.ToString());
                log("FsOffset=" + fw.FsOffset + ",FsSize=" + fw.FsSize + ",LuadbOffset="+fw.LuadbOffset);
                if (app.FirmwareFile!="") log("Firmware path:" + app.FirmwareFile);
                if (app.ScriptPath != "") log("Local script path:" + app.ScriptPath);
                log("Script location:" + app.ScriptLocation);
                log("Autofind ESP chip COM port:" + app.AutoFindESPCOM);
                log("Auto download mode (core,script):" +app.AutoDownloadFirmware+","+app.AutoDownloadScript );

                //更新界面控件的初始信息
                if (app.ScriptLocation == "package") chb_usePackageScript.Checked = true;
                if (app.ScriptLocation == "local") chb_useLocalScript.Checked = true;
                txt_firmwareFile.Text = app.FirmwareFile;
                txt_scriptPath.Text = app.ScriptPath;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.StackTrace);
                log("读取配置文件错误，请下载完整程序");
            }
        }
        ///<summary>
        ///写入Toml配置文件
        /// </summary>
        private void WriteToml()
        {
            try
            {
                TomlTable toml = Toml.ReadFile(Application.StartupPath + "\\" + "config.toml");
                var apptoml =(TomlTable) toml["app"];
                apptoml.Update("FirmwareFile", app.FirmwareFile);
                apptoml.Update("ScriptPath", app.ScriptPath);
                apptoml.Update("ScriptLocation", app.ScriptLocation);
                toml["app"] = apptoml;
                Toml.WriteFile(toml,Application.StartupPath + "\\" + "config.toml");

            }
            catch
            {
                log("配置写入错误");
            }
        }


        ///<summary>
        ///检查是否为ESP32芯片
        /// </summary>
        private void CheckEsp32(string COMName)
        {
            Regex reg = new Regex("((COM[0-9]*))");
            string currCOM = reg.Match(COMName).Value;
            if (currCOM!="")
            {
                try
                {
                    statusStrip1.BackColor = SystemColors.Control;
                    pic_connected.Image = Properties.Resources.grayball;
                    DetectedESP = false;
                    uart.PortName=currCOM;
                    uart.Open();
                    Console.WriteLine("Checking COM " + currCOM);
                    uart.UartDataRecived += new EventHandler((obj, args) =>
                    {
                        byte[] bytes = (byte[])(obj);
                        string rsv = Encoding.ASCII.GetString(bytes);
                        uart.Close();
                        this.BeginInvoke(new Action(() =>
                        {
                            //检查串口返回的数据是否有Esp32固件的关键字
                            if (rsv.Contains("ESP-ROM") || rsv.Contains("LuatOS@ESP32"))
                            {
                                log_uart("--New esp32 device inserted--");
                                pic_connected.Image = Properties.Resources.greenball;
                                DetectedESP = true;
                                log_uart(rsv);
                            }
                            else
                            {
                                log_uart("Unknow uart device inserted--");
                                pic_connected.Image = Properties.Resources.redball;
                                DetectedESP = false;
                            }
                            //如果配置文件中有自动下载设置，则启动自动下载
                            if (app.AutoDownloadFirmware ||app.AutoDownloadScript) AutoStartDownload();

                        }));

                    });
                    uart.Rts = true;
                    System.Threading.Thread.Sleep(30);
                    uart.Dtr = true;
                    System.Threading.Thread.Sleep(30);
                    uart.Dtr = false;
                    System.Threading.Thread.Sleep(30);
                    uart.Rts = false;
                }
                catch (Exception ee)
                {
                    //log("无法打开"+ currCOM+","+"请检查是否被其他串口控制软件占用");
                    Console.Write(ee.StackTrace); 
                }
            }else
            {
                pic_connected.Image = Properties.Resources.grayball;
            }



        }
        /// <summary>
        /// 启动自动下载
        /// </summary>
        public void AutoStartDownload()
        {
            if (DetectedESP == true)
            {
                if (app.AutoDownloadFirmware)
                {
                    app.BurnType = App.BURNTYPE.Full;
                    if (!bgw_Exe.IsBusy)
                        bgw_Exe.RunWorkerAsync();
                }else if (app.AutoDownloadScript)
                {
                    app.BurnType = App.BURNTYPE.ScriptOnly;
                    if (!bgw_Exe.IsBusy)
                        bgw_Exe.RunWorkerAsync();
                }
            }

        }

        /// <summary>
        /// 刷新设备列表，完整的抄袭了LLCOM的代码
        /// </summary>
        private void refreshPortList()
        {
            if (refreshLock)
                return;
            refreshLock = true;
            cmb_serial.Items.Clear();
            List<string> strs = new List<string>();
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");
                        Regex regExp = new Regex("\\(COM\\d+\\)");
                        foreach (ManagementObject queryObj in searcher.Get())
                        {
                            if ((queryObj["Caption"] != null) && regExp.IsMatch(queryObj["Caption"].ToString()))
                            {
                                strs.Add(queryObj["Caption"].ToString());
                            }
                        }
                        break;
                    }
                    catch
                    {
                        Task.Delay(500).Wait();
                    }
                }

                try
                {
                    foreach (string p in SerialPort.GetPortNames())//根据得到的strs补全COM口名称
                    {
                        bool notMatch = true;
                        foreach (string n in strs)
                        {
                            if (n.Contains($"({p})"))//如果和选中项目匹配
                            {
                                notMatch = false;
                                break;
                            }
                        }
                        if (notMatch)
                            strs.Add($"Serial Port {p} ({p})");//如果列表中没有，就自己加上
                    }
                }
                catch { }

                this.BeginInvoke(new Action(() => { 
                    foreach (string i in strs) cmb_serial.Items.Add(i);
                    //如果combobox显示当前串口为空，则指定当前串口为发现的第一个串口
                    if (cmb_serial.Text == "" && cmb_serial.Items.Count > 0) cmb_serial.Text = cmb_serial.Items[0].ToString();
                    CheckEsp32(cmb_serial.Text);
                }));

                refreshLock = false;
 
            });
        }
        /// <summary>
        /// 下载完整的固件和脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_downloadFull_Click(object sender, EventArgs e)
        {
            app.BurnType = App.BURNTYPE.Full;
            if (!bgw_Exe.IsBusy)
            bgw_Exe.RunWorkerAsync();
        }
        /// <summary>
        /// 配置窗口输出log
        /// </summary>
        /// <param name="str"></param>
        private void log(string str)
        {

            string time = DateTime.Now.ToString("HH:mm:ss.fff");
            this.BeginInvoke(new Action(() => {
                rtb_mainlog.AppendText("["+time+"] " +str +"\n");
                rtb_mainlog.SelectionStart = rtb_mainlog.TextLength;
                rtb_mainlog.ScrollCaret();
            }));

        }
        /// <summary>
        /// 串口窗口输出log
        /// </summary>
        /// <param name="str"></param>
        private void log_uart(string str)
        {
            string time = DateTime.Now.ToString("HH:mm:ss.fff");
            this.BeginInvoke(new Action(() => {
                rtb_uartlog.AppendText("[" + time + "] " + str + "\n");
                rtb_uartlog.SelectionStart = rtb_uartlog.TextLength;
                rtb_uartlog.ScrollCaret();
                toolStripStatusLabel1.Width = statusStrip1.Width - 20;
                toolStripStatusLabel1.Text ="[esp32dl] " + str;
            }));


        }
        private void chb_usePackageScript_Click(object sender, EventArgs e)
        {
            log("Script location:" + app.ScriptLocation);
        }

        private void chb_useLocalScript_Click(object sender, EventArgs e)
        {
            log("Script location:" + app.ScriptLocation);
        }
        /// <summary>
        /// 选择固件名称
        /// 可以是合宙的soc格式，也可以是乐鑫的bin格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_selectFW_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Firmware Files (*.soc;*.bin)|*.soc;*.bin";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txt_firmwareFile.Text = ofd.FileName;
                app.FirmwareFile = txt_firmwareFile.Text;
                if (app.FirmwareFile != "") log("Firmware path:" + app.FirmwareFile);
                WriteToml();
            }
            else
            { }
        }
        /// <summary>
        /// 保存固件名称因手工编辑造成的更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_firmwareFile_Leave(object sender, EventArgs e)
        {
           // if (app.FirmwareFile != "") log("Firmware path:" + app.FirmwareFile);
            app.FirmwareFile = txt_firmwareFile.Text;
            WriteToml();
        }
        /// <summary>
        /// 选择脚本目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_selectScript_Click(object sender, EventArgs e)
        {
            var odd = new CommonOpenFileDialog();
            odd.IsFolderPicker = true; //设置为true为选择文件夹，设置为false为选择文件
            odd.Title = "选择文件夹";
            var result = odd.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                txt_scriptPath.Text = odd.FileName;
                app.ScriptPath = txt_scriptPath.Text;
                if (app.ScriptPath != "") log("Script path:" + app.ScriptPath);
                WriteToml();
            }
        }
        /// <summary>
        /// 保存脚本路径因为手动编辑的变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_scriptPath_TextChanged(object sender, EventArgs e)
        {
            //if (app.ScriptPath != "") log("Script path:" + app.ScriptPath);
            app.ScriptPath = txt_scriptPath.Text;
            WriteToml();
        }
        /// <summary>
        /// 串口发生变化，检查接入设备是否是esp32
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_serial_SelectedIndexChanged(object sender, EventArgs e)
        {

            


        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtb_uartlog.Text = "";
        }
        /// <summary>
        /// 自动循环检测当前串口是否为esp32，如果不是则遍历并选中第一个esp32串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_AutoselectCOM_DoWork(object sender, DoWorkEventArgs e)
        {
            Task.Run(async delegate
            {
                for (; ; )
                {
                    try
                    {
                        for (int i = 0; i < cmb_serial.Items.Count; i++)
                        {
                            if (DetectedESP == false)
                            {
                                CheckEsp32(cmb_serial.Items[i].ToString());
                                await Task.Delay(100);
                                if (DetectedESP == true)
                                {
                                    this.BeginInvoke(new Action(() =>
                                    {
                                        cmb_serial.Text = cmb_serial.Items[i].ToString();
                                    }));
                                    break;
                                }
                            }
                        }
                    }
                    catch { }
                    await Task.Delay(200);
                }

            });
        }

        /// <summary>
        /// 执行外部程序
        /// </summary>
        /// <param name="file"></param>
        /// <param name="para"></param>
        private void exeFile(string file,string para)
        {
            ProcessStartInfo start = new ProcessStartInfo(file,para);
            start.CreateNoWindow = true;                //不显示dos命令行窗口
            start.RedirectStandardOutput = true;
            start.RedirectStandardInput = true;
            start.RedirectStandardError = true;
            start.UseShellExecute = false;              //是否指定操作系统外壳进程启动程序，这里需为false
            Process p = Process.Start(start);
            //StreamWriter writer = p.StandardInput;
            //writer.WriteLine("ping www.baidu.com");
            //writer.WriteLine("exit");
            //writer.Close();
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            p.ErrorDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            p.BeginOutputReadLine();
            p.WaitForExit();                            //等待程序执行完退出进程
            p.Close();                                  //关闭进程
        }
        /// <summary>
        /// 过滤检测串口输出，并根据输出设置状态栏颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                this.BeginInvoke(new Action(() =>
                {
                    log_uart(e.Data);
                    if (e.Data.Contains("Hash of data verified"))
                    {
                        app.ExeStatus = App.EXESTATUS.Pass;
                    }
                    if (e.Data.Contains("Factory FW was generated"))
                    {
                        app.ExeStatus = App.EXESTATUS.Pass;
                    }
                    
                }));
            }
        }
        /// <summary>
        /// 程序的主线程，负责烧写固件，脚本或者生成量产固件
        /// 方式是通过参数调用外部可执行文件esp32dl.exe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_Exe_DoWork(object sender, DoWorkEventArgs e)
        {
            app.ExeStatus = App.EXESTATUS.Notstarted;
            Regex reg = new Regex("((COM[0-9]*))");
            string currCOM="";
            this.Invoke(new Action(() =>
            {
                statusStrip1.BackColor = Color.Yellow;
                currCOM = reg.Match(cmb_serial.Text).Value;
                if (currCOM=="")
                {
                    log("串口不存在");
                    return;
                }
            }));
            //设置芯片型号为esp32-c3
            string para = "-t esp32c3" + " ";
            //设置下载文件格式为SOC
            if (app.FirmwareFile.ToLower().EndsWith("soc")) para = para + "-p" + " ";

            //设置烧写类型
            switch(app.BurnType)
            {
                case App.BURNTYPE.Full:
                    //同时脚本与固件
                    para = para + "-rf" + " ";
                    break;
                case App.BURNTYPE.ScriptOnly:
                    para = para + "-f" + " ";
                    break;
                case App.BURNTYPE.GenerateOnly:
                    para = para + "-f" + " " + "-m" + " ";
                    break;
            }
            //设置串口为选中端口
            para = para + "-c " +currCOM + " ";
            //设置波特率为 921600
            para = para + "-b 921600" + " ";
            try
            {
                //设置固件文件名
                {
                    if (app.FirmwareFile.ToLower().EndsWith("soc"))
                    {
                        System.IO.File.Copy(app.FirmwareFile, Application.StartupPath + "\\fw.soc", true);
                        para = para + "-l " + "fw.soc" + " ";
                    }else
                    {
                        System.IO.File.Copy(app.FirmwareFile, Application.StartupPath + "\\fw.bin", true);
                        para = para + "-l " + "fw.bin" + " ";
                    }

                }

            } 
            catch (Exception ee)
            {
                Console.WriteLine(ee.StackTrace);
                log_uart("固件文件错误");
                return;
            }
            try
            {

                //设置本地脚本路径
                if (app.ScriptLocation.ToLower() == "local")
                {
                    CopyFileAndDir(app.ScriptPath, Application.StartupPath + "\\tempscript");
                    para = para + "-s " + "tempscript" + " ";

                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.StackTrace);
                log_uart("固件脚本错误");
                return;
            }
            //设置下载地址
            para = para + "--FsOffset 0x390000 --FsSize 0x70000 --LuadbOffset 0x310000" + " ";
            this.Invoke(new Action(() =>
            {
                //根据串口名设置端口类型（usb 或者 uart）
                if (cmb_serial.Text.Contains("串行设备"))
                {
                    para = para + "--usb" + " ";
                }else
                {
                    para = para + "--uart" + " ";
                }
            }));
            //执行
            exeFile("esp32dl",para);
            if (app.ExeStatus == App.EXESTATUS.Pass)
            {
                statusStrip1.BackColor = Color.Green;
                log_uart("Passed");
            }else
            {
                statusStrip1.BackColor = Color.Red;
                app.ExeStatus = App.EXESTATUS.Failed;
                log_uart("Failed");
            }
            try
            {
                //删除脚本临时目录
                DirectoryInfo di = new DirectoryInfo(Application.StartupPath + "\\tempscript");
                di.Delete(true);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.StackTrace);
            }
            try
            {   
                //删除临时固件文件
                System.IO.File.Delete(Application.StartupPath + "\\fw.tmp");
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.StackTrace);
            }
            try
            {
                if (app.BurnType==App.BURNTYPE.GenerateOnly)
                {
                    //更名生成的固件
                    string scriptName = System.IO.Path.GetFileName(app.ScriptPath);
                    string coreName = System.IO.Path.GetFileName(app.FirmwareFile);
                    string timestamp = DateTime.Now.ToLongTimeString();
                    string generatedFileName = Application.StartupPath + "\\" + timestamp.Replace(":", "-") + "_generated_" + scriptName + "_on_" + coreName;
                    System.IO.File.Move(Application.StartupPath + "\\tempscript_on_fw.soc", generatedFileName);
                    log_uart("Saved as " + generatedFileName);
                }
            }
            catch(Exception ee) 
            {
                Console.WriteLine(ee.StackTrace);
            }

        }
        /// <summary>
        /// 复制目录
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="desDir"></param>
        public static void CopyFileAndDir(string dir, string desDir)
        {
            if (!System.IO.Directory.Exists(desDir))
            {
                System.IO.Directory.CreateDirectory(desDir);
            }
            IEnumerable<string> files = System.IO.Directory.EnumerateFileSystemEntries(dir);
            if (files != null && files.Count() > 0)
            {
                foreach (var item in files)
                {
                    string desPath = System.IO.Path.Combine(desDir, System.IO.Path.GetFileName(item));

                    //如果是文件
                    var fileExist = System.IO.File.Exists(item);
                    if (fileExist)
                    {
                        //复制文件到指定目录下                     
                        System.IO.File.Copy(item, desPath, true);
                        continue;
                    }

                    //如果是文件夹                   
                    CopyFileAndDir(item, desPath);

                }
            }
        }
        /// <summary>
        /// 点击下载脚本按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_downloadScript_Click(object sender, EventArgs e)
        {
            app.BurnType = App.BURNTYPE.ScriptOnly;
            if (!bgw_Exe.IsBusy)
                bgw_Exe.RunWorkerAsync();
        }
        /// <summary>
        /// 点击生成量产固件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_generateFactorySW_Click(object sender, EventArgs e)
        {
            app.BurnType = App.BURNTYPE.GenerateOnly;
            if (!bgw_Exe.IsBusy)
                bgw_Exe.RunWorkerAsync();
        }

        private void pic_connected_DoubleClick(object sender, EventArgs e)
        {
            app.AutoDownloadFirmware = !app.AutoDownloadFirmware;
            app.AutoDownloadScript = app.AutoDownloadFirmware;
            log("Auto download mode (core,script):" + app.AutoDownloadFirmware + "," + app.AutoDownloadScript);
        }

        private void pic_connected_Click(object sender, EventArgs e)
        {

        }
    }
    /// <summary>
    /// 固件配置，主要是描述固件信息
    /// </summary>
    public class Firmware
    {
        public string Name { set; get; }
        public string Script { set; get; }
        public string FsOffset { set; get; }

        public string FsSize { set; get; }

        public string LuadbOffset { set; get; }

    }
    /// <summary>
    /// 应用的配置，主要是描述烧录过程的配置
    /// </summary>
    public class App
    {
        //自动下载脚本
        public bool AutoDownloadScript { set; get; }
        //自动下载固件
        public bool AutoDownloadFirmware{set; get;}
        //固件文件名
        public string FirmwareFile { set; get; }
        //外部脚本路径
        public string ScriptPath { set; get; }
        //脚本位置（本地或者外部）
        public string ScriptLocation { set; get; }
        //自动检测串口
        public bool AutoFindESPCOM { set; get; }

        //烧写方式 完整烧写，仅烧写脚本，仅合成脚本
        public enum BURNTYPE{Full=1,ScriptOnly=2,GenerateOnly=3 };
        public BURNTYPE BurnType { set; get; }

        //当前执行状态
        public enum EXESTATUS { Notstarted=0,Pass=1,Failed=-1 };
        public EXESTATUS ExeStatus { set; get; }

    }

}
