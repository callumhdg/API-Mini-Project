using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer
{
    public class DTO<ResponseType> where ResponseType : IResponse, new()
    {
        public ResponseType Response { get; set; }

        public IResponse IResponse
        {
            get => default;
            set
            {
            }
        }

        public void DeserializeResponse(string jokeResponse)
        {
            Response = JsonConvert.DeserializeObject<ResponseType>(jokeResponse);
        }
    }
}
