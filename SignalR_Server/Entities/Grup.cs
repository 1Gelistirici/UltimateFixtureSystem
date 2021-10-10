using System.Collections.Generic;

namespace SignalR_Server.Entities
{
    public class Grup
    {
        public string GroupName { get; set; }
        public List<Client> Clients { get; set; }
    }
}
