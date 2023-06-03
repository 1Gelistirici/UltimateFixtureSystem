using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Models.Tool
{
    public class UserRoleAuthentication
    {
        Timer emptyTempUserRolesTimer;
        UltimateResult<List<UserRole>> tempUserRoles;
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
            UltimateResult<List<UserRole>> userRoles = getUserRoles(userRefId);
            bool isAuthorized = userRoles.Data.Find(x => x.MenuRefId == pageNumber) != null;
            //userRoles.Data?.Find(x => x.MenuRefId == pageNumber) != null;

            return isAuthorized;
        }

        private UltimateResult<List<UserRole>> getUserRoles(int userRefId)
        {
            if (tempUserRoles is null)
            {
                var request = WebRequest.Create(ConnectionManager.Instance.apiAdress + "UserRole/GetRole");
                request.Method = "POST";
                request.ContentType = "application/json";

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

                tempUserRoles = JsonConvert.DeserializeObject<UltimateResult<List<UserRole>>>(content);

                if (emptyTempUserRolesTimer is null)
                {
                    emptyTempUserRolesTimer = new Timer(emptyTempUserRoles, null, 5000, Timeout.Infinite);
                }
                else
                {
                    emptyTempUserRolesTimer = null;
                    emptyTempUserRolesTimer = new Timer(emptyTempUserRoles, null, 5000, Timeout.Infinite);
                }

                return tempUserRoles;
            }
            else
            {
                return tempUserRoles;
            }
        }

        private void emptyTempUserRoles(object state)
        {
            tempUserRoles = null;
            emptyTempUserRolesTimer = null;
        }

    }
}
