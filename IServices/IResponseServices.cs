using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;

namespace WebAPICore.IServices
{
    public interface IResponseServices
    {

        IEnumerable<Response> GetResponse();
        Response AddResponse(Response response);
        Response UpdateResponse(Response response);
        Response DeleteResponse(int id);
    }
}
