using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.IServices;
using WebAPICore.Models;

namespace WebAPICore.Services
{
    public class RespondentServices: IRespondentServices
    {
        BD_SurveyContext dbContext;

        public RespondentServices(BD_SurveyContext _db)
        {
            dbContext = _db;
        }

        public IEnumerable<Respondent> GetRespondent()
        {
            var respondents = dbContext.Respondents.ToList();
            return respondents;

        }

        public Respondent AddRespondent(Respondent respondents)
        {
            if (respondents != null)
            {
                dbContext.Respondents.Add(respondents);

                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }



                
                return respondents;
            }
            return null;
        }

        public Respondent UpdateRespondent(Respondent respondents)
        {

            dbContext.Entry(respondents).State = EntityState.Modified;

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }


            
            return respondents;

        }

        public Respondent DeleteRespondent(int Id)
        {

            var respondents = dbContext.Respondents.FirstOrDefault(x => x.Id == Id);
            dbContext.Entry(respondents).State = EntityState.Deleted;

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }


            return respondents;

        }

    }
}
