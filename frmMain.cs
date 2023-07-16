namespace SqlTaskManager;
using System.Linq;
using PetaPoco;
using PetaPoco.Providers;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;
public partial class frmMain : Form {
    #region "private variables"
    /// <summary>
    /// Order By Column
    /// </summary>
    private string _orderByColumn = "[SPID]";
    /// <summary>
    /// Settings Ini File
    /// </summary>
    private string _settingsIniFile = Application.StartupPath + @"\settings.ini";
    /// <summary>
    /// Current Column Sort
    /// </summary>
    private int _currentColumnSort = 0;
    /// <summary>
    /// Direction
    /// </summary>
    private int _currentColumnSortDirection = 0;
    #endregion
    #region "public methods"
    /// <summary>
    /// Constructor
    /// </summary>
    public frmMain() {
        InitializeComponent();
        try {
            this.FormClosed += frmMain_FormClosed;
            lvwProcesses.ColumnClick += lvwProcesses_ColumnClick;
            if (lblError.Text != "") lblError.Text = "";
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "SPID", Tag = "Numeric", Width = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "SPIDWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Status", Tag = "Text", Width = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "StatusWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Login", Tag = "Text", Width = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "LoginWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Host Name", Tag = "Text", Width = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "HostNameWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Block By", Tag = "Text", Width = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "BlkByWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Database Name Width", Tag = "Text", Width = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "DbNameWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Command", Tag = "Text", Width = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "CommandWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Cpu Time", Tag = "Numeric", Width = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "CpuTimeWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Disk IO", Tag = "Numeric", Width = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "DiskIOWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Last Batch", Tag = "Text", Width = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "LastBatchWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Program Name", Tag = "Text", Width = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "ProgramNameWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "SPID2", Tag = "Numeric", Width = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "SPID2Width", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "RequestID", Tag = "Numeric", Width = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "RequestIDWidth", 100) });
            lvwProcesses.SetDoubleBuffered();
            lvwProcesses.ListViewItemSorter = new ListViewSorter();
            lvwBigTables.Columns.Add(new ColumnHeader() { Text = "Table", Tag = "Text", Width = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "TableWidth", 100) });
            lvwBigTables.Columns.Add(new ColumnHeader() { Text = "Used MB", Tag = "Text", Width = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "UsedMBWidth", 100) });
            lvwBigTables.Columns.Add(new ColumnHeader() { Text = "Allocated MB", Tag = "Text", Width = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "AllocatedMBWidth", 100) });
            lvwBigTables.SetDoubleBuffered();
            //lvwBigTables.ListViewItemSorter = new ListViewSorter();
            this.Left = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "MainLeft", 0);
            this.Top = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "MainTop", 0);
            this.Width = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "MainWidth", 300);
            this.Height = IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "MainHeight", 600);
        } catch (Exception ex) {
            lblError.Text = ex.Message;
        }
    }
    /// <summary>
    /// Show Error
    /// </summary>
    /// <param name="errorMessage"></param>
    public void ShowError(string errorMessage) {
        lblError.Text = errorMessage;
    }
    #endregion
    #region "private methods"
    /// <summary>
    /// Process Column Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void lvwProcesses_ColumnClick(object? sender, ColumnClickEventArgs e) {
        tmrRefresh.Enabled = false;
        if (_currentColumnSort != e.Column) {
            _currentColumnSort = e.Column;
            _currentColumnSortDirection = 0;
        } else {
            if (_currentColumnSortDirection == 0) {
                _currentColumnSortDirection = 1;
            } else {
                _currentColumnSortDirection = 0;
            }
        }
        switch (_currentColumnSort + 1) {
            case 1:
                _orderByColumn = "[SPID]";
                break;
            case 2:
                _orderByColumn = "[Status]";
                break;
            case 3:
                _orderByColumn = "[Login]";
                break;
            case 4:
                _orderByColumn = "[HostName]";
                break;
            case 5:
                _orderByColumn = "[BlkBy]";
                break;
            case 6:
                _orderByColumn = "[DBName]";
                break;
            case 7:
                _orderByColumn = "[Command]";
                break;
            case 8:
                _orderByColumn = "[CpuTime]";
                break;
            case 9:
                _orderByColumn = "[DiskIO]";
                break;
            case 10:
                _orderByColumn = "[LastBatch]";
                break;
            case 11:
                _orderByColumn = "[ProgramName]";
                break;
            case 12:
                _orderByColumn = "[SPID2]";
                break;
            case 13:
                _orderByColumn = "[RequestID]";
                break;
        }
        lvwProcesses.Items.Clear();
        lvwProcesses.Tag = _currentColumnSort.ToString();
        UpdateNow();
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
    private IDatabase GetDb() {
        if (lblError.Text != "") lblError.Text = "";
        var connectionString = IniFileHelper.ReadIni(_settingsIniFile, "Settings", "ConnectionString", "");
        return DatabaseConfiguration.Build()
            .WithoutAutoSelect()
            .UsingProvider<SqlServerDatabaseProvider>()
            .UsingConnectionString(connectionString)
            .Create();
    }
    /// <summary>
    /// Update Big Tables
    /// </summary>
    private void UpdateBigTables() {
        try {
            using (var db = GetDb()) {
                if (db != null) {
                    var sql = @"
SELECT TOP 100 schema_name(tab.schema_id) + '.' + tab.name as [table], 
	cast(sum(spc.used_pages * 8)/1024.00 as numeric(36, 2)) as used_mb,
    cast(sum(spc.total_pages * 8)/1024.00 as numeric(36, 2)) as allocated_mb
from sys.tables tab
join sys.indexes ind 
     on tab.object_id = ind.object_id
join sys.partitions part 
     on ind.object_id = part.object_id and ind.index_id = part.index_id
join sys.allocation_units spc
     on part.partition_id = spc.container_id
group by schema_name(tab.schema_id) + '.' + tab.name
order by sum(spc.used_pages) desc;
";
                    var bigTables = db.Fetch<LargeTableModel>(sql).ToList();
                    if (bigTables != null && bigTables.Any()) {
                        lvwBigTables.BeginUpdate();
                        try {
                            var selectedItems = new List<string>();
                            foreach (var item in lvwBigTables.SelectedItems) {
                                selectedItems.Add(((ListViewItem)item).Text);
                            }
                            lvwBigTables.Items.Clear();
                            foreach (var bigTable in bigTables) {
                                var subItems = new List<ListViewSubItem>();
                                subItems.Add(new ListViewSubItem() { Name = "Table", Text = bigTable.table });
                                subItems.Add(new ListViewSubItem() { Name = "Used MB", Text = bigTable.used_mb });
                                subItems.Add(new ListViewSubItem() { Name = "Allocated MB", Text = bigTable.allocated_mb });
                                var listViewItem = new ListViewItem(subItems.ToArray(), 0);
                                if (selectedItems.Contains(listViewItem.Text)) listViewItem.Selected = true;
                                lvwBigTables.Items.Add(listViewItem);
                            }
                        } finally {
                            lvwBigTables.EndUpdate();
                        }
                    }
                }
            }
        } catch (Exception ex) {
            lblError.Text = ex.Message;
        }
    }
    /// <summary>
    /// Update Now
    /// </summary>
    private void UpdateNow() {
        try {
            if (lblError.Text != "") lblError.Text = "";
            List<SpWho2Model> spWho2 = new List<SpWho2Model>();
            var orderBy = "";
            orderBy = "ORDER BY " + _orderByColumn + " " + (_currentColumnSortDirection == 0 ? "ASC" : "DESC");
            var sql = @"
                IF (OBJECT_ID('tempdb..#spWho2Temp790') IS NOT NULL) BEGIN DROP TABLE #spWho2Temp790 END
                CREATE TABLE #spWho2Temp790 (
	                [SPID] INT NULL,
	                [Status] VARCHAR(200) NULL,
	                [Login] VARCHAR(200) NULL,
	                [HostName] VARCHAR(200) NULL,
	                [BlkBy] VARCHAR(200) NULL,
	                [DBName] VARCHAR(200) NULL,
	                [Command] VARCHAR(200) NULL,
	                [CpuTime] INT NULL,
	                [DiskIO] INT NULL,
	                [LastBatch] VARCHAR(200) NULL,
	                [ProgramName] VARCHAR(200) NULL,
	                [SPID2] INT NULL,
	                [RequestID] INT NULL
                );
                INSERT INTO #spWho2Temp790
                EXEC [dbo].[SP_WHO2];
                SELECT
	                *
                FROM
	                #spWho2Temp790
	            " + orderBy + @";
                IF (OBJECT_ID('tempdb..#spWho2Temp790') IS NOT NULL) BEGIN DROP TABLE #spWho2Temp790 END;";
            using (var db = GetDb()) spWho2 = db.Fetch<SpWho2Model>(sql).ToList();

            if (spWho2.Any()) {
                var spids = new List<string>();
                var topItemIndex = lvwProcesses.TopItem != null ? (int?)lvwProcesses.TopItem.Index : null;
                lvwProcesses.BeginUpdate();
                try {
                    var selectedText = new List<string>();
                    foreach (var item in lvwProcesses.SelectedItems) {
                        selectedText.Add(((ListViewItem)item).Text);
                    }
                    lvwProcesses.Items.Clear();
                    foreach (var item in spWho2) {
                        var lvsi = new List<ListViewSubItem>();
                        lvsi.Add(new ListViewSubItem() { Text = item.SPID.ToString(), Tag = "Numeric" });
                        lvsi.Add(new ListViewSubItem() { Text = item.Status, Tag = "Text" });
                        lvsi.Add(new ListViewSubItem() { Text = item.Login, Tag = "Text" });
                        lvsi.Add(new ListViewSubItem() { Text = item.HostName, Tag = "Text" });
                        lvsi.Add(new ListViewSubItem() { Text = item.BlkBy, Tag = "Text" });
                        lvsi.Add(new ListViewSubItem() { Text = item.DBName, Tag = "Text" });
                        lvsi.Add(new ListViewSubItem() { Text = item.Command, Tag = "Text" });
                        lvsi.Add(new ListViewSubItem() { Text = item.CpuTime.ToString(), Tag = "Numeric" });
                        lvsi.Add(new ListViewSubItem() { Text = item.DiskIO.ToString(), Tag = "Numeric" });
                        lvsi.Add(new ListViewSubItem() { Text = item.LastBatch, Tag = "Text" });
                        lvsi.Add(new ListViewSubItem() { Text = item.ProgramName, Tag = "Text" });
                        lvsi.Add(new ListViewSubItem() { Text = item.SPID2.ToString(), Tag = "Numeric" });
                        lvsi.Add(new ListViewSubItem() { Text = item.RequestID.ToString(), Tag = "Numeric" });
                        var listViewItem = new ListViewItem(lvsi.ToArray(), 0);
                        if (selectedText.Contains(listViewItem.Text)) listViewItem.Selected = true;
                        var newItem = lvwProcesses.Items.Add(listViewItem);
                        spids.Add(item.SPID.ToString());
                    }
                } finally {
                    if (topItemIndex != null) lvwProcesses.TopItem = lvwProcesses.Items[topItemIndex.Value];
                    lvwProcesses.EndUpdate();
                }
            }
        } catch (Exception ex) {
            lblError.Text = ex.Message;
            if (lvwProcesses.Items.Count != 0) lvwProcesses.Clear();
        }
    }
    /// <summary>
    /// Refresh List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tmrRefresh_Tick(object sender, EventArgs e) {
        try {
            UpdateNow();
        } catch (Exception ex) {
            lblError.Text = ex.Message;
        }
    }
    /// <summary>
    /// Kill
    /// </summary>
    /// <param name="spids"></param>
    /// <returns></returns>
    public void Kill(List<int> spids) {
        try {
            using (var db = GetDb())
                if (db != null)
                    foreach (var spid in spids)
                        db.Execute("KILL " + spid.ToString() + ";");
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
            f.ShowDialog();
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
            UpdateNow();
            UpdateBigTables();
            tmrRefresh.Interval = Convert.ToInt32(IniFileHelper.ReadIniInt(_settingsIniFile, "Settings", "TimerInterval", 1500));
            tmrBigTablesRefresh.Interval = tmrRefresh.Interval;
            tmrRefresh.Enabled = true;
            tmrBigTablesRefresh.Enabled = true;
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
        UpdateBigTables();
    }
    #endregion
}