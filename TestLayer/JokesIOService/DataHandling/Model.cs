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

    public class JokeResponse : IResponse
    {
        public int formatVersion { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string joke { get; set; }
        public Flags flags { get; set; }
        public string lang { get; set; }
    }

    public class Flags
    {
        public bool nsfw { get; set; }
        public bool religious { get; set; }
        public bool political { get; set; }
        public bool racist { get; set; }
        public bool sexist { get; set; }
        public bool _explicit { get; set; }
    }

    /////

    public class JokeIDResponse : IResponse
    {
        public bool error { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string joke { get; set; }
        public Flags flags { get; set; }
        public int id { get; set; }
        public bool safe { get; set; }
        public string lang { get; set; }
    }

}
