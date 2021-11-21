using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApplicationDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentController : ControllerBase
    {

        private readonly ILogger<AssignmentController> _logger;

        public AssignmentController(ILogger<AssignmentController> logger)
        {
            _logger = logger;
        }

        private static string Check(int num)
        {
            if (num % 3 == 0)
            {
                if (num % 5 == 0)
                {
                    return "Walkers Assessment";
                }
                else
                {
                    return "Walkers";
                }
            }
            else if (num % 5 == 0)
            {
                return "Assessment";
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [HttpGet("api/{id}")]
        public JsonResult AjaxMethod(int id)
        {
            if(id == 0) { throw new HttpResponseException(HttpStatusCode.NotFound); }
            if (id <= 20)
            {
                var result = new Assignment
                {
                    Title = Check(id),
                    Number = id,
                    Date = System.DateTime.Now
                };
                return new JsonResult(result);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

        }
    }

    [Serializable]
    internal class HttpResponseException : Exception
    {
        private HttpStatusCode notFound;

        public HttpResponseException()
        {
        }

        public HttpResponseException(HttpStatusCode notFound)
        {
            this.notFound = notFound;
        }

        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
