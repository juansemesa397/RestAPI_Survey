using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICore.IServices;
using WebAPICore.Models;

namespace WebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private readonly IResponseServices responseServices;

        public ResponseController(IResponseServices response)
        {
            responseServices = response;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Response/GetResponse")]
        public IEnumerable<Response> GetResponse()
        {
            return responseServices.GetResponse();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Response/AddResponse")]
        public Response AddResponse(Response response)
        {
            return responseServices.AddResponse(response);
        }

        [HttpPut]
        [Route("[action]")]
        [Route("api/Response/UpdateResponse")]
        public Response UpdateResponse(Response response)
        {
            return responseServices.UpdateResponse(response);
        }

        [HttpDelete]
        [Route("[action]")]
        [Route("api/Response/DeleteResponse")]
        public Response DeleteResponse(int Id)
        {
            return responseServices.DeleteResponse(Id);
        }
    }
}