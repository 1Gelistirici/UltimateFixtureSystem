
using System.Collections.Generic;

namespace UltimateAPI.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Area { get; set; }
        public string Icon { get; set; }
        public int Dependency { get; set; }
        public int Order { get; set; }
        public List<Menu> Children{ get; set; }
    }
}
