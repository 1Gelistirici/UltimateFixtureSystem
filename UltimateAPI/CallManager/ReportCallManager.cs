using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class ReportCallManager
    {
        private static readonly object Lock = new object();
        private static volatile ReportCallManager _instance;
        public static ReportCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ReportCallManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<Report>> GetReports()
        {
            return ReportManager.Instance.GetReports();
        }

        public UltimateResult<List<Report>> GetPassiveReports()
        {
            return ReportManager.Instance.GetPassiveReports();
        }

        public UltimateResult<List<Report>> AddReport(Report parameter)
        {
            return ReportManager.Instance.AddReport(parameter);
        }

        public UltimateResult<List<Report>> UpdateReportStatu(Report parameter)
        {
            return ReportManager.Instance.UpdateReportStatu(parameter);
        }
    }
}
