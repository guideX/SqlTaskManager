namespace SqlTaskManager {
    /// <summary>
    /// Slow Running Queries Model
    /// </summary>
    public class SlowRunningQueriesModel {
        /// <summary>
        /// Average CPU Time
        /// </summary>
        public required string Average_CPU_Time { get; set; }
        /// <summary>
        /// Query Text
        /// </summary>
        public required string QueryText { get; set; }
    }
}