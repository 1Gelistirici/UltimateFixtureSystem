using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class LogCallManager
    {
        private static readonly object Lock = new object();
        private static volatile LogCallManager _instance;
        public static LogCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LogCallManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<Log>> GetLogs(Log parameter)
        {
            return LogManager.Instance.GetLogs(parameter);
        }

        public UltimateResult<List<Log>> DeleteLog(Log parameter)
        {
            return LogManager.Instance.DeleteLog(parameter);
        }

        public UltimateResult<List<Log>> AddLog(Log parameter)
        {
            return LogManager.Instance.AddLog(parameter);
        }

    }
}
