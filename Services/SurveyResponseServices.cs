using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.IServices;
using WebAPICore.Models;

namespace WebAPICore.Services
{
    public class SurveyResponseServices: ISurveyResponseServices
    {
        BD_SurveyContext dbContext;

        public SurveyResponseServices(BD_SurveyContext _db)
        {
            dbContext = _db;
        }

        public IEnumerable<SurveyResponse> GetSurveyResponse()
        {
            var surveyrespon = dbContext.SurveyResponses.ToList();
            return surveyrespon;

        }

        public SurveyResponse AddSurveyResponse(SurveyResponse surveyresponse)
        {
            if (surveyresponse != null)
            {
                dbContext.SurveyResponses.Add(surveyresponse);

                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }
                
                return surveyresponse;
            }
            return null;
        }

        public SurveyResponse UpdateSurveyResponse(SurveyResponse surveyresponse)
        {

            dbContext.Entry(surveyresponse).State = EntityState.Modified;

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            return surveyresponse;

        }

        public SurveyResponse DeleteSurveyResponse(int Id)
        {

            var surveyresponse = dbContext.SurveyResponses.FirstOrDefault(x => x.Id == Id);
            dbContext.Entry(surveyresponse).State = EntityState.Deleted;

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            return surveyresponse;

        }

    }
}
