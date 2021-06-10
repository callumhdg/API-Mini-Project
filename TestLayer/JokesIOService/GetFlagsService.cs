using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer
{
    public class GetFlagsService
    {
        public CallManager CallManager { get; set; }
        //Newstonsoft object representing the json response
        public JObject JsonResponse { get; set; }

        public DTO<FlagsResponse> FlagsDTO { get; set; }
        //response content as a string
        public string FlagResponse { get; set; }

        public GetFlagsService()
        {
            CallManager = new CallManager();
            FlagsDTO = new DTO<FlagsResponse>();
        }

        public async Task MakeRequestAsync()
        {
            FlagResponse = await CallManager.MakeRequestAsync($"flags");

            JsonResponse = JObject.Parse(FlagResponse);

            FlagsDTO.DeserializeResponse(FlagResponse);
        }
    }
}
