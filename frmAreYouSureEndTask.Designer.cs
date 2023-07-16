namespace SqlTaskManager {
    partial class frmAreYouSureEndTask {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAreYouSureEndTask));
            cmdOK = new Button();
            cmdCancel = new Button();
            lblAreYouSure = new Label();
            lstTasks = new ListBox();
            SuspendLayout();
            // 
            // cmdOK
            // 
            cmdOK.DialogResult = DialogResult.OK;
            cmdOK.Location = new Point(275, 96);
            cmdOK.Name = "cmdOK";
            cmdOK.Size = new Size(86, 28);
            cmdOK.TabIndex = 0;
            cmdOK.Text = "OK";
            cmdOK.UseVisualStyleBackColor = true;
            cmdOK.Click += cmdOK_Click;
            // 
            // cmdCancel
            // 
            cmdCancel.DialogResult = DialogResult.Cancel;
            cmdCancel.Location = new Point(367, 96);
            cmdCancel.Name = "cmdCancel";
            cmdCancel.Size = new Size(86, 28);
            cmdCancel.TabIndex = 1;
            cmdCancel.Text = "Cancel";
            cmdCancel.UseVisualStyleBackColor = true;
            cmdCancel.Click += cmdCancel_Click;
            // 
            // lblAreYouSure
            // 
            lblAreYouSure.AutoSize = true;
            lblAreYouSure.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblAreYouSure.Location = new Point(10, 8);
            lblAreYouSure.Name = "lblAreYouSure";
            lblAreYouSure.Size = new Size(226, 15);
            lblAreYouSure.TabIndex = 2;
            lblAreYouSure.Text = "Are you sure you wish to kill the task(s):";
            // 
            // lstTasks
            // 
            lstTasks.BorderStyle = BorderStyle.None;
            lstTasks.FormattingEnabled = true;
            lstTasks.ItemHeight = 15;
            lstTasks.Location = new Point(13, 26);
            lstTasks.Name = "lstTasks";
            lstTasks.Size = new Size(440, 60);
            lstTasks.TabIndex = 3;
            // 
            // frmAreYouSureEndTask
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 136);
            Controls.Add(lstTasks);
            Controls.Add(lblAreYouSure);
            Controls.Add(cmdCancel);
            Controls.Add(cmdOK);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAreYouSureEndTask";
            Text = "Confirmation - Sql Task Manager";
            Load += frmAreYouSureEndTask_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cmdOK;
        private Button cmdCancel;
        private Label lblAreYouSure;
        private ListBox lstTasks;
    }
}