﻿namespace scheduler
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.msDBStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.hideConflictsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsHideDS = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsHideOC = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTest = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdAvail = new System.Windows.Forms.OpenFileDialog();
            this.ofdSkeleton = new System.Windows.Forms.OpenFileDialog();
            this.ofdSave = new System.Windows.Forms.OpenFileDialog();
            this.tpPreview = new System.Windows.Forms.TabPage();
            this.wbPreview = new System.Windows.Forms.WebBrowser();
            this.tpSchedule = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btTest2 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.lstUnassigned = new System.Windows.Forms.ListView();
            this.lstAssigned = new System.Windows.Forms.ListView();
            this.btAssignToShift = new System.Windows.Forms.Button();
            this.btUnassignToShift = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lbInfo = new System.Windows.Forms.Label();
            this.lstShifts = new System.Windows.Forms.ListView();
            this.lstEmployees = new System.Windows.Forms.ListView();
            this.lstAvailPreview = new System.Windows.Forms.ListView();
            this.lbHoursInfo = new System.Windows.Forms.Label();
            this.lbShiftInfo = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.lbEmployeeHeader = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lbEmployeeCount = new System.Windows.Forms.Label();
            this.lbCurrent = new System.Windows.Forms.Label();
            this.btAutoAll = new System.Windows.Forms.Button();
            this.btSubmit = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbUploading = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbUploading = new System.Windows.Forms.ToolStripProgressBar();
            this.lstConflicts = new System.Windows.Forms.RichTextBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btUndoSubmit = new System.Windows.Forms.Button();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.tpConfig = new System.Windows.Forms.TabPage();
            this.tabConfigs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtbHoursExceptions = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tpAvail = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbAvail = new System.Windows.Forms.RichTextBox();
            this.btDownloadFresh = new System.Windows.Forms.Button();
            this.btAvailSave = new System.Windows.Forms.Button();
            this.btAvailClear = new System.Windows.Forms.Button();
            this.btAvailReload = new System.Windows.Forms.Button();
            this.tpSkeleton = new System.Windows.Forms.TabPage();
            this.rtbSkeleton = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btSkeletonSave = new System.Windows.Forms.Button();
            this.btSkeletonClear = new System.Windows.Forms.Button();
            this.btSkeletonReload = new System.Windows.Forms.Button();
            this.tpBasic = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txDBPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txDBUsername = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txDBHostName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbBlankIt = new System.Windows.Forms.CheckBox();
            this.txDBName = new System.Windows.Forms.TextBox();
            this.btTestConnection = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txAvailLoc = new System.Windows.Forms.TextBox();
            this.txSkeletonLoc = new System.Windows.Forms.TextBox();
            this.txSaveLoc = new System.Windows.Forms.TextBox();
            this.btAvailLoc = new System.Windows.Forms.Button();
            this.btSkeletonLoc = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.btSaveLoc = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txMaxHours = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txMinHours = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txSweet = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txLow = new System.Windows.Forms.TextBox();
            this.txMedium = new System.Windows.Forms.TextBox();
            this.txHigh = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txHighV = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txMediumV = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txLowV = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.txHourMod = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txPriority = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txAvailMod = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.txPreferMod = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.btUpdateFileLoc = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.Config = new System.Windows.Forms.TabControl();
            this.msMain.SuspendLayout();
            this.tpPreview.SuspendLayout();
            this.tpSchedule.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tpConfig.SuspendLayout();
            this.tabConfigs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tpAvail.SuspendLayout();
            this.tpSkeleton.SuspendLayout();
            this.tpBasic.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.Config.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.DarkGray;
            this.msMain.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.msDBStatus,
            this.hideConflictsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.msMain.Size = new System.Drawing.Size(1425, 24);
            this.msMain.TabIndex = 7;
            this.msMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // fileExit
            // 
            this.fileExit.Name = "fileExit";
            this.fileExit.Size = new System.Drawing.Size(99, 22);
            this.fileExit.Text = "Exit";
            this.fileExit.Click += new System.EventHandler(this.fileExit_Click);
            // 
            // msDBStatus
            // 
            this.msDBStatus.BackColor = System.Drawing.Color.Red;
            this.msDBStatus.Name = "msDBStatus";
            this.msDBStatus.Size = new System.Drawing.Size(201, 20);
            this.msDBStatus.Text = "Database Connection Status";
            this.msDBStatus.ToolTipText = "Red = Not Connected. Green - Connected.";
            // 
            // hideConflictsToolStripMenuItem
            // 
            this.hideConflictsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtsHideDS,
            this.mtsHideOC});
            this.hideConflictsToolStripMenuItem.Name = "hideConflictsToolStripMenuItem";
            this.hideConflictsToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.hideConflictsToolStripMenuItem.Text = "Hide Conflicts";
            // 
            // mtsHideDS
            // 
            this.mtsHideDS.Name = "mtsHideDS";
            this.mtsHideDS.Size = new System.Drawing.Size(191, 22);
            this.mtsHideDS.Text = "Hide Double Shifts";
            this.mtsHideDS.Click += new System.EventHandler(this.mtsHideDS_Click);
            // 
            // mtsHideOC
            // 
            this.mtsHideOC.Name = "mtsHideOC";
            this.mtsHideOC.Size = new System.Drawing.Size(191, 22);
            this.mtsHideOC.Text = "Hide Open/Close";
            this.mtsHideOC.Click += new System.EventHandler(this.mtsHideOC_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmTest});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.Visible = false;
            // 
            // tsmTest
            // 
            this.tsmTest.Name = "tsmTest";
            this.tsmTest.Size = new System.Drawing.Size(152, 22);
            this.tsmTest.Text = "Test";
            this.tsmTest.Click += new System.EventHandler(this.tsmTest_Click);
            // 
            // tpPreview
            // 
            this.tpPreview.BackColor = System.Drawing.Color.Silver;
            this.tpPreview.Controls.Add(this.wbPreview);
            this.tpPreview.Location = new System.Drawing.Point(4, 25);
            this.tpPreview.Name = "tpPreview";
            this.tpPreview.Padding = new System.Windows.Forms.Padding(3);
            this.tpPreview.Size = new System.Drawing.Size(1417, 702);
            this.tpPreview.TabIndex = 3;
            this.tpPreview.Text = "Schedule Preview";
            // 
            // wbPreview
            // 
            this.wbPreview.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.wbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbPreview.Location = new System.Drawing.Point(3, 3);
            this.wbPreview.MinimumSize = new System.Drawing.Size(23, 21);
            this.wbPreview.Name = "wbPreview";
            this.wbPreview.Size = new System.Drawing.Size(1411, 696);
            this.wbPreview.TabIndex = 0;
            // 
            // tpSchedule
            // 
            this.tpSchedule.BackColor = System.Drawing.Color.Silver;
            this.tpSchedule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tpSchedule.Controls.Add(this.label41);
            this.tpSchedule.Controls.Add(this.label40);
            this.tpSchedule.Controls.Add(this.label39);
            this.tpSchedule.Controls.Add(this.btUndoSubmit);
            this.tpSchedule.Controls.Add(this.lbStatus);
            this.tpSchedule.Controls.Add(this.lstConflicts);
            this.tpSchedule.Controls.Add(this.statusStrip1);
            this.tpSchedule.Controls.Add(this.btSubmit);
            this.tpSchedule.Controls.Add(this.btAutoAll);
            this.tpSchedule.Controls.Add(this.lbCurrent);
            this.tpSchedule.Controls.Add(this.lbEmployeeCount);
            this.tpSchedule.Controls.Add(this.label23);
            this.tpSchedule.Controls.Add(this.lbEmployeeHeader);
            this.tpSchedule.Controls.Add(this.btSave);
            this.tpSchedule.Controls.Add(this.lbShiftInfo);
            this.tpSchedule.Controls.Add(this.lbHoursInfo);
            this.tpSchedule.Controls.Add(this.lstAvailPreview);
            this.tpSchedule.Controls.Add(this.lstEmployees);
            this.tpSchedule.Controls.Add(this.lstShifts);
            this.tpSchedule.Controls.Add(this.lbInfo);
            this.tpSchedule.Controls.Add(this.label21);
            this.tpSchedule.Controls.Add(this.label19);
            this.tpSchedule.Controls.Add(this.btUnassignToShift);
            this.tpSchedule.Controls.Add(this.btAssignToShift);
            this.tpSchedule.Controls.Add(this.lstAssigned);
            this.tpSchedule.Controls.Add(this.lstUnassigned);
            this.tpSchedule.Controls.Add(this.label18);
            this.tpSchedule.Controls.Add(this.btTest2);
            this.tpSchedule.Controls.Add(this.linkLabel1);
            this.tpSchedule.Location = new System.Drawing.Point(4, 25);
            this.tpSchedule.Name = "tpSchedule";
            this.tpSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.tpSchedule.Size = new System.Drawing.Size(1417, 702);
            this.tpSchedule.TabIndex = 2;
            this.tpSchedule.Text = "Scheduling";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(73, 179);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 16);
            this.linkLabel1.TabIndex = 1;
            // 
            // btTest2
            // 
            this.btTest2.Location = new System.Drawing.Point(200, 3);
            this.btTest2.Name = "btTest2";
            this.btTest2.Size = new System.Drawing.Size(39, 23);
            this.btTest2.TabIndex = 3;
            this.btTest2.Text = "Clear";
            this.btTest2.UseVisualStyleBackColor = true;
            this.btTest2.Visible = false;
            this.btTest2.Click += new System.EventHandler(this.ReloadSchedule);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(73, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 16);
            this.label18.TabIndex = 4;
            this.label18.Text = "List Of Shifts";
            // 
            // lstUnassigned
            // 
            this.lstUnassigned.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstUnassigned.Location = new System.Drawing.Point(309, 348);
            this.lstUnassigned.MultiSelect = false;
            this.lstUnassigned.Name = "lstUnassigned";
            this.lstUnassigned.Size = new System.Drawing.Size(138, 318);
            this.lstUnassigned.TabIndex = 5;
            this.lstUnassigned.UseCompatibleStateImageBehavior = false;
            this.lstUnassigned.SelectedIndexChanged += new System.EventHandler(this.lstUnassigned_SelectedIndexChanged);
            this.lstUnassigned.DoubleClick += new System.EventHandler(this.AssignToShift);
            this.lstUnassigned.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AssignToShift);
            this.lstUnassigned.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstUnassigned_SelectedIndexChanged);
            // 
            // lstAssigned
            // 
            this.lstAssigned.Location = new System.Drawing.Point(309, 39);
            this.lstAssigned.MultiSelect = false;
            this.lstAssigned.Name = "lstAssigned";
            this.lstAssigned.Size = new System.Drawing.Size(138, 283);
            this.lstAssigned.TabIndex = 6;
            this.lstAssigned.UseCompatibleStateImageBehavior = false;
            this.lstAssigned.SelectedIndexChanged += new System.EventHandler(this.lstAssigned_SelectedIndexChanged);
            this.lstAssigned.DoubleClick += new System.EventHandler(this.UnassignToShift);
            this.lstAssigned.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UnassignToShift);
            this.lstAssigned.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstAssigned_SelectedIndexChanged);
            // 
            // btAssignToShift
            // 
            this.btAssignToShift.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAssignToShift.Image = global::scheduler.Properties.Resources.Arrow_Circle_Up_256;
            this.btAssignToShift.Location = new System.Drawing.Point(1179, 608);
            this.btAssignToShift.Name = "btAssignToShift";
            this.btAssignToShift.Size = new System.Drawing.Size(46, 43);
            this.btAssignToShift.TabIndex = 7;
            this.btAssignToShift.UseVisualStyleBackColor = true;
            this.btAssignToShift.Visible = false;
            this.btAssignToShift.Click += new System.EventHandler(this.AssignToShift);
            // 
            // btUnassignToShift
            // 
            this.btUnassignToShift.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUnassignToShift.Image = global::scheduler.Properties.Resources.Arrow_Circle_Down_256;
            this.btUnassignToShift.Location = new System.Drawing.Point(1272, 608);
            this.btUnassignToShift.Name = "btUnassignToShift";
            this.btUnassignToShift.Size = new System.Drawing.Size(46, 43);
            this.btUnassignToShift.TabIndex = 8;
            this.btUnassignToShift.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btUnassignToShift.UseVisualStyleBackColor = true;
            this.btUnassignToShift.Visible = false;
            this.btUnassignToShift.Click += new System.EventHandler(this.UnassignToShift);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(311, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(116, 16);
            this.label19.TabIndex = 9;
            this.label19.Text = "Assigned To Shift";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(306, 329);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(123, 16);
            this.label21.TabIndex = 10;
            this.label21.Text = "Able To Work Shift";
            // 
            // lbInfo
            // 
            this.lbInfo.BackColor = System.Drawing.Color.Orange;
            this.lbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbInfo.Location = new System.Drawing.Point(454, 39);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(299, 37);
            this.lbInfo.TabIndex = 11;
            this.lbInfo.Text = "Skeleton Suggests X employees\r\nfor this shift.";
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstShifts
            // 
            this.lstShifts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstShifts.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstShifts.Location = new System.Drawing.Point(3, 39);
            this.lstShifts.MultiSelect = false;
            this.lstShifts.Name = "lstShifts";
            this.lstShifts.Size = new System.Drawing.Size(298, 625);
            this.lstShifts.TabIndex = 12;
            this.lstShifts.UseCompatibleStateImageBehavior = false;
            this.lstShifts.View = System.Windows.Forms.View.Details;
            this.lstShifts.SelectedIndexChanged += new System.EventHandler(this.lstShifts_SelectedIndexChanged);
            this.lstShifts.DoubleClick += new System.EventHandler(this.AutoAssign);
            // 
            // lstEmployees
            // 
            this.lstEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstEmployees.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEmployees.Location = new System.Drawing.Point(760, 107);
            this.lstEmployees.Name = "lstEmployees";
            this.lstEmployees.Size = new System.Drawing.Size(338, 559);
            this.lstEmployees.TabIndex = 13;
            this.lstEmployees.TileSize = new System.Drawing.Size(71, 40);
            this.lstEmployees.UseCompatibleStateImageBehavior = false;
            this.lstEmployees.View = System.Windows.Forms.View.Tile;
            this.lstEmployees.SelectedIndexChanged += new System.EventHandler(this.lstEmployees_SelectedIndexChanged);
            // 
            // lstAvailPreview
            // 
            this.lstAvailPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstAvailPreview.Location = new System.Drawing.Point(454, 83);
            this.lstAvailPreview.Name = "lstAvailPreview";
            this.lstAvailPreview.Size = new System.Drawing.Size(299, 582);
            this.lstAvailPreview.TabIndex = 14;
            this.lstAvailPreview.TileSize = new System.Drawing.Size(50, 50);
            this.lstAvailPreview.UseCompatibleStateImageBehavior = false;
            this.lstAvailPreview.View = System.Windows.Forms.View.Details;
            // 
            // lbHoursInfo
            // 
            this.lbHoursInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbHoursInfo.Location = new System.Drawing.Point(760, 39);
            this.lbHoursInfo.Name = "lbHoursInfo";
            this.lbHoursInfo.Size = new System.Drawing.Size(165, 37);
            this.lbHoursInfo.TabIndex = 16;
            this.lbHoursInfo.Text = "Total Hours:\r\nAllocated:";
            this.lbHoursInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbShiftInfo
            // 
            this.lbShiftInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbShiftInfo.Location = new System.Drawing.Point(933, 39);
            this.lbShiftInfo.Name = "lbShiftInfo";
            this.lbShiftInfo.Size = new System.Drawing.Size(165, 37);
            this.lbShiftInfo.TabIndex = 17;
            this.lbShiftInfo.Text = "Total Shifts:\r\nAllocated:";
            this.lbShiftInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(246, 3);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(42, 23);
            this.btSave.TabIndex = 18;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Visible = false;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // lbEmployeeHeader
            // 
            this.lbEmployeeHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbEmployeeHeader.Location = new System.Drawing.Point(760, 83);
            this.lbEmployeeHeader.Name = "lbEmployeeHeader";
            this.lbEmployeeHeader.Size = new System.Drawing.Size(338, 20);
            this.lbEmployeeHeader.TabIndex = 19;
            this.lbEmployeeHeader.Text = "** All Employees And Hours Working **";
            this.lbEmployeeHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label23.Location = new System.Drawing.Point(1105, 138);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(303, 20);
            this.label23.TabIndex = 20;
            this.label23.Text = "** NOTICE **";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbEmployeeCount
            // 
            this.lbEmployeeCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbEmployeeCount.Location = new System.Drawing.Point(760, 16);
            this.lbEmployeeCount.Name = "lbEmployeeCount";
            this.lbEmployeeCount.Size = new System.Drawing.Size(338, 21);
            this.lbEmployeeCount.TabIndex = 21;
            this.lbEmployeeCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCurrent
            // 
            this.lbCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCurrent.Location = new System.Drawing.Point(454, 3);
            this.lbCurrent.Name = "lbCurrent";
            this.lbCurrent.Size = new System.Drawing.Size(299, 34);
            this.lbCurrent.TabIndex = 22;
            this.lbCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btAutoAll
            // 
            this.btAutoAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btAutoAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btAutoAll.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btAutoAll.Location = new System.Drawing.Point(1168, 5);
            this.btAutoAll.Name = "btAutoAll";
            this.btAutoAll.Size = new System.Drawing.Size(240, 55);
            this.btAutoAll.TabIndex = 23;
            this.btAutoAll.Text = "AUTO ASSIGN ALL!";
            this.btAutoAll.UseVisualStyleBackColor = false;
            this.btAutoAll.Click += new System.EventHandler(this.btAutoAll_Click);
            // 
            // btSubmit
            // 
            this.btSubmit.BackColor = System.Drawing.Color.HotPink;
            this.btSubmit.Location = new System.Drawing.Point(1168, 66);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(240, 32);
            this.btSubmit.TabIndex = 24;
            this.btSubmit.Text = "SUBMIT SCHEDULE";
            this.btSubmit.UseVisualStyleBackColor = false;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbUploading,
            this.pbUploading});
            this.statusStrip1.Location = new System.Drawing.Point(3, 671);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1407, 24);
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbUploading
            // 
            this.lbUploading.Name = "lbUploading";
            this.lbUploading.Size = new System.Drawing.Size(93, 19);
            this.lbUploading.Text = "Upload Progress";
            // 
            // pbUploading
            // 
            this.pbUploading.Name = "pbUploading";
            this.pbUploading.Size = new System.Drawing.Size(229, 18);
            this.pbUploading.Step = 1;
            this.pbUploading.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // lstConflicts
            // 
            this.lstConflicts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstConflicts.Location = new System.Drawing.Point(1105, 161);
            this.lstConflicts.Name = "lstConflicts";
            this.lstConflicts.Size = new System.Drawing.Size(303, 504);
            this.lstConflicts.TabIndex = 26;
            this.lstConflicts.Text = "";
            // 
            // lbStatus
            // 
            this.lbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbStatus.AutoSize = true;
            this.lbStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lbStatus.Location = new System.Drawing.Point(349, 669);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 16);
            this.lbStatus.TabIndex = 27;
            // 
            // btUndoSubmit
            // 
            this.btUndoSubmit.BackColor = System.Drawing.Color.Red;
            this.btUndoSubmit.ForeColor = System.Drawing.Color.Yellow;
            this.btUndoSubmit.Location = new System.Drawing.Point(1168, 103);
            this.btUndoSubmit.Name = "btUndoSubmit";
            this.btUndoSubmit.Size = new System.Drawing.Size(240, 32);
            this.btUndoSubmit.TabIndex = 28;
            this.btUndoSubmit.Text = "**UNDO SUBMIT**";
            this.btUndoSubmit.UseVisualStyleBackColor = false;
            this.btUndoSubmit.Click += new System.EventHandler(this.btUndoSubmit_Click);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(1106, 25);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(56, 15);
            this.label39.TabIndex = 29;
            this.label39.Text = "Step 1:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(1106, 112);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(53, 15);
            this.label40.TabIndex = 30;
            this.label40.Text = "Uh Oh:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(1106, 75);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(56, 15);
            this.label41.TabIndex = 31;
            this.label41.Text = "Step 2:";
            this.label41.Click += new System.EventHandler(this.label41_Click);
            // 
            // tpConfig
            // 
            this.tpConfig.BackColor = System.Drawing.Color.Silver;
            this.tpConfig.Controls.Add(this.tabConfigs);
            this.tpConfig.Location = new System.Drawing.Point(4, 25);
            this.tpConfig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpConfig.Name = "tpConfig";
            this.tpConfig.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpConfig.Size = new System.Drawing.Size(1417, 702);
            this.tpConfig.TabIndex = 1;
            this.tpConfig.Text = "Config Page";
            // 
            // tabConfigs
            // 
            this.tabConfigs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabConfigs.Controls.Add(this.tpBasic);
            this.tabConfigs.Controls.Add(this.tpSkeleton);
            this.tabConfigs.Controls.Add(this.tpAvail);
            this.tabConfigs.Controls.Add(this.tabPage1);
            this.tabConfigs.Location = new System.Drawing.Point(0, 0);
            this.tabConfigs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabConfigs.Name = "tabConfigs";
            this.tabConfigs.SelectedIndex = 0;
            this.tabConfigs.Size = new System.Drawing.Size(1416, 704);
            this.tabConfigs.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Silver;
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.rtbHoursExceptions);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1408, 675);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Max Hour Exceptions";
            // 
            // rtbHoursExceptions
            // 
            this.rtbHoursExceptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbHoursExceptions.Location = new System.Drawing.Point(8, 139);
            this.rtbHoursExceptions.Name = "rtbHoursExceptions";
            this.rtbHoursExceptions.Size = new System.Drawing.Size(1391, 567);
            this.rtbHoursExceptions.TabIndex = 0;
            this.rtbHoursExceptions.Text = "";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(8, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1392, 128);
            this.label9.TabIndex = 1;
            this.label9.Text = resources.GetString("label9.Text");
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tpAvail
            // 
            this.tpAvail.BackColor = System.Drawing.Color.Silver;
            this.tpAvail.Controls.Add(this.btAvailReload);
            this.tpAvail.Controls.Add(this.btAvailClear);
            this.tpAvail.Controls.Add(this.btAvailSave);
            this.tpAvail.Controls.Add(this.btDownloadFresh);
            this.tpAvail.Controls.Add(this.rtbAvail);
            this.tpAvail.Controls.Add(this.label3);
            this.tpAvail.Location = new System.Drawing.Point(4, 25);
            this.tpAvail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpAvail.Name = "tpAvail";
            this.tpAvail.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpAvail.Size = new System.Drawing.Size(1408, 675);
            this.tpAvail.TabIndex = 0;
            this.tpAvail.Text = "Availabilities";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Availabilities:";
            // 
            // rtbAvail
            // 
            this.rtbAvail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbAvail.Location = new System.Drawing.Point(134, 13);
            this.rtbAvail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbAvail.MinimumSize = new System.Drawing.Size(132, 132);
            this.rtbAvail.Name = "rtbAvail";
            this.rtbAvail.Size = new System.Drawing.Size(1273, 692);
            this.rtbAvail.TabIndex = 4;
            this.rtbAvail.Text = "";
            this.rtbAvail.WordWrap = false;
            this.rtbAvail.TextChanged += new System.EventHandler(this.rtbAvail_TextChanged);
            // 
            // btDownloadFresh
            // 
            this.btDownloadFresh.Enabled = false;
            this.btDownloadFresh.Location = new System.Drawing.Point(9, 44);
            this.btDownloadFresh.Name = "btDownloadFresh";
            this.btDownloadFresh.Size = new System.Drawing.Size(118, 66);
            this.btDownloadFresh.TabIndex = 0;
            this.btDownloadFresh.Text = "Download Fresh Availability";
            this.btDownloadFresh.UseVisualStyleBackColor = true;
            this.btDownloadFresh.Click += new System.EventHandler(this.btDownloadFresh_Click);
            // 
            // btAvailSave
            // 
            this.btAvailSave.Location = new System.Drawing.Point(9, 199);
            this.btAvailSave.Name = "btAvailSave";
            this.btAvailSave.Size = new System.Drawing.Size(118, 31);
            this.btAvailSave.TabIndex = 2;
            this.btAvailSave.Text = "Save";
            this.btAvailSave.UseVisualStyleBackColor = true;
            this.btAvailSave.Click += new System.EventHandler(this.btAvailSave_Click);
            // 
            // btAvailClear
            // 
            this.btAvailClear.Location = new System.Drawing.Point(9, 237);
            this.btAvailClear.Name = "btAvailClear";
            this.btAvailClear.Size = new System.Drawing.Size(118, 31);
            this.btAvailClear.TabIndex = 3;
            this.btAvailClear.Text = "Clear";
            this.btAvailClear.UseVisualStyleBackColor = true;
            this.btAvailClear.Click += new System.EventHandler(this.btAvailClear_Click);
            // 
            // btAvailReload
            // 
            this.btAvailReload.Location = new System.Drawing.Point(9, 116);
            this.btAvailReload.Name = "btAvailReload";
            this.btAvailReload.Size = new System.Drawing.Size(117, 77);
            this.btAvailReload.TabIndex = 1;
            this.btAvailReload.Text = "Reload From Availability File";
            this.btAvailReload.UseVisualStyleBackColor = true;
            this.btAvailReload.Click += new System.EventHandler(this.btAvailReload_Click);
            // 
            // tpSkeleton
            // 
            this.tpSkeleton.BackColor = System.Drawing.Color.Silver;
            this.tpSkeleton.Controls.Add(this.btSkeletonReload);
            this.tpSkeleton.Controls.Add(this.btSkeletonClear);
            this.tpSkeleton.Controls.Add(this.btSkeletonSave);
            this.tpSkeleton.Controls.Add(this.label4);
            this.tpSkeleton.Controls.Add(this.rtbSkeleton);
            this.tpSkeleton.Location = new System.Drawing.Point(4, 25);
            this.tpSkeleton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpSkeleton.Name = "tpSkeleton";
            this.tpSkeleton.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpSkeleton.Size = new System.Drawing.Size(1408, 675);
            this.tpSkeleton.TabIndex = 1;
            this.tpSkeleton.Text = "Shift Skeleton";
            // 
            // rtbSkeleton
            // 
            this.rtbSkeleton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbSkeleton.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSkeleton.Location = new System.Drawing.Point(134, 13);
            this.rtbSkeleton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbSkeleton.MinimumSize = new System.Drawing.Size(132, 132);
            this.rtbSkeleton.Name = "rtbSkeleton";
            this.rtbSkeleton.Size = new System.Drawing.Size(1273, 692);
            this.rtbSkeleton.TabIndex = 3;
            this.rtbSkeleton.Text = "";
            this.rtbSkeleton.WordWrap = false;
            this.rtbSkeleton.TextChanged += new System.EventHandler(this.rtbSkeleton_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Shift Skeleton:";
            // 
            // btSkeletonSave
            // 
            this.btSkeletonSave.Location = new System.Drawing.Point(10, 128);
            this.btSkeletonSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btSkeletonSave.Name = "btSkeletonSave";
            this.btSkeletonSave.Size = new System.Drawing.Size(117, 31);
            this.btSkeletonSave.TabIndex = 1;
            this.btSkeletonSave.Text = "Save";
            this.btSkeletonSave.UseVisualStyleBackColor = true;
            this.btSkeletonSave.Click += new System.EventHandler(this.btSkeletonSave_Click);
            // 
            // btSkeletonClear
            // 
            this.btSkeletonClear.Location = new System.Drawing.Point(10, 166);
            this.btSkeletonClear.Name = "btSkeletonClear";
            this.btSkeletonClear.Size = new System.Drawing.Size(117, 31);
            this.btSkeletonClear.TabIndex = 2;
            this.btSkeletonClear.Text = "Clear";
            this.btSkeletonClear.UseVisualStyleBackColor = true;
            this.btSkeletonClear.Click += new System.EventHandler(this.btSkeletonClear_Click);
            // 
            // btSkeletonReload
            // 
            this.btSkeletonReload.Location = new System.Drawing.Point(10, 44);
            this.btSkeletonReload.Name = "btSkeletonReload";
            this.btSkeletonReload.Size = new System.Drawing.Size(117, 77);
            this.btSkeletonReload.TabIndex = 0;
            this.btSkeletonReload.Text = "Reload From Shift Skeleton File";
            this.btSkeletonReload.UseVisualStyleBackColor = true;
            this.btSkeletonReload.Click += new System.EventHandler(this.btSkeletonReload_Click);
            // 
            // tpBasic
            // 
            this.tpBasic.BackColor = System.Drawing.Color.Silver;
            this.tpBasic.Controls.Add(this.panel3);
            this.tpBasic.Controls.Add(this.panel2);
            this.tpBasic.Controls.Add(this.panel1);
            this.tpBasic.Location = new System.Drawing.Point(4, 25);
            this.tpBasic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpBasic.Name = "tpBasic";
            this.tpBasic.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpBasic.Size = new System.Drawing.Size(1408, 675);
            this.tpBasic.TabIndex = 2;
            this.tpBasic.Text = "Basic Config";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btTestConnection);
            this.panel1.Controls.Add(this.txDBName);
            this.panel1.Controls.Add(this.cbBlankIt);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txDBHostName);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txDBUsername);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txDBPass);
            this.panel1.Location = new System.Drawing.Point(8, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 555);
            this.panel1.TabIndex = 8;
            // 
            // txDBPass
            // 
            this.txDBPass.Location = new System.Drawing.Point(165, 191);
            this.txDBPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txDBPass.Name = "txDBPass";
            this.txDBPass.PasswordChar = '*';
            this.txDBPass.Size = new System.Drawing.Size(171, 22);
            this.txDBPass.TabIndex = 2;
            this.txDBPass.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btTestConnection_EnterPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Database Username:";
            // 
            // txDBUsername
            // 
            this.txDBUsername.Location = new System.Drawing.Point(165, 138);
            this.txDBUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txDBUsername.Name = "txDBUsername";
            this.txDBUsername.Size = new System.Drawing.Size(171, 22);
            this.txDBUsername.TabIndex = 1;
            this.txDBUsername.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btTestConnection_EnterPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Database Password:";
            // 
            // txDBHostName
            // 
            this.txDBHostName.Location = new System.Drawing.Point(165, 84);
            this.txDBHostName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txDBHostName.Name = "txDBHostName";
            this.txDBHostName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txDBHostName.Size = new System.Drawing.Size(171, 22);
            this.txDBHostName.TabIndex = 0;
            this.txDBHostName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btTestConnection_EnterPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 247);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Database Name:";
            // 
            // cbBlankIt
            // 
            this.cbBlankIt.AutoSize = true;
            this.cbBlankIt.Location = new System.Drawing.Point(14, 295);
            this.cbBlankIt.Name = "cbBlankIt";
            this.cbBlankIt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbBlankIt.Size = new System.Drawing.Size(199, 20);
            this.cbBlankIt.TabIndex = 13;
            this.cbBlankIt.Text = "?Generates Blank Schedule";
            this.cbBlankIt.UseVisualStyleBackColor = true;
            // 
            // txDBName
            // 
            this.txDBName.Location = new System.Drawing.Point(165, 244);
            this.txDBName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txDBName.Name = "txDBName";
            this.txDBName.Size = new System.Drawing.Size(171, 22);
            this.txDBName.TabIndex = 3;
            this.txDBName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btTestConnection_EnterPress);
            // 
            // btTestConnection
            // 
            this.btTestConnection.Location = new System.Drawing.Point(8, 355);
            this.btTestConnection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btTestConnection.Name = "btTestConnection";
            this.btTestConnection.Size = new System.Drawing.Size(322, 31);
            this.btTestConnection.TabIndex = 4;
            this.btTestConnection.Text = "Test Connection And Load";
            this.btTestConnection.UseVisualStyleBackColor = true;
            this.btTestConnection.Click += new System.EventHandler(this.btTestConnection_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Database Host Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "MySQL Connection Information";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(5, 4);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 16);
            this.label24.TabIndex = 9;
            this.label24.Text = "Step 1:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(14, 319);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(246, 32);
            this.label28.TabIndex = 14;
            this.label28.Text = "Check this box in order to start over\r\nand not load the previous save state.";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txPreferMod);
            this.panel2.Controls.Add(this.label42);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.txAvailMod);
            this.panel2.Controls.Add(this.label38);
            this.panel2.Controls.Add(this.txPriority);
            this.panel2.Controls.Add(this.label37);
            this.panel2.Controls.Add(this.txHourMod);
            this.panel2.Controls.Add(this.label36);
            this.panel2.Controls.Add(this.txLowV);
            this.panel2.Controls.Add(this.label35);
            this.panel2.Controls.Add(this.txMediumV);
            this.panel2.Controls.Add(this.label34);
            this.panel2.Controls.Add(this.txHighV);
            this.panel2.Controls.Add(this.label33);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.label31);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.txHigh);
            this.panel2.Controls.Add(this.txMedium);
            this.panel2.Controls.Add(this.txLow);
            this.panel2.Controls.Add(this.label29);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.txSweet);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.txMinHours);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txMaxHours);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.btSaveLoc);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.btSkeletonLoc);
            this.panel2.Controls.Add(this.btAvailLoc);
            this.panel2.Controls.Add(this.txSaveLoc);
            this.panel2.Controls.Add(this.txSkeletonLoc);
            this.panel2.Controls.Add(this.txAvailLoc);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(376, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1021, 338);
            this.panel2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(322, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "File Locations";
            // 
            // txAvailLoc
            // 
            this.txAvailLoc.Location = new System.Drawing.Point(322, 138);
            this.txAvailLoc.Name = "txAvailLoc";
            this.txAvailLoc.Size = new System.Drawing.Size(308, 22);
            this.txAvailLoc.TabIndex = 10;
            // 
            // txSkeletonLoc
            // 
            this.txSkeletonLoc.Location = new System.Drawing.Point(322, 183);
            this.txSkeletonLoc.Name = "txSkeletonLoc";
            this.txSkeletonLoc.Size = new System.Drawing.Size(308, 22);
            this.txSkeletonLoc.TabIndex = 12;
            // 
            // txSaveLoc
            // 
            this.txSaveLoc.Location = new System.Drawing.Point(322, 238);
            this.txSaveLoc.Name = "txSaveLoc";
            this.txSaveLoc.Size = new System.Drawing.Size(308, 22);
            this.txSaveLoc.TabIndex = 14;
            // 
            // btAvailLoc
            // 
            this.btAvailLoc.Location = new System.Drawing.Point(638, 135);
            this.btAvailLoc.Name = "btAvailLoc";
            this.btAvailLoc.Size = new System.Drawing.Size(66, 23);
            this.btAvailLoc.TabIndex = 11;
            this.btAvailLoc.Text = "Browse";
            this.btAvailLoc.UseVisualStyleBackColor = true;
            this.btAvailLoc.Click += new System.EventHandler(this.btAvailLoc_Click);
            // 
            // btSkeletonLoc
            // 
            this.btSkeletonLoc.Location = new System.Drawing.Point(638, 182);
            this.btSkeletonLoc.Name = "btSkeletonLoc";
            this.btSkeletonLoc.Size = new System.Drawing.Size(66, 23);
            this.btSkeletonLoc.TabIndex = 13;
            this.btSkeletonLoc.Text = "Browse";
            this.btSkeletonLoc.UseVisualStyleBackColor = true;
            this.btSkeletonLoc.Click += new System.EventHandler(this.btSkeletonLoc_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(48, 55);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(113, 16);
            this.label17.TabIndex = 0;
            this.label17.Text = "General Settings";
            // 
            // btSaveLoc
            // 
            this.btSaveLoc.Location = new System.Drawing.Point(638, 236);
            this.btSaveLoc.Name = "btSaveLoc";
            this.btSaveLoc.Size = new System.Drawing.Size(66, 23);
            this.btSaveLoc.TabIndex = 15;
            this.btSaveLoc.Text = "Browse";
            this.btSaveLoc.UseVisualStyleBackColor = true;
            this.btSaveLoc.Click += new System.EventHandler(this.btSaveLoc_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(319, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 16);
            this.label10.TabIndex = 11;
            this.label10.Text = "Availability File";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(48, 101);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 16);
            this.label13.TabIndex = 2;
            this.label13.Text = "Minimum Hours:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(48, 129);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 16);
            this.label14.TabIndex = 3;
            this.label14.Text = "Maximum Hours:";
            // 
            // txMaxHours
            // 
            this.txMaxHours.Location = new System.Drawing.Point(175, 129);
            this.txMaxHours.Name = "txMaxHours";
            this.txMaxHours.Size = new System.Drawing.Size(114, 22);
            this.txMaxHours.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(319, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 16);
            this.label11.TabIndex = 12;
            this.label11.Text = "Shift Skeleton";
            // 
            // txMinHours
            // 
            this.txMinHours.Location = new System.Drawing.Point(175, 101);
            this.txMinHours.Name = "txMinHours";
            this.txMinHours.Size = new System.Drawing.Size(114, 22);
            this.txMinHours.TabIndex = 5;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(48, 157);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(86, 16);
            this.label22.TabIndex = 14;
            this.label22.Text = "Ideal Hours:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(322, 219);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(239, 16);
            this.label12.TabIndex = 13;
            this.label12.Text = "Save File - Last Schedule/Inprogress";
            // 
            // txSweet
            // 
            this.txSweet.Location = new System.Drawing.Point(175, 157);
            this.txSweet.Name = "txSweet";
            this.txSweet.Size = new System.Drawing.Size(114, 22);
            this.txSweet.TabIndex = 7;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(7, 4);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(289, 16);
            this.label25.TabIndex = 16;
            this.label25.Text = "Step 2: Change settings as required.";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(322, 75);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(262, 30);
            this.label27.TabIndex = 17;
            this.label27.Text = "Use locations on the shared drive in order to\r\nallow accessibility across multipl" +
    "e machines.";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(717, 55);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(95, 16);
            this.label29.TabIndex = 19;
            this.label29.Text = "Shift Priorities";
            // 
            // txLow
            // 
            this.txLow.Location = new System.Drawing.Point(720, 241);
            this.txLow.Name = "txLow";
            this.txLow.Size = new System.Drawing.Size(293, 22);
            this.txLow.TabIndex = 20;
            // 
            // txMedium
            // 
            this.txMedium.Location = new System.Drawing.Point(720, 170);
            this.txMedium.Name = "txMedium";
            this.txMedium.Size = new System.Drawing.Size(293, 22);
            this.txMedium.TabIndex = 18;
            // 
            // txHigh
            // 
            this.txHigh.Location = new System.Drawing.Point(720, 98);
            this.txHigh.Name = "txHigh";
            this.txHigh.Size = new System.Drawing.Size(293, 22);
            this.txHigh.TabIndex = 16;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(726, 222);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(82, 16);
            this.label30.TabIndex = 23;
            this.label30.Text = "Low Priority";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(726, 150);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(104, 16);
            this.label31.TabIndex = 24;
            this.label31.Text = "Medium Priority";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(726, 79);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(84, 16);
            this.label32.TabIndex = 25;
            this.label32.Text = "High Priority";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(720, 128);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(48, 16);
            this.label33.TabIndex = 26;
            this.label33.Text = "Value:";
            // 
            // txHighV
            // 
            this.txHighV.Location = new System.Drawing.Point(783, 125);
            this.txHighV.Name = "txHighV";
            this.txHighV.Size = new System.Drawing.Size(45, 22);
            this.txHighV.TabIndex = 17;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(720, 197);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(48, 16);
            this.label34.TabIndex = 28;
            this.label34.Text = "Value:";
            // 
            // txMediumV
            // 
            this.txMediumV.Location = new System.Drawing.Point(783, 194);
            this.txMediumV.Name = "txMediumV";
            this.txMediumV.Size = new System.Drawing.Size(45, 22);
            this.txMediumV.TabIndex = 19;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(720, 270);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(48, 16);
            this.label35.TabIndex = 30;
            this.label35.Text = "Value:";
            // 
            // txLowV
            // 
            this.txLowV.Location = new System.Drawing.Point(783, 267);
            this.txLowV.Name = "txLowV";
            this.txLowV.Size = new System.Drawing.Size(45, 22);
            this.txLowV.TabIndex = 21;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(48, 185);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(103, 16);
            this.label36.TabIndex = 32;
            this.label36.Text = "Hours Modifier:";
            // 
            // txHourMod
            // 
            this.txHourMod.Location = new System.Drawing.Point(175, 185);
            this.txHourMod.Name = "txHourMod";
            this.txHourMod.Size = new System.Drawing.Size(114, 22);
            this.txHourMod.TabIndex = 8;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(48, 308);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(181, 16);
            this.label37.TabIndex = 34;
            this.label37.Text = "Order of Shift Assignments:";
            // 
            // txPriority
            // 
            this.txPriority.Location = new System.Drawing.Point(279, 308);
            this.txPriority.Name = "txPriority";
            this.txPriority.Size = new System.Drawing.Size(734, 22);
            this.txPriority.TabIndex = 22;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(48, 213);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(95, 16);
            this.label38.TabIndex = 36;
            this.label38.Text = "Avail Modifier:";
            // 
            // txAvailMod
            // 
            this.txAvailMod.Location = new System.Drawing.Point(175, 213);
            this.txAvailMod.Name = "txAvailMod";
            this.txAvailMod.Size = new System.Drawing.Size(114, 22);
            this.txAvailMod.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(357, 16);
            this.label15.TabIndex = 37;
            this.label15.Text = "Settings are filled in after you connect to the database.";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(48, 241);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(104, 16);
            this.label42.TabIndex = 39;
            this.label42.Text = "Prefer Modifier:";
            // 
            // txPreferMod
            // 
            this.txPreferMod.Location = new System.Drawing.Point(175, 241);
            this.txPreferMod.Name = "txPreferMod";
            this.txPreferMod.Size = new System.Drawing.Size(114, 22);
            this.txPreferMod.TabIndex = 38;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.btUpdateFileLoc);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Location = new System.Drawing.Point(376, 353);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(722, 212);
            this.panel3.TabIndex = 15;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(312, 103);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 16);
            this.label20.TabIndex = 0;
            this.label20.Text = "Update";
            // 
            // btUpdateFileLoc
            // 
            this.btUpdateFileLoc.Enabled = false;
            this.btUpdateFileLoc.Location = new System.Drawing.Point(190, 124);
            this.btUpdateFileLoc.Name = "btUpdateFileLoc";
            this.btUpdateFileLoc.Size = new System.Drawing.Size(329, 23);
            this.btUpdateFileLoc.TabIndex = 23;
            this.btUpdateFileLoc.Text = "Save Settings to Database";
            this.btUpdateFileLoc.UseVisualStyleBackColor = true;
            this.btUpdateFileLoc.Click += new System.EventHandler(this.btUpdateFileLoc_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(7, 17);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(208, 16);
            this.label26.TabIndex = 15;
            this.label26.Text = "Step 3: Save As Required.\r\n";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(501, 16);
            this.label16.TabIndex = 24;
            this.label16.Text = "Saves settings to database in order to allow them to presist across machines.";
            // 
            // Config
            // 
            this.Config.Controls.Add(this.tpConfig);
            this.Config.Controls.Add(this.tpSchedule);
            this.Config.Controls.Add(this.tpPreview);
            this.Config.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Config.Location = new System.Drawing.Point(0, 24);
            this.Config.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Config.Name = "Config";
            this.Config.SelectedIndex = 0;
            this.Config.Size = new System.Drawing.Size(1425, 731);
            this.Config.TabIndex = 6;
            this.Config.SelectedIndexChanged += new System.EventHandler(this.Config_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1425, 755);
            this.Controls.Add(this.Config);
            this.Controls.Add(this.msMain);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Scheduler";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tpPreview.ResumeLayout(false);
            this.tpSchedule.ResumeLayout(false);
            this.tpSchedule.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tpConfig.ResumeLayout(false);
            this.tabConfigs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tpAvail.ResumeLayout(false);
            this.tpAvail.PerformLayout();
            this.tpSkeleton.ResumeLayout(false);
            this.tpSkeleton.PerformLayout();
            this.tpBasic.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.Config.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileExit;
        private System.Windows.Forms.ToolStripMenuItem msDBStatus;
        private System.Windows.Forms.OpenFileDialog ofdAvail;
        private System.Windows.Forms.OpenFileDialog ofdSkeleton;
        private System.Windows.Forms.OpenFileDialog ofdSave;
        private System.Windows.Forms.ToolStripMenuItem hideConflictsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mtsHideDS;
        private System.Windows.Forms.ToolStripMenuItem mtsHideOC;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmTest;
        private System.Windows.Forms.TabPage tpPreview;
        private System.Windows.Forms.WebBrowser wbPreview;
        private System.Windows.Forms.TabPage tpSchedule;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button btUndoSubmit;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.RichTextBox lstConflicts;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbUploading;
        private System.Windows.Forms.ToolStripProgressBar pbUploading;
        private System.Windows.Forms.Button btSubmit;
        private System.Windows.Forms.Button btAutoAll;
        private System.Windows.Forms.Label lbCurrent;
        private System.Windows.Forms.Label lbEmployeeCount;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lbEmployeeHeader;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label lbShiftInfo;
        private System.Windows.Forms.Label lbHoursInfo;
        private System.Windows.Forms.ListView lstAvailPreview;
        private System.Windows.Forms.ListView lstEmployees;
        private System.Windows.Forms.ListView lstShifts;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btUnassignToShift;
        private System.Windows.Forms.Button btAssignToShift;
        private System.Windows.Forms.ListView lstAssigned;
        private System.Windows.Forms.ListView lstUnassigned;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btTest2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TabPage tpConfig;
        private System.Windows.Forms.TabControl tabConfigs;
        private System.Windows.Forms.TabPage tpBasic;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btUpdateFileLoc;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txPreferMod;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txAvailMod;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txPriority;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txHourMod;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txLowV;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txMediumV;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txHighV;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txHigh;
        private System.Windows.Forms.TextBox txMedium;
        private System.Windows.Forms.TextBox txLow;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txSweet;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txMinHours;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txMaxHours;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btSaveLoc;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btSkeletonLoc;
        private System.Windows.Forms.Button btAvailLoc;
        private System.Windows.Forms.TextBox txSaveLoc;
        private System.Windows.Forms.TextBox txSkeletonLoc;
        private System.Windows.Forms.TextBox txAvailLoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btTestConnection;
        private System.Windows.Forms.TextBox txDBName;
        private System.Windows.Forms.CheckBox cbBlankIt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txDBHostName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txDBUsername;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txDBPass;
        private System.Windows.Forms.TabPage tpSkeleton;
        private System.Windows.Forms.Button btSkeletonReload;
        private System.Windows.Forms.Button btSkeletonClear;
        private System.Windows.Forms.Button btSkeletonSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtbSkeleton;
        private System.Windows.Forms.TabPage tpAvail;
        private System.Windows.Forms.Button btAvailReload;
        private System.Windows.Forms.Button btAvailClear;
        private System.Windows.Forms.Button btAvailSave;
        private System.Windows.Forms.Button btDownloadFresh;
        private System.Windows.Forms.RichTextBox rtbAvail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox rtbHoursExceptions;
        private System.Windows.Forms.TabControl Config;
    }
}

