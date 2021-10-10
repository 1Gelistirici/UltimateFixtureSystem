using Microsoft.AspNetCore.Mvc;
using System;
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
                string fileName = "UltimateDemirbasApi.txt";
                string filePath = @"c:\";
                string targetFile = System.IO.Path.Combine(filePath, fileName);

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
