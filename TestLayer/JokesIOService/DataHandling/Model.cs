using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestLayer
{
    public class PingResponse : IResponse
    {
        public bool error { get; set; }
        public string ping { get; set; }
        public long timestamp { get; set; }
    }
  
}
