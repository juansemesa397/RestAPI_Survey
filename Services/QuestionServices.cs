using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.IServices;
using WebAPICore.Models;

namespace WebAPICore.Services
{
    public class QuestionServices: IQuestionServices
    {
        BD_SurveyContext dbContext;

        public QuestionServices(BD_SurveyContext _db)
        {
            dbContext = _db;
        }

        public IEnumerable<Question> GetQuestionService()
        {
            var Questions = dbContext.Questions.ToList();
            return Questions;

        }

        public Question AddQuestionService(Question question)
        {
            if (question != null)
            {
                dbContext.Questions.Add(question);

                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }


                return question;
            }
            return null;
        }

        public Question UpdateQuestionService(Question question)
        {

            dbContext.Entry(question).State = EntityState.Modified;
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            return question;

        }

        public Question DeleteQuestion(int Id)
        {

            var question = dbContext.Questions.FirstOrDefault(x => x.Id == Id);
            dbContext.Entry(question).State = EntityState.Deleted;
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            return question;

        }
    }
}
