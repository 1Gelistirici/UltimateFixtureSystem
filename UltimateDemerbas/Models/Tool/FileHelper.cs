using Microsoft.Extensions.Configuration;
using System.IO;
using UltimateAPI.Entities.Enums;

namespace UltimateDemerbas.Models.Tool
{
    public class FileHelper
    {
        private IConfiguration configuration;
        public FileHelper(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        public string GetSaveURL(SaveFile saveFile, int companyRefId)
        {
            var saveUrl = configuration.GetSection("FileSaveDebug").Value;
            if (saveUrl == null)
            {
                return "";
            }

            string url = Path.Combine(saveUrl, companyRefId.ToString(), saveFile.ToString());

            CheckFolder(url);

            return url;
        }

        private void CheckFolder(string url)
        {
            if (!Directory.Exists(url))
            {
                Directory.CreateDirectory(url);
            }
        }


    }
}
