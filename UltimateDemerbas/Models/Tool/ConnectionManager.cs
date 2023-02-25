
namespace UltimateDemerbas.Models.Tool
{
    public class ConnectionManager
    {
        private static readonly object Lock = new object();
        private static volatile ConnectionManager _instance;
        public static ConnectionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ConnectionManager();
                        }
                    }
                }
                return _instance;
            }

        }


        public string apiAdress = "https://localhost:44354/api/";
    }
}
