using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class MessageCallManager
    {
        private static readonly object Lock = new object();
        private static volatile MessageCallManager _instance;
        public static MessageCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MessageCallManager();
                        }
                    }
                }
                return _instance;
            }
        }


        public UltimateResult<List<Message>> GetMessages(Message parameter)
        {
            return MessageManager.Instance.GetMessages(parameter);
        }

        public UltimateResult<List<Message>> DeleteMessage(Message parameter)
        {
            return MessageManager.Instance.DeleteMessage(parameter);
        }

        public UltimateResult<List<Message>> AddMessage(Message parameter)
        {
            return MessageManager.Instance.AddMessage(parameter);
        }

    }
}
