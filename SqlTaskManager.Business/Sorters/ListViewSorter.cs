using System.Windows.Forms;
namespace SqlTaskManager {
    /// <summary>
    /// List View Sorter
    /// </summary>
    public class ListViewSorter : System.Collections.IComparer {
        /// <summary>
        /// Column
        /// </summary>
        public int Column = 0;
        /// <summary>
        /// Order
        /// </summary>
        public System.Windows.Forms.SortOrder Order = SortOrder.Ascending;
        /// <summary>
        /// Compare
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object? x, object? y) {
            if (x == null || y == null) return 0;
            if (!(x is ListViewItem)) return 0;
            if (!(y is ListViewItem)) return 0;
            var l1 = (ListViewItem)x;
            var l2 = (ListViewItem)y;
            if (l1 != null && l1.ListView != null) {
                Column = Convert.ToInt32(l1.ListView.Tag);
                switch (l1.ListView.Columns[Column].Tag) {
                    case "Numeric":
                        var fl1 = float.Parse(l1.SubItems[Column].Text);
                        var fl2 = float.Parse(l2.SubItems[Column].Text);
                        if (Order == SortOrder.Ascending)
                            return fl1.CompareTo(fl2);
                        else
                            return fl2.CompareTo(fl1);
                    default:
                        var str1 = l1.SubItems[Column].Text;
                        var str2 = l2.SubItems[Column].Text;
                        if (Order == SortOrder.Ascending)
                            return str1.CompareTo(str2);
                        else
                            return str2.CompareTo(str1);
                }
            } else {
                return 0;
            }
        }
    }
}