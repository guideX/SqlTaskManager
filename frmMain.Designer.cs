﻿namespace SqlTaskManager;

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
        tabControl1 = new TabControl();
        tabPage1 = new TabPage();
        splitContainer1 = new SplitContainer();
        lvwProcesses = new ListView();
        lblError = new Label();
        cmdKill = new Button();
        mnuFile = new MenuStrip();
        toolStripMenuItem1 = new ToolStripMenuItem();
        settingsToolStripMenuItem = new ToolStripMenuItem();
        tmrRefresh = new System.Windows.Forms.Timer(components);
        tabControl1.SuspendLayout();
        tabPage1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        mnuFile.SuspendLayout();
        SuspendLayout();
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabPage1);
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
        cmdKill.Location = new Point(5, 12);
        cmdKill.Name = "cmdKill";
        cmdKill.Size = new Size(120, 31);
        cmdKill.TabIndex = 0;
        cmdKill.Text = "End Process Now";
        cmdKill.UseVisualStyleBackColor = true;
        cmdKill.Click += cmdKill_Click;
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
        tmrRefresh.Enabled = true;
        tmrRefresh.Interval = 500;
        tmrRefresh.Tick += tmrRefresh_Tick;
        // 
        // frmMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(781, 701);
        Controls.Add(tabControl1);
        Controls.Add(mnuFile);
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
}
