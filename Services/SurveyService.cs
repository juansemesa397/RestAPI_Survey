using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.IServices;
using WebAPICore.Models;

namespace WebAPICore.Services
{
    public class SurveyService: ISurveyService
    {
        BD_SurveyContext dbContext;

        public SurveyService(BD_SurveyContext _db)
        {
            dbContext = _db;
        }

        public IEnumerable<Survey> GetSurveyService()
        {
            
                var survey = dbContext.Surveys.ToList();
                return survey;
           
        }

        public Survey AddSurveyService(Survey survey)
        {
            if (survey != null)
            {
                dbContext.Surveys.Add(survey);

                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

                return survey;
            }
            return null;

        }

        public Survey UpdateService(Survey survey)
        {

            dbContext.Entry(survey).State = EntityState.Modified;

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            return survey;

        }

        public Survey DeleteSurvey(int Id)
        {

            var employee = dbContext.Surveys.FirstOrDefault(x => x.Id == Id);
            dbContext.Entry(employee).State = EntityState.Deleted;

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            return employee;

        }
    }
}
