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
            //submitJokeResponse = await CallManager.MakeJokeRequestAsync($"submit{values}{}{}{}");
            //JObject body = new JObject(            
            //    new JProperty("formatVersion", 3),
            //    new JProperty("category", "Misc"),
            //    new JProperty("type", "single"),
            //    new JProperty("joke", "A horse walks into a bar..."),
            //    new JArray("flags",
            //        new JProperty("nsfw", true),
            //        new JProperty("religious", false),
            //        new JProperty("political", true),
            //        new JProperty("racist", false),
            //        new JProperty("sexist", false),
            //        new JProperty("explicit", false)
            //    ),
            //new JProperty("lang", "en")
            //);

            //JObject body = new JObject();

            //body["formatVersion"] = 3;
            //body["category"] = "Misc";
            //body["type"] = "single";
            //body["joke"] = "A horse walks into a bar...";
            //body["flags"] = new JArray { new JObject 
            //{ ["nsfw"] = false, 
            //    ["religious"] = false, 
            //    ["political"] = false,
            //    ["racist"] = false,
            //    ["sexist"] = false,
            //    ["explicit"] = false,
            //} };
            //body["lang"] = "en";


            submitJokeResponse = await CallManager.SubmitJokeRequestAsync($"submit", body);

            JsonResponse = JObject.Parse(submitJokeResponse);

            JokeDTO.DeserializeResponse(submitJokeResponse);
        }


    }
}
