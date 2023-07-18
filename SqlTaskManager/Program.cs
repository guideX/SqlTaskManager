namespace SqlTaskManager;
/// <summary>
/// Program
/// </summary>
static class Program {
    /// <summary>
    /// Constructor
    /// </summary>
    [STAThread]
    static void Main() {
        ApplicationConfiguration.Initialize();
        Application.Run(new frmMain());
    }
}