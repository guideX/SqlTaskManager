namespace SqlTaskManager;
using PetaPoco;
using PetaPoco.Providers;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;
public partial class frmMain : Form {
    /// <summary>
    /// Settings Ini File
    /// </summary>
    private string _settingsIniFile = Application.StartupPath + @"\settings.ini";
    /// <summary>
    /// Constructor
    /// </summary>
    public frmMain() {
        InitializeComponent();
        try {
            this.FormClosed += frmMain_FormClosed;
            if (lblError.Text != "") lblError.Text = "";
            lvwProcesses.Columns.Add("SPID", IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "SPIDWidth", 100));
            lvwProcesses.Columns.Add("Status", IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "StatusWidth", 100));
            lvwProcesses.Columns.Add("Login", IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "LoginWidth", 100));
            lvwProcesses.Columns.Add("HostName", IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "HostNameWidth", 100));
            lvwProcesses.Columns.Add("BlkBy", IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "BlkByWidth", 100));
            lvwProcesses.Columns.Add("DBName", IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "DBNameWidth", 100));
            lvwProcesses.Columns.Add("Command", IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "CommandWidth", 100));
            lvwProcesses.Columns.Add("CpuTime", IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "CpuTimeWidth", 100));
            lvwProcesses.Columns.Add("DiskIO", IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "DiskIOWidth", 100));
            lvwProcesses.Columns.Add("LastBatch", IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "LastBatchWidth", 100));
            lvwProcesses.Columns.Add("ProgramName", IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "ProgramNameWidth", 100));
            lvwProcesses.Columns.Add("SPID2", IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "SPID2Width", 100));
            lvwProcesses.Columns.Add("RequestID", IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "RequestIDWidth", 100));
            this.Left = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "MainLeft", 0);
            this.Top = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "MainTop", 0);
            IniFileHelper.WriteIni(_settingsIniFile, "Settings", "MainY", this.Location.Y.ToString());
            lvwProcesses.SetDoubleBuffered();
        } catch (Exception ex) {
            lblError.Text = ex.Message;
        }
    }
    /// <summary>
    /// Form Closed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void frmMain_FormClosed(object? sender, FormClosedEventArgs e) {
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "SPIDWidth", lvwProcesses.Columns[0].Width.ToString());
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "StatusWidth", lvwProcesses.Columns[1].Width.ToString());
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "LoginWidth", lvwProcesses.Columns[2].Width.ToString());
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "HostNameWidth", lvwProcesses.Columns[3].Width.ToString());
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "BlkByWidth", lvwProcesses.Columns[4].Width.ToString());
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "DBNameWidth", lvwProcesses.Columns[5].Width.ToString());
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "CommandWidth", lvwProcesses.Columns[6].Width.ToString());
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "CpuTimeWidth", lvwProcesses.Columns[7].Width.ToString());
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "DiskIOWidth", lvwProcesses.Columns[8].Width.ToString());
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "LastBatchWidth", lvwProcesses.Columns[9].Width.ToString());
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "ProgramNameWidth", lvwProcesses.Columns[10].Width.ToString());
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "SPID2Width", lvwProcesses.Columns[11].Width.ToString());
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "RequestIDWidth", lvwProcesses.Columns[12].Width.ToString());
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "MainWidth", this.ClientSize.Width.ToString());
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "MainHeight", this.ClientSize.Height.ToString());
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "MainX", this.Location.X.ToString());
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "MainY", this.Location.Y.ToString());
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "MainLeft", this.Left.ToString());
        IniFileHelper.WriteIni(_settingsIniFile, "Settings", "MainTop", this.Top.ToString());
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
            lblError.Text = ex.Message;
        }
    }
    /// <summary>
    /// Get Db
    /// </summary>
    /// <returns></returns>
    private IDatabase? GetDb() {
        try {
            if (lblError.Text != "") lblError.Text = "";
            var connectionString = IniFileHelper.ReadIni(_settingsIniFile, "Settings", "ConnectionString", "");
            if (!string.IsNullOrEmpty(connectionString)) {
                return DatabaseConfiguration.Build()
                    .WithoutAutoSelect()
                    .UsingProvider<SqlServerDatabaseProvider>()
                    .UsingConnectionString(connectionString)
                    .Create();
            } else {
                return null;
            }
        } catch (Exception ex) {
            lblError.Text = ex.Message;
            return null;
        }
    }
    /// <summary>
    /// Refresh List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tmrRefresh_Tick(object sender, EventArgs e) {
        try {
            if (lblError.Text != "") lblError.Text = "";
            List<SpWho2Model> spWho2 = new List<SpWho2Model>();
            using (var db = GetDb()) {
                if (db != null) spWho2 = db.Fetch<SpWho2Model>("EXEC [dbo].[SP_WHO2];").ToList();
            }
            if (spWho2.Any()) {
                var spids = new List<string>();
                lvwProcesses.BeginUpdate();
                try {
                    foreach (var item in spWho2) {
                        var findItem = lvwProcesses.FindItemWithText(item.SPID);
                        var lvsi = new List<ListViewSubItem>();
                        lvsi.Add(new ListViewSubItem() { Text = item.SPID });
                        lvsi.Add(new ListViewSubItem() { Text = item.Status });
                        lvsi.Add(new ListViewSubItem() { Text = item.Login });
                        lvsi.Add(new ListViewSubItem() { Text = item.HostName });
                        lvsi.Add(new ListViewSubItem() { Text = item.BlkBy, ForeColor = Color.Red });
                        lvsi.Add(new ListViewSubItem() { Text = item.DBName });
                        lvsi.Add(new ListViewSubItem() { Text = item.Command });
                        lvsi.Add(new ListViewSubItem() { Text = item.CpuTime });
                        lvsi.Add(new ListViewSubItem() { Text = item.DiskIO });
                        lvsi.Add(new ListViewSubItem() { Text = item.LastBatch });
                        lvsi.Add(new ListViewSubItem() { Text = item.ProgramName });
                        lvsi.Add(new ListViewSubItem() { Text = item.SPID2 });
                        lvsi.Add(new ListViewSubItem() { Text = item.RequestID });
                        if (findItem != null) {
                            spids.Add(item.SPID);
                            for (int i = 0; i < findItem.SubItems.Count; i++) {
                                if (findItem.SubItems[i].Text != lvsi[i].Text) findItem.SubItems[i].Text = lvsi[i].Text;
                            }
                        } else {
                            var listViewItem = new ListViewItem(lvsi.ToArray(), 0);
                            var newItem = lvwProcesses.Items.Add(listViewItem);
                            spids.Add(item.SPID);
                        }
                    }
                    var itemsToRemove = new List<ListViewItem>();
                    foreach (var listItem in lvwProcesses.Items) {
                        if (!spids.Contains(((ListViewItem)listItem).Text)) {
                            itemsToRemove.Add((ListViewItem)listItem);
                        }
                    }
                    foreach (var item in itemsToRemove) {
                        lvwProcesses.Items.Remove(item);
                    }
                } finally {
                    lvwProcesses.EndUpdate();
                }
            }
        } catch (Exception ex) {
            lblError.Text = ex.Message;
            if (lvwProcesses.Items.Count != 0) lvwProcesses.Clear();
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
            using (var db = GetDb()) {
                if (db != null) {
                    foreach (var item in lvwProcesses.SelectedItems) {
                        db.Execute("KILL " + ((ListViewItem)item).Text);
                    }
                }
            }
        } catch (Exception ex) {
            lblError.Text = ex.Message;
        }
    }
    /// <summary>
    /// Load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void frmMain_Load(object sender, EventArgs e) {
    }
}