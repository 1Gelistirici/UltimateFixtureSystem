
namespace Functions
{
    public class JsonHelper
    {
        public class JsonResult
        {
            public int Id { get; set; }

            public bool IsSuccess { get; set; }

            public string Message { get; set; }

            public string ExceptionDetail { get; set; }

            public object Data { get; set; }
        }


        public static T JsonConvert<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
                return default(T);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json, new Newtonsoft.Json.JsonSerializerSettings() { DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local });
        }
    }
}