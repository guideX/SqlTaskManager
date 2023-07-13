namespace SqlTaskManager {
    /// <summary>
    /// SpWho2 Model
    /// </summary>
    [PetaPoco.TableName("SP_WHO2")]
    [PetaPoco.PrimaryKey("SPID")]
    public class SpWho2Model {
        /// <summary>
        /// SPID
        /// </summary>
        public required int SPID { get; set; }
        /// <summary>
        /// Status
        /// </summary>
		public required string Status { get; set; }
        /// <summary>
        /// Login
        /// </summary>
        public required string Login { get; set; }
        /// <summary>
        /// Host Name
        /// </summary>
        public required string HostName { get; set; }
        /// <summary>
        /// Blk By
        /// </summary>
        public required string BlkBy { get; set; }
        /// <summary>
        /// Db Name
        /// </summary>
        public required string DBName { get; set; }
        /// <summary>
        /// Command
        /// </summary>
        public required string Command { get; set; }
        /// <summary>
        /// Cpu Time
        /// </summary>
        public required int CpuTime { get; set; }
        /// <summary>
        /// Disk IO
        /// </summary>
        public required int DiskIO { get; set; }
        /// <summary>
        /// Last Batch
        /// </summary>
        public required string LastBatch { get; set; }
        /// <summary>
        /// Program Name
        /// </summary>
        public required string ProgramName { get; set; }
        /// <summary>
        /// SPID2
        /// </summary>
        public required int SPID2 { get; set; }
        /// <summary>
        /// RequestID
        /// </summary>
        public required int RequestID { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        public required DateTime Timestamp { get; set; }
    }
}