using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class BaseManager : Controller
    {

        public void AddLog(int id, string message)
        {
            Log log = new Log();
            log.Detail = message;
            log.Time = DateTime.Now;
            log.UserNo = id;
            log.Icon = "fa fa-check";
            LogCallManager.Instance.AddLog(log);
        }

        public void Error(Exception ex)
        {
            WriteError(ex);
        }

        private void WriteError(Exception ex)
        {
            try
            {
                string root = @"C:\UFS";
                string subdir = @"C:\UFS\UltimateAPI";

                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }


                if (!Directory.Exists(subdir))
                {
                    Directory.CreateDirectory(subdir);
                }

                string fileName = "ErrorUltimateAPI.txt";
                string targetFile = System.IO.Path.Combine(subdir, fileName);

                if (!System.IO.File.Exists(targetFile))
                {
                    var file = System.IO.File.Create(targetFile);
                    file.Close();
                }
                System.IO.File.WriteAllText(targetFile, ex.ToString());
            }
            catch (Exception)
            {

            }

        }

    }
}
