using static System.Windows.Forms.ListView;
namespace SqlTaskManager {
    /// <summary>
    /// Are you sure? End Task
    /// </summary>
    public partial class frmAreYouSureEndTask : Form {
        /// <summary>
        /// Form
        /// </summary>
        private frmMain _form;
        private SelectedListViewItemCollection _listViewItems;
        /// <summary>
        /// Are you Sure (End Task)?
        /// </summary>
        /// <param name="listViewItems"></param>
        /// <param name="form"></param>
        public frmAreYouSureEndTask(SelectedListViewItemCollection listViewItems, frmMain form) {
            InitializeComponent();
            _form = form;
            _listViewItems = listViewItems;
            this.Icon = form.Icon;
        }
        /// <summary>
        /// Form - Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAreYouSureEndTask_Load(object sender, EventArgs e) {
            try {
                foreach (var item in _listViewItems) {
                    var listViewItem = ((ListViewItem)item);
                    lstTasks.Items.Add("SPID: " + listViewItem.Text + ", Program Name: " + listViewItem.SubItems[10].Text);
                }
            } catch (Exception ex) {
                _form.ShowError(ex.Message);
            }
        }
        /// <summary>
        /// OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e) {
            try {
                _form.Kill(_listViewItems.ToList().Select(si => si.Text).ToList().ToIntList());
                this.Close();
            } catch (Exception ex) {
                _form.ShowError(ex.Message);
            }
        }
        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e) {
            try {
                this.Close();
            } catch (Exception ex) {
                _form.ShowError(ex.Message);
            }
        }
    }
}