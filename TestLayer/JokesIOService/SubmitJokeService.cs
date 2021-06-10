using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer
{
    public class SubmitJokeService
    {
        public CallManager CallManager { get; set; }        
        public JObject JsonResponse { get; set; }
        public DTO<JokeResponse> JokeDTO { get; set; }
        public string submitJokeResponse { get; set; }

        public SubmitJokeService()
        {
            CallManager = new CallManager();
            JokeDTO = new DTO<JokeResponse>();
        }

        public async Task SubmitJokeRequestAsync(JObject body)
        {
            submitJokeResponse = await CallManager.MakeRequestAsync("submit", body);

            JsonResponse = JObject.Parse(submitJokeResponse);

            JokeDTO.DeserializeResponse(submitJokeResponse);
        }
    }
}
