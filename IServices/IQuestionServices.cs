using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;

namespace WebAPICore.IServices
{
    public interface IQuestionServices
    {
        IEnumerable<Question> GetQuestionService();
        Question AddQuestionService(Question questionService);
        Question UpdateQuestionService(Question questionService);
        Question DeleteQuestion(int id);
    }
}
