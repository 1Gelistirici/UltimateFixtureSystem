
using Newtonsoft.Json;

namespace UltimateAPI.Entities
{
    public class UltimateSetResult
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public UltimateSetResult()
        {
            IsSuccess = true;
            Message = "";
        }
        public static string Get(bool isSuccess, string message)
        {
            ResultData newResult = new ResultData(isSuccess, message);
            return JsonConvert.SerializeObject(newResult);
        }
    }
}
