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

        public async Task<string> MakeJokeRequestAsync(string path)
        {
            //set up the request
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");


            //Define the resource path
            request.Resource = $"{path.ToLower().Replace(" ", "")}";

            //Execute the request and store the response
            var response = await _client.ExecuteAsync(request);

            //Capture the status code
            StatusDescription = response.StatusCode.ToString();

            return response.Content;
        }

        public async Task<string> SubmitJokeRequestAsync(string path, JObject body)
        {
            //set up the request
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            //Define the resource path
            request.Resource = path;

            //Execute the request and store the response
            request.AddJsonBody(body.ToString());
            var response = await _client.ExecuteAsync(request);

            //Capture the status code
            StatusDescription = response.StatusCode.ToString();

            return response.Content;
        }



    }
}
