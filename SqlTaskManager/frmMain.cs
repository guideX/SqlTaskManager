namespace SqlTaskManager;
using System.Windows.Forms;
using SqlTaskManager.Business.Business;
using SqlTaskManager.Business.Helpers;
public partial class frmMain : Form {
    #region "private variables"
    /// <summary>
    /// Main Business
    /// </summary>
    public MainBusiness MainBusiness;
    #endregion
    #region "public methods"
    /// <summary>
    /// Constructor
    /// </summary>
    public frmMain() {
        InitializeComponent();
        MainBusiness = new MainBusiness(lvwProcesses, lvwBigTables, this);
        try {
            this.FormClosed += frmMain_FormClosed;
            lvwProcesses.ColumnClick += lvwProcesses_ColumnClick;
            if (lblError.Text != "") lblError.Text = "";
        } catch (Exception ex) {
            ShowError(ex.Message);
        }
    }
    /// <summary>
    /// Show Error
    /// </summary>
    /// <param name="errorMessage"></param>
    public void ShowError(string errorMessage) {
        lblError.Text = errorMessage;
    }
    /// <summary>
    /// Kill
    /// </summary>
    /// <param name="spids"></param>
    public void Kill(List<int> spids) {
        MainBusiness.Kill(spids);
    }
    #endregion
    #region "private methods"
    /// <summary>
    /// Process Column Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void lvwProcesses_ColumnClick(object? sender, ColumnClickEventArgs e) {
        try {
            tmrRefresh.Enabled = false;
            MainBusiness.lvwProcesses_ColumnClick(lvwProcesses, e);
        } catch (Exception ex) {
            ShowError(ex.Message);
        }
    }
    /// <summary>
    /// Form Closed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void frmMain_FormClosed(object? sender, FormClosedEventArgs e) {
        try {
            MainBusiness.FormClosed(lvwProcesses, this);
        } catch (Exception ex) {
            ShowError(ex.Message);
        }
    }
    /// <summary>
    /// Click Settings
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
        try {
            if (lblError.Text != "") lblError.Text = "";
            var frm = new frmSettings();
            frm.ShowDialog();
        } catch (Exception ex) {
            ShowError(ex.Message);
        }
    }
    /// <summary>
    /// Refresh List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tmrRefresh_Tick(object sender, EventArgs e) {
        try {
            MainBusiness.UpdateNow(lvwProcesses);
        } catch (Exception ex) {
            ShowError(ex.Message);
        }
    }
    /// <summary>
    /// Kill
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void cmdKill_Click(object sender, EventArgs e) {
        try {
            if (lblError.Text != "") lblError.Text = "";
            var f = new frmAreYouSureEndTask(lvwProcesses.SelectedItems, this);
            f.ShowDialog(this);
        } catch (Exception ex) {
            ShowError(ex.Message);
        }
    }
    /// <summary>
    /// Load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void frmMain_Load(object sender, EventArgs e) {
        try {
            MainBusiness.UpdateNow(lvwProcesses);
            MainBusiness.UpdateBigTables(lvwBigTables);
            if (MainBusiness != null) tmrRefresh.Interval = Convert.ToInt32(IniFileHelper.ReadIniInt(MainBusiness.SettingsIniFile, "Settings", "TimerInterval", 1500));
            tmrRefresh.Enabled = true;
            tmrBigTablesRefresh.Interval = tmrRefresh.Interval;
            tmrBigTablesRefresh.Enabled = true;
            tmrPerformance.Interval = tmrRefresh.Interval;
            tmrPerformance.Enabled = true;
        } catch (Exception ex) {
            ShowError(ex.Message);
        }
    }
    /// <summary>
    /// Big Tables Refresh
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tmrBigTablesRefresh_Tick(object sender, EventArgs e) {
        try {
            MainBusiness.UpdateBigTables(lvwBigTables);
        } catch (Exception ex) {
            ShowError(ex.Message);
        }
    }
    /// <summary>
    /// Performance
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tmrPerformance_Tick(object sender, EventArgs e) {
        try {
            UpdatePerformance();
        } catch(Exception ex) {
            ShowError(ex.Message);
        }
    }
    private void UpdatePerformance() {
        var pc = PerformanceCounterHelper.GetCpu("LEON_DT");
        if (pc != null) lblCPU.Text = pc.Value.ToString();
    }
    #endregion
}