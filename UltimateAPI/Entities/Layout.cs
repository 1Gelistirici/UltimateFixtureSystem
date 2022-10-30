using UltimateAPI.Entities.Enums;

namespace UltimateAPI.Entities
{
    public class Layout:BaseProperty
    {
        public string Url { get; set; }
        public string Area { get; set; }
        public string Icon { get; set; }
        public MenuType Dependency { get; set; }
    }
}
