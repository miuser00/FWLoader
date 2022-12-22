
namespace FWLoader
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_downloadFull = new System.Windows.Forms.Button();
            this.btn_downloadScript = new System.Windows.Forms.Button();
            this.txt_firmwareFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_generateFactorySW = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chb_usePackageScript = new System.Windows.Forms.CheckBox();
            this.chb_useLocalScript = new System.Windows.Forms.CheckBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txt_scriptPath = new System.Windows.Forms.TextBox();
            this.panel21 = new System.Windows.Forms.Panel();
            this.btn_selectScript = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_selectFW = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.cmb_serial = new System.Windows.Forms.ComboBox();
            this.panel22 = new System.Windows.Forms.Panel();
            this.pic_connected = new System.Windows.Forms.PictureBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.main_log = new System.Windows.Forms.TabPage();
            this.rtb_mainlog = new ScintillaNET.Scintilla();
            this.uart_log = new System.Windows.Forms.TabPage();
            this.rtb_uartlog = new ScintillaNET.Scintilla();
            this.menu_uartlog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgw_AutoselectCOM = new System.ComponentModel.BackgroundWorker();
            this.bgw_Exe = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel13.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_connected)).BeginInit();
            this.panel17.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.main_log.SuspendLayout();
            this.uart_log.SuspendLayout();
            this.menu_uartlog.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_downloadFull
            // 
            this.btn_downloadFull.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_downloadFull.Location = new System.Drawing.Point(35, 217);
            this.btn_downloadFull.Name = "btn_downloadFull";
            this.btn_downloadFull.Size = new System.Drawing.Size(170, 36);
            this.btn_downloadFull.TabIndex = 1;
            this.btn_downloadFull.Text = "下载底包与脚本(&R)";
            this.btn_downloadFull.UseVisualStyleBackColor = true;
            this.btn_downloadFull.Click += new System.EventHandler(this.btn_downloadFull_Click);
            // 
            // btn_downloadScript
            // 
            this.btn_downloadScript.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_downloadScript.Location = new System.Drawing.Point(224, 217);
            this.btn_downloadScript.Name = "btn_downloadScript";
            this.btn_downloadScript.Size = new System.Drawing.Size(144, 36);
            this.btn_downloadScript.TabIndex = 2;
            this.btn_downloadScript.Text = "仅下载脚本(&P)";
            this.btn_downloadScript.UseVisualStyleBackColor = true;
            this.btn_downloadScript.Click += new System.EventHandler(this.btn_downloadScript_Click);
            // 
            // txt_firmwareFile
            // 
            this.txt_firmwareFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_firmwareFile.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txt_firmwareFile.Location = new System.Drawing.Point(101, 0);
            this.txt_firmwareFile.Name = "txt_firmwareFile";
            this.txt_firmwareFile.Size = new System.Drawing.Size(341, 29);
            this.txt_firmwareFile.TabIndex = 3;
            this.txt_firmwareFile.TabStop = false;
            this.txt_firmwareFile.Leave += new System.EventHandler(this.txt_firmwareFile_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(16, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "固件文件：";
            // 
            // btn_generateFactorySW
            // 
            this.btn_generateFactorySW.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_generateFactorySW.Location = new System.Drawing.Point(387, 217);
            this.btn_generateFactorySW.Name = "btn_generateFactorySW";
            this.btn_generateFactorySW.Size = new System.Drawing.Size(144, 36);
            this.btn_generateFactorySW.TabIndex = 8;
            this.btn_generateFactorySW.Text = "生成量产固件";
            this.btn_generateFactorySW.UseVisualStyleBackColor = true;
            this.btn_generateFactorySW.Click += new System.EventHandler(this.btn_generateFactorySW_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 537);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(571, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel13);
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.btn_downloadFull);
            this.panel1.Controls.Add(this.btn_downloadScript);
            this.panel1.Controls.Add(this.btn_generateFactorySW);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 274);
            this.panel1.TabIndex = 13;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.groupBox2);
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.panel15);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 109);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(571, 80);
            this.panel13.TabIndex = 19;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chb_usePackageScript);
            this.groupBox2.Controls.Add(this.chb_useLocalScript);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F);
            this.groupBox2.Location = new System.Drawing.Point(18, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(523, 80);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "脚本源：";
            // 
            // chb_usePackageScript
            // 
            this.chb_usePackageScript.AutoSize = true;
            this.chb_usePackageScript.Font = new System.Drawing.Font("宋体", 12F);
            this.chb_usePackageScript.Location = new System.Drawing.Point(34, 51);
            this.chb_usePackageScript.Name = "chb_usePackageScript";
            this.chb_usePackageScript.Size = new System.Drawing.Size(323, 20);
            this.chb_usePackageScript.TabIndex = 7;
            this.chb_usePackageScript.Text = "优先SOC中的Lua脚本(仅适用于量产固件）";
            this.chb_usePackageScript.UseVisualStyleBackColor = true;
            this.chb_usePackageScript.CheckedChanged += new System.EventHandler(this.chb_usePackageScript_CheckedChanged);
            this.chb_usePackageScript.Click += new System.EventHandler(this.chb_usePackageScript_Click);
            // 
            // chb_useLocalScript
            // 
            this.chb_useLocalScript.AutoSize = true;
            this.chb_useLocalScript.Font = new System.Drawing.Font("宋体", 12F);
            this.chb_useLocalScript.Location = new System.Drawing.Point(34, 25);
            this.chb_useLocalScript.Name = "chb_useLocalScript";
            this.chb_useLocalScript.Size = new System.Drawing.Size(243, 20);
            this.chb_useLocalScript.TabIndex = 9;
            this.chb_useLocalScript.Text = "使用本地目录中包含的Lua脚本";
            this.chb_useLocalScript.UseVisualStyleBackColor = true;
            this.chb_useLocalScript.CheckedChanged += new System.EventHandler(this.chb_useLocalScript_CheckedChanged);
            this.chb_useLocalScript.Click += new System.EventHandler(this.chb_useLocalScript_Click);
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(18, 80);
            this.panel14.TabIndex = 11;
            // 
            // panel15
            // 
            this.panel15.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel15.Location = new System.Drawing.Point(541, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(30, 80);
            this.panel15.TabIndex = 14;
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 96);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(571, 13);
            this.panel12.TabIndex = 18;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 67);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(571, 29);
            this.panel6.TabIndex = 16;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txt_scriptPath);
            this.panel7.Controls.Add(this.panel21);
            this.panel7.Controls.Add(this.btn_selectScript);
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(571, 29);
            this.panel7.TabIndex = 12;
            // 
            // txt_scriptPath
            // 
            this.txt_scriptPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_scriptPath.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txt_scriptPath.Location = new System.Drawing.Point(101, 0);
            this.txt_scriptPath.Name = "txt_scriptPath";
            this.txt_scriptPath.Size = new System.Drawing.Size(341, 29);
            this.txt_scriptPath.TabIndex = 3;
            this.txt_scriptPath.TabStop = false;
            this.txt_scriptPath.TextChanged += new System.EventHandler(this.txt_scriptPath_TextChanged);
            // 
            // panel21
            // 
            this.panel21.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel21.Location = new System.Drawing.Point(442, 0);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(15, 29);
            this.panel21.TabIndex = 15;
            // 
            // btn_selectScript
            // 
            this.btn_selectScript.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_selectScript.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_selectScript.Location = new System.Drawing.Point(457, 0);
            this.btn_selectScript.Name = "btn_selectScript";
            this.btn_selectScript.Size = new System.Drawing.Size(84, 29);
            this.btn_selectScript.TabIndex = 16;
            this.btn_selectScript.Text = "选择目录";
            this.btn_selectScript.UseVisualStyleBackColor = true;
            this.btn_selectScript.Click += new System.EventHandler(this.btn_selectScript_Click);
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(541, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(30, 29);
            this.panel10.TabIndex = 13;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label3);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(101, 29);
            this.panel8.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(16, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "本地脚本：";
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 48);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(571, 19);
            this.panel11.TabIndex = 17;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 19);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(571, 29);
            this.panel5.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txt_firmwareFile);
            this.panel3.Controls.Add(this.panel20);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.btn_selectFW);
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(571, 29);
            this.panel3.TabIndex = 12;
            // 
            // panel20
            // 
            this.panel20.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel20.Location = new System.Drawing.Point(442, 0);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(15, 29);
            this.panel20.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(101, 29);
            this.panel2.TabIndex = 11;
            // 
            // btn_selectFW
            // 
            this.btn_selectFW.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_selectFW.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_selectFW.Location = new System.Drawing.Point(457, 0);
            this.btn_selectFW.Name = "btn_selectFW";
            this.btn_selectFW.Size = new System.Drawing.Size(84, 29);
            this.btn_selectFW.TabIndex = 14;
            this.btn_selectFW.Text = "选择文件";
            this.btn_selectFW.UseVisualStyleBackColor = true;
            this.btn_selectFW.Click += new System.EventHandler(this.btn_selectFW_Click);
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(541, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(30, 29);
            this.panel9.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(571, 19);
            this.panel4.TabIndex = 13;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.cmb_serial);
            this.panel16.Controls.Add(this.panel22);
            this.panel16.Controls.Add(this.pic_connected);
            this.panel16.Controls.Add(this.panel17);
            this.panel16.Controls.Add(this.panel18);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel16.Location = new System.Drawing.Point(0, 506);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(571, 31);
            this.panel16.TabIndex = 14;
            // 
            // cmb_serial
            // 
            this.cmb_serial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_serial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_serial.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_serial.FormattingEnabled = true;
            this.cmb_serial.Location = new System.Drawing.Point(83, 0);
            this.cmb_serial.Name = "cmb_serial";
            this.cmb_serial.Size = new System.Drawing.Size(437, 29);
            this.cmb_serial.TabIndex = 14;
            this.cmb_serial.TabStop = false;
            this.cmb_serial.SelectedIndexChanged += new System.EventHandler(this.cmb_serial_SelectedIndexChanged);
            // 
            // panel22
            // 
            this.panel22.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel22.Location = new System.Drawing.Point(520, 0);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(10, 31);
            this.panel22.TabIndex = 16;
            // 
            // pic_connected
            // 
            this.pic_connected.Dock = System.Windows.Forms.DockStyle.Right;
            this.pic_connected.Image = global::FWLoader.Properties.Resources.grayball;
            this.pic_connected.InitialImage = null;
            this.pic_connected.Location = new System.Drawing.Point(530, 0);
            this.pic_connected.Name = "pic_connected";
            this.pic_connected.Size = new System.Drawing.Size(26, 31);
            this.pic_connected.TabIndex = 17;
            this.pic_connected.TabStop = false;
            this.pic_connected.Click += new System.EventHandler(this.pic_connected_Click);
            this.pic_connected.DoubleClick += new System.EventHandler(this.pic_connected_DoubleClick);
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.label2);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(83, 31);
            this.panel17.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "下载端口：";
            // 
            // panel18
            // 
            this.panel18.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel18.Location = new System.Drawing.Point(556, 0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(15, 31);
            this.panel18.TabIndex = 15;
            // 
            // panel19
            // 
            this.panel19.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel19.Location = new System.Drawing.Point(0, 501);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(571, 5);
            this.panel19.TabIndex = 19;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.main_log);
            this.tabControl1.Controls.Add(this.uart_log);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 12F);
            this.tabControl1.Location = new System.Drawing.Point(0, 274);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(571, 227);
            this.tabControl1.TabIndex = 20;
            // 
            // main_log
            // 
            this.main_log.Controls.Add(this.rtb_mainlog);
            this.main_log.Location = new System.Drawing.Point(4, 26);
            this.main_log.Name = "main_log";
            this.main_log.Padding = new System.Windows.Forms.Padding(3);
            this.main_log.Size = new System.Drawing.Size(563, 197);
            this.main_log.TabIndex = 0;
            this.main_log.Text = "程序配置";
            this.main_log.UseVisualStyleBackColor = true;
            // 
            // rtb_mainlog
            // 
            this.rtb_mainlog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_mainlog.HScrollBar = false;
            this.rtb_mainlog.Location = new System.Drawing.Point(3, 3);
            this.rtb_mainlog.Margins.Capacity = 0;
            this.rtb_mainlog.Margins.Left = 0;
            this.rtb_mainlog.Margins.Right = 0;
            this.rtb_mainlog.Name = "rtb_mainlog";
            this.rtb_mainlog.Size = new System.Drawing.Size(557, 191);
            this.rtb_mainlog.TabIndex = 0;
            // 
            // uart_log
            // 
            this.uart_log.Controls.Add(this.rtb_uartlog);
            this.uart_log.Location = new System.Drawing.Point(4, 26);
            this.uart_log.Name = "uart_log";
            this.uart_log.Padding = new System.Windows.Forms.Padding(3);
            this.uart_log.Size = new System.Drawing.Size(563, 197);
            this.uart_log.TabIndex = 1;
            this.uart_log.Text = "串口消息";
            this.uart_log.UseVisualStyleBackColor = true;
            // 
            // rtb_uartlog
            // 
            this.rtb_uartlog.ContextMenuStrip = this.menu_uartlog;
            this.rtb_uartlog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_uartlog.HScrollBar = false;
            this.rtb_uartlog.Location = new System.Drawing.Point(3, 3);
            this.rtb_uartlog.Margins.Capacity = 0;
            this.rtb_uartlog.Margins.Left = 0;
            this.rtb_uartlog.Margins.Right = 0;
            this.rtb_uartlog.Name = "rtb_uartlog";
            this.rtb_uartlog.Size = new System.Drawing.Size(557, 191);
            this.rtb_uartlog.TabIndex = 1;
            // 
            // menu_uartlog
            // 
            this.menu_uartlog.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu_uartlog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空ToolStripMenuItem});
            this.menu_uartlog.Name = "menu_uartlog";
            this.menu_uartlog.Size = new System.Drawing.Size(101, 26);
            this.menu_uartlog.Text = "清空";
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // bgw_AutoselectCOM
            // 
            this.bgw_AutoselectCOM.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_AutoselectCOM_DoWork);
            // 
            // bgw_Exe
            // 
            this.bgw_Exe.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_Exe_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(571, 559);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel19);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Esp32C3固件下载器 V0.17 -抄袭的不仅仅是梦想";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_connected)).EndInit();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.main_log.ResumeLayout(false);
            this.uart_log.ResumeLayout(false);
            this.menu_uartlog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_downloadFull;
        private System.Windows.Forms.Button btn_downloadScript;
        private System.Windows.Forms.TextBox txt_firmwareFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_generateFactorySW;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txt_scriptPath;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chb_usePackageScript;
        private System.Windows.Forms.CheckBox chb_useLocalScript;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.ComboBox cmb_serial;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Button btn_selectFW;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Button btn_selectScript;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.PictureBox pic_connected;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage main_log;
        private ScintillaNET.Scintilla rtb_mainlog;
        private System.Windows.Forms.TabPage uart_log;
        private ScintillaNET.Scintilla rtb_uartlog;
        private System.Windows.Forms.ContextMenuStrip menu_uartlog;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bgw_AutoselectCOM;
        private System.ComponentModel.BackgroundWorker bgw_Exe;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

