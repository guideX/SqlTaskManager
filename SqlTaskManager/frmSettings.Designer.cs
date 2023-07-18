namespace SqlTaskManager {
    partial class frmSettings {
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
            label1 = new Label();
            txtConnectionString = new TextBox();
            txtRefreshInterval = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 0;
            label1.Text = "Connection String:";
            // 
            // txtConnectionString
            // 
            txtConnectionString.AcceptsReturn = true;
            txtConnectionString.Location = new Point(12, 27);
            txtConnectionString.Name = "txtConnectionString";
            txtConnectionString.Size = new Size(324, 23);
            txtConnectionString.TabIndex = 1;
            // 
            // txtRefreshInterval
            // 
            txtRefreshInterval.AcceptsReturn = true;
            txtRefreshInterval.Location = new Point(12, 80);
            txtRefreshInterval.Name = "txtRefreshInterval";
            txtRefreshInterval.Size = new Size(324, 23);
            txtRefreshInterval.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 2;
            label2.Text = "Refresh Interval:";
            // 
            // frmSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 121);
            Controls.Add(txtRefreshInterval);
            Controls.Add(label2);
            Controls.Add(txtConnectionString);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmSettings";
            Text = "Sql Task Manager - Settings";
            Load += frmSettings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtConnectionString;
        private TextBox txtRefreshInterval;
        private Label label2;
    }
}