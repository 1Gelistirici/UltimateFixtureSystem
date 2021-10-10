using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltimateAPI.Entities
{
    public class UltimateResult<T> where T : class, new()
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public int ReturnId { get; set; }
        public UltimateResult()
        {
            Message = "";
            IsSuccess = true;
        }
    }
}
