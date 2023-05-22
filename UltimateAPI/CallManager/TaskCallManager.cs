using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class TaskCallManager
    {
        private static readonly object Lock = new object();
        private static volatile TaskCallManager _instance;
        public static TaskCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new TaskCallManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<Tasks>> GetTasks(Tasks parameter)
        {
            return TaskManager.Instance.GetTasks(parameter);
        }
        
        public UltimateResult<List<Tasks>> GetTask(Tasks parameter)
        {
            return TaskManager.Instance.GetTask(parameter);
        }

        public UltimateResult<List<Tasks>>UpdateTask(Tasks parameter)
        {
            return TaskManager.Instance.UpdateTask(parameter);
        }
        
        public UltimateResult<List<Tasks>> DeleteTask(Tasks parameter)
        {
            return TaskManager.Instance.DeleteTask(parameter);
        }

        public UltimateResult<List<Tasks>> AddTask(Tasks parameter)
        {
            return TaskManager.Instance.AddTask(parameter);
        }

        public UltimateResult<List<Tasks>> AddStatu(Tasks parameter)
        {
            return TaskManager.Instance.AddStatu(parameter);
        }

        public UltimateResult<List<Tasks>> GetTaskByCompanyRefId(ReferansParameter parameter)
        {
            return TaskManager.Instance.GetTaskByCompanyRefId(parameter);
        }

    }
}
