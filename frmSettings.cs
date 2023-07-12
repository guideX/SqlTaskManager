namespace SqlTaskManager {
    /// <summary>
    /// Settings Form
    /// </summary>
    public partial class frmSettings : Form {
        /// <summary>
        /// Settings Ini File
        /// </summary>
        private string _settingsIniFile = Application.StartupPath + @"\settings.ini";
        /// <summary>
        /// Constructor
        /// </summary>
        public frmSettings() {
            InitializeComponent();
        }
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSettings_Load(object sender, EventArgs e) {
            txtConnectionString.KeyPress += txtConnectionString_KeyPress;
            txtConnectionString.Text = IniFileHelper.ReadIni(_settingsIniFile, "Settings", "ConnectionString", "");
            this.FormClosing += frmSettings_FormClosing;
        }
        /// <summary>
        /// Form Closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSettings_FormClosing(object? sender, FormClosingEventArgs e) {
            IniFileHelper.WriteIni(_settingsIniFile, "Settings", "ConnectionString", txtConnectionString.Text);
        }
        /// <summary>
        /// Connection String KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtConnectionString_KeyPress(object? sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13 || e.KeyChar == (char)10) {
                this.Close();
            }
        }
    }
}