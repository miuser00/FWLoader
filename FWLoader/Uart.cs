using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using LibUsbDotNet.DeviceNotify;
using System.Reflection;

//这个文件的代码抄了晨旭大神的LLCOM，连注释好多地方都没改...
namespace FWLoader
{
    public class Uart
    {
        public SerialPort serial = new SerialPort();
        public event EventHandler UartDataRecived;
        public event EventHandler UartDataSent;
        public string PortName{get; set;}
        public int BaudRate { get; set; } = 115200;
        public Parity Parity { get; set; } = Parity.None;
        public int DataBits { get; set; } = 8;
        public StopBits StopBits { get; set; } = StopBits.One;

        public int Timeout { get; set; } = 30;

        //串口发送接收计数
        public long SentCount{get;set;}
        public long ReceivedCount { get; set; }

        public long SentPackageCount { get; set; }
        public long ReceivedPackageCount { get; set; }

        public bool Rts
        {
            get
            {
                return serial.RtsEnable;
            }
            set
            {
                serial.RtsEnable = value;
            }
        }
        public bool Dtr
        {
            get
            {
                return serial.DtrEnable;
            }
            set
            {
                serial.DtrEnable = value;
            }
        }
        private static readonly object objLock = new object();
        /// <summary>
        /// 初始化串口各个触发函数
        /// </summary>
        public Uart()
        {

        }
        /// <summary>
        /// 查看串口打开状态
        /// </summary>
        /// <returns></returns>
        public bool IsOpen()
        {
            return serial.IsOpen;
        }

        /// <summary>
        /// 开启串口
        /// </summary>
        public void Open()
        {
            if (serial.IsOpen == true) serial.Close();
            ClearAllEvents(this, "UartDataRecived");
            serial = new SerialPort();
            //声明接收到事件
            serial.DataReceived += Serial_DataReceived;
            serial.BaudRate = BaudRate;
            serial.Parity = Parity;
            serial.DataBits = DataBits;
            serial.StopBits = StopBits;
            serial.RtsEnable = Rts;
            serial.DtrEnable = Dtr;
            serial.PortName = PortName;
            serial.Open();
        }
        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            serial.Close();
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="data">数据内容</param>
        public void SendData(byte[] data)
        {
            if (data.Length == 0)
                return;
            serial.Write(data, 0, data.Length);
            SentCount += data.Length;
            SentPackageCount++;
            UartDataSent(data, EventArgs.Empty);//回调
        }
        /// <summary>
        /// 接收到数据事件
        /// </summary>
        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            lock (objLock)
            {
                if(Timeout > 0)
                    System.Threading.Thread.Sleep(Timeout);//等待时间
                List<byte> result = new List<byte>();
                while (true)//循环读
                {
                    if (!serial.IsOpen)//串口被关了，不读了
                        break;
                    try
                    {
                        int length = ((SerialPort)sender).BytesToRead;
                        if (length == 0)//没数据，退出去
                            break;
                        byte[] rev = new byte[length];
                        ((SerialPort)sender).Read(rev, 0, length);//读数据
                        if (rev.Length == 0)
                            break;
                        result.AddRange(rev);//加到list末尾
                    }catch { break; }//崩了？

                    if ( Timeout > 0)//如果是设置了等待间隔时间
                    {
                        System.Threading.Thread.Sleep(Timeout);//等待时间
                    }
                }
                ReceivedCount += result.Count;
                ReceivedPackageCount++;
                if (result.Count > 0)
                    UartDataRecived(result.ToArray(), EventArgs.Empty);//回调事件
                    System.Diagnostics.Debug.WriteLine("uart data received");
            }
        }
        #region 清除事件绑定的函数
        /// <summary>
        /// 清除事件绑定的函数
        /// </summary>
        /// <param name="objectHasEvents">拥有事件的实例</param>
        /// <param name="eventName">事件名称</param>
        public static void ClearAllEvents(object objectHasEvents, string eventName)
        {
            if (objectHasEvents == null)
            {
                return;
            }
            try
            {
                EventInfo[] events = objectHasEvents.GetType().GetEvents(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (events == null || events.Length < 1)
                {
                    return;
                }
                for (int i = 0; i < events.Length; i++)
                {
                    EventInfo ei = events[i];
                    if (ei.Name == eventName)
                    {
                        FieldInfo fi = ei.DeclaringType.GetField(eventName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                        if (fi != null)
                        {
                            fi.SetValue(objectHasEvents, null);
                        }
                        break;
                    }
                }
            }
            catch
            {
            }
        }
        #endregion
    }
}
