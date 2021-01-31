using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessDemo.Web.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
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
    }
}
