using static System.Windows.Forms.ListView;
namespace SqlTaskManager {
    /// <summary>
    /// Extension methods for List Views
    /// </summary>
    public static class ListViewExtensions {
        /// <summary>
        /// Sets the double buffered property of a list view to the specified value
        /// </summary>
        /// <param name="listView">The List view</param>
        /// <param name="doubleBuffered">Double Buffered or not</param>
        public static void SetDoubleBuffered(this System.Windows.Forms.ListView listView, bool doubleBuffered = true) {
            listView
                .GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)?
                .SetValue(listView, doubleBuffered, null);
        }
        /// <summary>
        /// To List
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static List<ListViewItem> ToList(this SelectedListViewItemCollection objs) {
            var result = new List<ListViewItem>();
            foreach (var obj in objs)
                result.Add((ListViewItem)obj);
            return result;
        }
    }
}