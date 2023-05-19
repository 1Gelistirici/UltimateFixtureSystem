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

        public UltimateResult<Code> GetCodeV1(Code parameter)
        {
            return CodeManager.Instance.GetCodeV1(parameter);
        }

        public UltimateSetResult IsValidateCode(Code parameter)
        {
            UltimateSetResult result = new UltimateSetResult();
            UltimateResult<Code> code = CodeManager.Instance.GetCodeV1(parameter);

            result.IsSuccess = code.Data != null;

            return result;
        }

        public UltimateSetResult DeleteCodeBySessionId(string sessionId)
        {
            return CodeManager.Instance.DeleteCodeBySessionId(sessionId);
        }

        public UltimateSetResult IsBlockedBySessionId(string sessionId)
        {
            return CodeManager.Instance.IsBlockedBySessionId(sessionId);
        }

        public bool AddCode(Code parameter)
        {
            return CodeManager.Instance.AddCode(parameter);
        }
    }
}
