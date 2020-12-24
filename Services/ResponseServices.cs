using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.IServices;
using WebAPICore.Models;

namespace WebAPICore.Services
{
    public class ResponseServices: IResponseServices
    {
        BD_SurveyContext dbContext;

        public ResponseServices(BD_SurveyContext _db)
        {
            dbContext = _db;
        }

        public IEnumerable<Response> GetResponse()
        {
            var survey = dbContext.Responses.ToList();
            return survey;

        }

        public Response AddResponse(Response response)
        {
            if (response != null)
            {
                dbContext.Responses.Add(response);

                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }

                return response;
            }
            return null;
        }

        public Response UpdateResponse(Response response)
        {

            dbContext.Entry(response).State = EntityState.Modified;
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            return response;

        }

        public Response DeleteResponse(int Id)
        {

            var response = dbContext.Responses.FirstOrDefault(x => x.RespondentId == Id);
            dbContext.Entry(response).State = EntityState.Deleted;

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            return response;

        }

    }
}
