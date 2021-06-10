using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer
{
    public class CallManager
    {
        private readonly IRestClient _client;
        public string StatusDescription { get; set; }

        public CallManager() 
        {
            _client = new RestClient(AppConfigReader.BaseUrl);
        }

        public async Task<string> MakeRequestAsync(string path, JObject body = null)
        {
            //set up the request
            var request = body != null ? new RestRequest(Method.POST) : new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");

            //Define the resource path
            request.Resource = path;
            if (body != null) request.AddJsonBody(body.ToString());

            //Execute the request and store the response
            var response = await _client.ExecuteAsync(request);

            //Capture the status code
            StatusDescription = response.StatusCode.ToString();

            return response.Content;
        }

    }
}
