using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer
{
    public class GetJokeService
    {
        public CallManager CallManager { get; set; }
        //Newstonsoft object representing the json response
        public JObject JsonResponse { get; set; }

        public DTO<JokeIDResponse> JokeDTO { get; set; }
        //response content as a string
        public string JokeResponse { get; set; }

        public GetJokeService()
        {
            CallManager = new CallManager();
            JokeDTO = new DTO<JokeIDResponse>();
        }

        public async Task MakeRequestAsync()
        {
            JokeResponse = await CallManager.MakeJokeRequestAsync($"joke/any?idRange=0");

            JsonResponse = JObject.Parse(JokeResponse);

            JokeDTO.DeserializeResponse(JokeResponse);
        }
    }
}
