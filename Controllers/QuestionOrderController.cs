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
    public class QuestionOrderController : ControllerBase
    {
        private readonly IQuestionOrderServices questionOrder;

        public QuestionOrderController(IQuestionOrderServices questionO)
        {
            questionOrder = questionO;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/QuestionOrder/UpdateQuestionOrder")]

        public IEnumerable<QuestionOrder> UpdateQuestionOrder(int IdSurvey, int PosicionI, int PosicionF)
        {
            return questionOrder.UpdateQuestionOrder(IdSurvey, PosicionI, PosicionF);
        
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/QuestionOrder/InsertQuestionOrder")]
        public IEnumerable<QuestionOrder> InsertQuestionOrder(int question_id, int survey_id, int order)
        {
            return questionOrder.InsertQuestionOrder(question_id, survey_id, order);
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/QuestionOrder/GetQuestionOrder")]
        public IEnumerable<QuestionOrder> GetQuestionOrder()
        {
            return questionOrder.GetQuestionOrder();
        }

    }
}