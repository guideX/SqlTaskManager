namespace SqlTaskManager;

partial class frmMain {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
        tabControl1 = new TabControl();
        tabPage1 = new TabPage();
        splitContainer1 = new SplitContainer();
        lvwProcesses = new ListView();
        lblError = new Label();
        cmdKill = new Button();
        tabPage2 = new TabPage();
        lvwBigTables = new ListView();
        tabPage3 = new TabPage();
        mnuFile = new MenuStrip();
        toolStripMenuItem1 = new ToolStripMenuItem();
        settingsToolStripMenuItem = new ToolStripMenuItem();
        tmrRefresh = new System.Windows.Forms.Timer(components);
        tmrBigTablesRefresh = new System.Windows.Forms.Timer(components);
        label1 = new Label();
        lblCPU = new Label();
        tmrPerformance = new System.Windows.Forms.Timer(components);
        tabControl1.SuspendLayout();
        tabPage1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        tabPage2.SuspendLayout();
        tabPage3.SuspendLayout();
        mnuFile.SuspendLayout();
        SuspendLayout();
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabPage1);
        tabControl1.Controls.Add(tabPage2);
        tabControl1.Controls.Add(tabPage3);
        tabControl1.Dock = DockStyle.Fill;
        tabControl1.Location = new Point(0, 24);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(781, 677);
        tabControl1.TabIndex = 0;
        // 
        // tabPage1
        // 
        tabPage1.Controls.Add(splitContainer1);
        tabPage1.Location = new Point(4, 24);
        tabPage1.Name = "tabPage1";
        tabPage1.Padding = new Padding(3);
        tabPage1.Size = new Size(773, 649);
        tabPage1.TabIndex = 0;
        tabPage1.Text = "Processes";
        tabPage1.UseVisualStyleBackColor = true;
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Location = new Point(3, 3);
        splitContainer1.Name = "splitContainer1";
        splitContainer1.Orientation = Orientation.Horizontal;
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.AutoScroll = true;
        splitContainer1.Panel1.Controls.Add(lvwProcesses);
        splitContainer1.Panel1MinSize = 300;
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(lblError);
        splitContainer1.Panel2.Controls.Add(cmdKill);
        splitContainer1.Size = new Size(767, 643);
        splitContainer1.SplitterDistance = 578;
        splitContainer1.TabIndex = 0;
        // 
        // lvwProcesses
        // 
        lvwProcesses.AutoArrange = false;
        lvwProcesses.BackColor = Color.White;
        lvwProcesses.BorderStyle = BorderStyle.None;
        lvwProcesses.Dock = DockStyle.Fill;
        lvwProcesses.FullRowSelect = true;
        lvwProcesses.Location = new Point(0, 0);
        lvwProcesses.Name = "lvwProcesses";
        lvwProcesses.Size = new Size(767, 578);
        lvwProcesses.TabIndex = 0;
        lvwProcesses.UseCompatibleStateImageBehavior = false;
        lvwProcesses.View = View.Details;
        // 
        // lblError
        // 
        lblError.AutoSize = true;
        lblError.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        lblError.ForeColor = Color.Red;
        lblError.Location = new Point(132, 18);
        lblError.Name = "lblError";
        lblError.Size = new Size(0, 15);
        lblError.TabIndex = 1;
        // 
        // cmdKill
        // 
        cmdKill.Dock = DockStyle.Right;
        cmdKill.Location = new Point(647, 0);
        cmdKill.Name = "cmdKill";
        cmdKill.Size = new Size(120, 61);
        cmdKill.TabIndex = 0;
        cmdKill.Text = "End Process Now";
        cmdKill.UseVisualStyleBackColor = true;
        cmdKill.Click += cmdKill_Click;
        // 
        // tabPage2
        // 
        tabPage2.Controls.Add(lvwBigTables);
        tabPage2.Location = new Point(4, 24);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new Padding(3);
        tabPage2.Size = new Size(773, 649);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "Big Tables";
        tabPage2.UseVisualStyleBackColor = true;
        // 
        // lvwBigTables
        // 
        lvwBigTables.BorderStyle = BorderStyle.None;
        lvwBigTables.Dock = DockStyle.Fill;
        lvwBigTables.Location = new Point(3, 3);
        lvwBigTables.Name = "lvwBigTables";
        lvwBigTables.Size = new Size(767, 643);
        lvwBigTables.TabIndex = 0;
        lvwBigTables.UseCompatibleStateImageBehavior = false;
        lvwBigTables.View = View.Details;
        // 
        // tabPage3
        // 
        tabPage3.Controls.Add(lblCPU);
        tabPage3.Controls.Add(label1);
        tabPage3.Location = new Point(4, 24);
        tabPage3.Name = "tabPage3";
        tabPage3.Padding = new Padding(3);
        tabPage3.Size = new Size(773, 649);
        tabPage3.TabIndex = 2;
        tabPage3.Text = "Performance";
        tabPage3.UseVisualStyleBackColor = true;
        // 
        // mnuFile
        // 
        mnuFile.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
        mnuFile.Location = new Point(0, 0);
        mnuFile.Name = "mnuFile";
        mnuFile.Size = new Size(781, 24);
        mnuFile.TabIndex = 1;
        mnuFile.Text = "menuStrip1";
        // 
        // toolStripMenuItem1
        // 
        toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
        toolStripMenuItem1.Name = "toolStripMenuItem1";
        toolStripMenuItem1.Size = new Size(37, 20);
        toolStripMenuItem1.Text = "&File";
        // 
        // settingsToolStripMenuItem
        // 
        settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
        settingsToolStripMenuItem.Size = new Size(116, 22);
        settingsToolStripMenuItem.Text = "&Settings";
        settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
        // 
        // tmrRefresh
        // 
        tmrRefresh.Interval = 1500;
        tmrRefresh.Tick += tmrRefresh_Tick;
        // 
        // tmrBigTablesRefresh
        // 
        tmrBigTablesRefresh.Interval = 60000;
        tmrBigTablesRefresh.Tick += tmrBigTablesRefresh_Tick;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
        label1.Location = new Point(8, 23);
        label1.Name = "label1";
        label1.Size = new Size(48, 25);
        label1.TabIndex = 0;
        label1.Text = "CPU";
        // 
        // lblCPU
        // 
        lblCPU.AutoSize = true;
        lblCPU.Location = new Point(8, 48);
        lblCPU.Name = "lblCPU";
        lblCPU.Size = new Size(38, 15);
        lblCPU.TabIndex = 1;
        lblCPU.Text = "(CPU)";
        // 
        // tmrPerformance
        // 
        tmrPerformance.Tick += tmrPerformance_Tick;
        // 
        // frmMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(781, 701);
        Controls.Add(tabControl1);
        Controls.Add(mnuFile);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MainMenuStrip = mnuFile;
        MinimumSize = new Size(0, 600);
        Name = "frmMain";
        StartPosition = FormStartPosition.Manual;
        Text = "Sql Task Manager";
        Load += frmMain_Load;
        tabControl1.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        splitContainer1.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        tabPage2.ResumeLayout(false);
        tabPage3.ResumeLayout(false);
        tabPage3.PerformLayout();
        mnuFile.ResumeLayout(false);
        mnuFile.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TabControl tabControl1;
    private TabPage tabPage1;
    private SplitContainer splitContainer1;
    private ListView lvwProcesses;
    private MenuStrip mnuFile;
    private ToolStripMenuItem toolStripMenuItem1;
    private ToolStripMenuItem settingsToolStripMenuItem;
    private System.Windows.Forms.Timer tmrRefresh;
    private Button cmdKill;
    private Label lblError;
    private TabPage tabPage2;
    private ListView lvwBigTables;
    private System.Windows.Forms.Timer tmrBigTablesRefresh;
    private TabPage tabPage3;
    private Label label1;
    private Label lblCPU;
    private System.Windows.Forms.Timer tmrPerformance;
}
