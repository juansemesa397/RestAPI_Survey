using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;

namespace WebAPICore.IServices
{
    public interface IQuestionOrderServices
    {
        IEnumerable <QuestionOrder> UpdateQuestionOrder(int IdSurvey, int PosicionI, int PosicionF);
        IEnumerable<QuestionOrder> GetQuestionOrder();
        IEnumerable<QuestionOrder> InsertQuestionOrder(int question_id, int survey_id, int order);
    }
}
