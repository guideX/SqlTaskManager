using static System.Windows.Forms.ListViewItem;
using SqlTaskManager.Business.Extensions;
using System.Windows.Forms;
using SqlTaskManager.Models;
using System.Diagnostics;

namespace SqlTaskManager.Business.Business {
    /// <summary>
    /// Main Business
    /// </summary>
    public class MainBusiness : BusinessExtensions {
        /// <summary>
        /// Order By Column
        /// </summary>
        private string _orderByColumn = "[SPID]";
        /// <summary>
        /// Current Column Sort
        /// </summary>
        private int _currentColumnSort = 0;
        /// <summary>
        /// Direction
        /// </summary>
        private int _currentColumnSortDirection = 0;
        /// <summary>
        /// Main Business
        /// </summary>
        public MainBusiness(ListView lvwProcesses, ListView lvwBigTables, Form frm) : base(Application.StartupPath) {
            SettingsIniFile = Application.StartupPath + @"\settings.ini";
            //lvwBigTables.ListViewItemSorter = new ListViewSorter();
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "SPID", Tag = "Numeric", Width = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "SPIDWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Status", Tag = "Text", Width = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "StatusWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Login", Tag = "Text", Width = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "LoginWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Host Name", Tag = "Text", Width = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "HostNameWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Block By", Tag = "Text", Width = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "BlkByWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Database Name Width", Tag = "Text", Width = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "DbNameWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Command", Tag = "Text", Width = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "CommandWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Cpu Time", Tag = "Numeric", Width = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "CpuTimeWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Disk IO", Tag = "Numeric", Width = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "DiskIOWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Last Batch", Tag = "Text", Width = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "LastBatchWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "Program Name", Tag = "Text", Width = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "ProgramNameWidth", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "SPID2", Tag = "Numeric", Width = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "SPID2Width", 100) });
            lvwProcesses.Columns.Add(new ColumnHeader() { Text = "RequestID", Tag = "Numeric", Width = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "RequestIDWidth", 100) });
            lvwProcesses.SetDoubleBuffered();
            lvwProcesses.ListViewItemSorter = new ListViewSorter();
            lvwBigTables.Columns.Add(new ColumnHeader() { Text = "Table", Tag = "Text", Width = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "TableWidth", 100) });
            lvwBigTables.Columns.Add(new ColumnHeader() { Text = "Used MB", Tag = "Text", Width = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "UsedMBWidth", 100) });
            lvwBigTables.Columns.Add(new ColumnHeader() { Text = "Allocated MB", Tag = "Text", Width = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "AllocatedMBWidth", 100) });
            lvwBigTables.SetDoubleBuffered();
            frm.Left = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "MainLeft", 0);
            frm.Top = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "MainTop", 0);
            frm.Width = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "MainWidth", 300);
            frm.Height = IniFileHelper.ReadIniInt(SettingsIniFile, "Settings", "MainHeight", 600);
        }
        /// <summary>
        /// lvwProcess ColumnClick
        /// </summary>
        /// <param name="lvwProcesses"></param>
        /// <param name="e"></param>
        public void lvwProcesses_ColumnClick(ListView lvwProcesses, ColumnClickEventArgs e) {
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
            UpdateNow(lvwProcesses);
        }
        /// <summary>
        /// Kill
        /// </summary>
        /// <param name="spids"></param>
        /// <returns></returns>
        public void Kill(List<int> spids) {
            using (var db = GetDb())
                if (db != null)
                    foreach (var spid in spids)
                        db.Execute("KILL " + spid.ToString() + ";");
        }
        /// <summary>
        /// Form Closed
        /// </summary>
        /// <param name="lvwProcesses"></param>
        /// <param name="frm"></param>
        public void FormClosed(ListView lvwProcesses, Form frm) {
            IniFileHelper.WriteIni(SettingsIniFile, "Settings", "SPIDWidth", lvwProcesses.Columns[0].Width.ToString());
            IniFileHelper.WriteIni(SettingsIniFile, "Settings", "StatusWidth", lvwProcesses.Columns[1].Width.ToString());
            IniFileHelper.WriteIni(SettingsIniFile, "Settings", "LoginWidth", lvwProcesses.Columns[2].Width.ToString());
            IniFileHelper.WriteIni(SettingsIniFile, "Settings", "HostNameWidth", lvwProcesses.Columns[3].Width.ToString());
            IniFileHelper.WriteIni(SettingsIniFile, "Settings", "BlkByWidth", lvwProcesses.Columns[4].Width.ToString());
            IniFileHelper.WriteIni(SettingsIniFile, "Settings", "DBNameWidth", lvwProcesses.Columns[5].Width.ToString());
            IniFileHelper.WriteIni(SettingsIniFile, "Settings", "CommandWidth", lvwProcesses.Columns[6].Width.ToString());
            IniFileHelper.WriteIni(SettingsIniFile, "Settings", "CpuTimeWidth", lvwProcesses.Columns[7].Width.ToString());
            IniFileHelper.WriteIni(SettingsIniFile, "Settings", "DiskIOWidth", lvwProcesses.Columns[8].Width.ToString());
            IniFileHelper.WriteIni(SettingsIniFile, "Settings", "LastBatchWidth", lvwProcesses.Columns[9].Width.ToString());
            IniFileHelper.WriteIni(SettingsIniFile, "Settings", "ProgramNameWidth", lvwProcesses.Columns[10].Width.ToString());
            IniFileHelper.WriteIni(SettingsIniFile, "Settings", "SPID2Width", lvwProcesses.Columns[11].Width.ToString());
            IniFileHelper.WriteIni(SettingsIniFile, "Settings", "RequestIDWidth", lvwProcesses.Columns[12].Width.ToString());
            IniFileHelper.WriteIni(SettingsIniFile, "Settings", "MainWidth", frm.ClientSize.Width.ToString());
            IniFileHelper.WriteIni(SettingsIniFile, "Settings", "MainHeight", frm.ClientSize.Height.ToString());
            IniFileHelper.WriteIni(SettingsIniFile, "Settings", "MainLeft", frm.Left.ToString());
            IniFileHelper.WriteIni(SettingsIniFile, "Settings", "MainTop", frm.Top.ToString());
        }
        /// <summary>
        /// Update Big Tables
        /// </summary>
        public void UpdateBigTables(ListView lvwBigTables) {
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
        }
        /// <summary>
        /// Update Now
        /// </summary>
        public void UpdateNow(ListView lvwProcesses) {
            //if (lblError.Text != "") lblError.Text = "";
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

                lvwProcesses.BeginUpdate();
                var topItemIndex = lvwProcesses.TopItem != null ? (int?)lvwProcesses.TopItem.Index : null;
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
                    lvwProcesses.EndUpdate();
                    if (topItemIndex != null) {
                        lvwProcesses.TopItem = lvwProcesses.Items[topItemIndex.Value];
                        lvwProcesses.TopItem = lvwProcesses.Items[topItemIndex.Value];
                    }
                }
            }
        }
        /// <summary>
        /// Get Statistics
        /// </summary>
        /// <returns></returns>
        public PerformanceStatisticModel GetPerformance() {
            var result = new PerformanceStatisticModel();
#pragma warning disable CA1416 // Validate platform compatibility
            result.CPU = new PerformanceCounter("Processor", "% Processor Time", "_Total").NextValue();
#pragma warning restore CA1416 // Validate platform compatibility
            return result;
        }
    }
}