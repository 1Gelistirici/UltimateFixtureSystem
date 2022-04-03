using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class CodeCallManager
    {
        private static readonly object Lock = new object();
        private static volatile CodeCallManager _instance;
        public static CodeCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new CodeCallManager();
                        }
                    }
                }
                return _instance;
            }

        }


        public UltimateResult<Code> GetCode(Code parameter)
        {
            return CodeManager.Instance.GetCode(parameter);
        }

        public bool AddCode(Code parameter)
        {
            return CodeManager.Instance.AddCode(parameter);
        }
    }
}
