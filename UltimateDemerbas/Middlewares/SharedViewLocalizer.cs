using System.Reflection;
using Microsoft.Extensions.Localization;

namespace MultiLanguage.Utilities
{
    public class SharedViewLocalizer
    {
        private readonly IStringLocalizer _localizer;

        public SharedViewLocalizer(IStringLocalizerFactory factory)
        {
            var assembly = Assembly.GetEntryAssembly();
            var assemblyName = assembly.GetName().Name;
            var projectName = assemblyName;

            _localizer = factory.Create("Lang", projectName);
        }

        public LocalizedString this[string key] => _localizer[key];

        public LocalizedString GetLocalizedString(string key)
        {
            return _localizer[key];
        }
    }

}
