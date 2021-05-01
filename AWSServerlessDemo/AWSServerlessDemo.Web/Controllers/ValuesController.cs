using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AWSServerlessDemo.Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "https://jsonplaceholder.typicode.com/todos/";

        public ValuesController()
        {
            _client = new HttpClient();
        }


        [HttpGet]
        public dynamic Get()
        {
            return new
            {
                Guid = Guid.NewGuid().ToString(),
                Expires = DateTime.Now.AddDays(1),
                Issuer = Environment.MachineName
            };
        }


        [HttpGet("getHttp")]
        public async Task<dynamic> GetHttp()
        {
            var httpResponse = await _client.GetAsync(BaseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            //var tasks = JsonConvert.DeserializeObject<List<Todo>>(content);

            return Ok(content);
        }

        [HttpGet("getHttpSecure")]
        [Authorize]
        public async Task<dynamic> GetHttpSecure()
        {
            var httpResponse = await _client.GetAsync(BaseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            return Ok(content);
        }



        [HttpGet("getEnv")]
        public dynamic GetEnv()
        {
            dynamic payload = new
            {
                Authority = Environment.GetEnvironmentVariable("Authority"),
                DefaultConnection = Environment.GetEnvironmentVariable("DefaultConnection")
            };

            return Ok(payload);
        }




    }
}
