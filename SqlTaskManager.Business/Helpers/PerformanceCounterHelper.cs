using System.Diagnostics;
namespace SqlTaskManager.Business.Helpers {
    /// <summary>
    /// Performance Counter Helper
    /// </summary>
    public static class PerformanceCounterHelper {
        /// <summary>
        /// Get Cpu
        /// </summary>
        /// <param name="machine"></param>
        /// <returns></returns>
        public static double? GetCpu(string machine) {
            var result = (double?)0;
            var counter = new CounterManager("Processor", "% Processor Time", "_Total", machine);
            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                var n = 0;
                var b = false;
                while (!counter.CounterReady() && !b) {
                    n++;
                    Thread.Sleep(1000);
                    if (n == 10) {
                        b = true;
                    }
                }
                if (counter.CounterReady()) {
                    result = counter.GetCounter();
                }
            }).Start();
            return result;
        }
    }
    /// <summary>
    /// Counter Manager
    /// </summary>
    public class CounterManager {
        /// <summary>
        /// Counter
        /// </summary>
        private PerformanceCounter _counter;
        /// <summary>
        /// Ready Time
        /// </summary>
        private DateTime _readyTime;
        /// <summary>
        /// Initialize the requested performance counter. the counter needs about a second
        /// to register and collect meaningfull data.
        /// </summary>
        /// <param name="categoryname"></param>
        /// <param name="countername"></param>
        /// <param name="instancename"></param>
        /// <param name="machine">remote computer name, you need to member of the performance monitor users group</param>
        public CounterManager(string categoryname, string countername, string instancename, string machine) {
            _counter = new PerformanceCounter(categoryname, countername, instancename, machineName: machine);
            float initialValue = _counter.NextValue();
            _readyTime = DateTime.Now.AddSeconds(1);
        }
        /// <summary>
        /// Indicates if the counter is ready to provide the next sample point.
        /// </summary>
        /// <returns></returns>
        public bool CounterReady() {
            return DateTime.Now > _readyTime;
        }
        /// <summary>
        /// Get the next sample point
        /// </summary>
        /// <returns></returns>
        public float GetCounter() {
            float currentValue = _counter.NextValue();
            _readyTime = DateTime.Now.AddSeconds(1);
            return currentValue;
        }
    }
}