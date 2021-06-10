using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer
{
    public class PingService
    {
        public CallManager CallManager { get; set; }
        //Newstonsoft object representing the json response
        public JObject JsonResponse { get; set; }

        public DTO<PingResponse> PingDTO { get; set; }
        //response content as a string
        public string PingResponse { get; set; }

        public PingService()
        {
            CallManager = new CallManager();
            PingDTO = new DTO<PingResponse>();
        }

        public async Task MakeRequestAsync()
        {
            PingResponse = await CallManager.MakeRequestAsync($"ping");

            JsonResponse = JObject.Parse(PingResponse);

            PingDTO.DeserializeResponse(PingResponse);
        }

    }
}
