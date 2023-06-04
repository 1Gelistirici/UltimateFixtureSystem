using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class FeedbackCallManager
    {
        private static readonly object Lock = new object();
        private static volatile FeedbackCallManager _instance;
        public static FeedbackCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new FeedbackCallManager();
                        }
                    }
                }
                return _instance;
            }

        }


        public UltimateSetResult AddFeedback(Feedback parameter)
        {
            return FeedbackManager.Instance.AddFeedback(parameter);
        }

        public UltimateResult<List<Feedback>> GetFeedbackByUser(ReferansParameter parameter)
        {
            return FeedbackManager.Instance.GetFeedbackByUser(parameter);
        }


    }
}
