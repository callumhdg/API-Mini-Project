using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer
{
    public class CategoryService
    {
        public CallManager CallManager { get; set; }
        //Newstonsoft object representing the json response
        public JObject JsonResponse { get; set; }

        public DTO<CategoryResponse> CategoryDTO { get; set; }
        //response content as a string
        public string CategoryResponse { get; set; }

        public CategoryService()
        {
            CallManager = new CallManager();
            CategoryDTO = new DTO<CategoryResponse>();
        }

        public async Task MakeRequestAsync()
        {
            CategoryResponse = await CallManager.MakeRequestAsync("categories");

            JsonResponse = JObject.Parse(CategoryResponse);

            CategoryDTO.DeserializeResponse(CategoryResponse);
        }

    }
}
