using Newtonsoft.Json;

namespace UltimateAPI.Entities
{
    public class ResultData
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public string Token { get; set; }

        public ResultData(bool isSuccess, string message)
        {
            Message = message;
            IsSuccess = isSuccess;
        }
        public static string Get(bool isSuccess, string message, object data)
        {
            ResultData newResult = new ResultData(isSuccess, message);
            newResult.Data = data;
            var res = JsonConvert.SerializeObject(newResult);
            return res;
        }
    }
}
