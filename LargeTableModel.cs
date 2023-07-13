namespace SqlTaskManager {
    /// <summary>
    /// Large Table Model
    /// </summary>
    public class LargeTableModel {
        /// <summary>
        /// Table
        /// </summary>
        public required string table { get; set; }
        /// <summary>
        /// Used MB
        /// </summary>
        public required string used_mb { get; set; }
        /// <summary>
        /// Allocated MB
        /// </summary>
        public required string allocated_mb { get; set; }
    }
}