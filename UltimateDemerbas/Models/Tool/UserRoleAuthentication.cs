using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Models.Tool
{
    public class UserRoleAuthentication
    {
        private static readonly object Lock = new object();
        private static volatile UserRoleAuthentication _instance;
        public static UserRoleAuthentication Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserRoleAuthentication();
                        }
                    }
                }
                return _instance;
            }
        }


        public bool CheckMenuUserRole(int userRefId, int pageNumber)
        {
            var request = WebRequest.Create(ConnectionManager.Instance.apiAdress + "UserRole/GetRole");
            request.Method = "POST";
            request.ContentType = "application/json";


        //https://localhost:44354/api/UserRole/GetRole

            var jsonData = JsonConvert.SerializeObject(new UserRole() { UserRefId = userRefId });
            var data = Encoding.UTF8.GetBytes(jsonData);


            request.ContentLength = data.Length;

            Stream stream;
            using (stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = request.GetResponse();
            stream = response.GetResponseStream();
            var reader = new StreamReader(stream);
            var content = reader.ReadToEnd();


            UltimateResult<List<UserRole>> userRoles = JsonConvert.DeserializeObject<UltimateResult<List<UserRole>>>(content);
            bool isAuthorized = userRoles.Data.Find(x => x.MenuRefId == pageNumber) != null;

            return isAuthorized;
        }


    }
}
