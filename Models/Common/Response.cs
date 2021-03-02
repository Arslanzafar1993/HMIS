using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Common
{
    public class Response<T> where T : class
    {
        public bool IsException { get; set; }
        public string Messages { get; set; }
        public T Data { get; set; }
    }
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
