
using Newtonsoft.Json;

namespace UltimateAPI.Entities
{
    public class UltimateSetResult
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public int ReturnId { get; set; }

        public UltimateSetResult()
        {
            IsSuccess = true;
            Message = "";
        }

        public static string Get(bool isSuccess, string message, int returnId = 0)
        {
            UltimateSetResult newResult = new UltimateSetResult();
            newResult.Message = message;
            newResult.IsSuccess = isSuccess;
            newResult.ReturnId = returnId;
            return JsonConvert.SerializeObject(newResult);
        }
    }
}
