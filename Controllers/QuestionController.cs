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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionServices questionService;

        public QuestionController(IQuestionServices question)
        {
            questionService = question;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Question/GetQuestionService")]
        public IEnumerable<Question> GetQuestionService()
        {
            return questionService.GetQuestionService();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Question/AddQuestionService")]
        public Question AddQuestionService(Question question)
        {
            return questionService.AddQuestionService(question);
        }

        [HttpPut]
        [Route("[action]")]
        [Route("api/Question/UpdateQuestionService")]
        public Question UpdateQuestionService(Question question)
        {
            return questionService.UpdateQuestionService(question);
        }

        [HttpDelete]
        [Route("[action]")]
        [Route("api/Question/DeleteQuestion")]
        public Question DeleteQuestion(int Id)
        {
            return questionService.DeleteQuestion(Id);
        }



    }
}