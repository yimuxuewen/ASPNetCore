using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcClientDemo.Models
{
    public class ErrorInfos
    {
        public string ErrorMessage { get; set; }
        public string Path { get; set; }
        public string QueryStr { get; set; }
        public string BasePath { get; set; }
    }
}
