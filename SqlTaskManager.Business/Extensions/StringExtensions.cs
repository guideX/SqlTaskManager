namespace SqlTaskManager {
    /// <summary>
    /// String Extensions
    /// </summary>
    public static class StringExtensions {
        /// <summary>
        /// To Int List
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static List<int> ToIntList(this List<string> strings) {
            var result = new List<int>();
            foreach (string s in strings) result.Add(Convert.ToInt32(s));
            return result;
        }
    }
}