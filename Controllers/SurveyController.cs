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
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService surveyService;

        public SurveyController(ISurveyService survey)
        {
            surveyService = survey;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Survey/GetSurveyService")]
        public IEnumerable<Survey> GetSurveyService()
        {
            return surveyService.GetSurveyService();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Survey/AddSurveyService")]
        public Survey AddSurveyService(Survey survey)
        {
            return surveyService.AddSurveyService(survey);
        }

        [HttpPut]
        [Route("[action]")]
        [Route("api/Survey/UpdateService")]
        public Survey UpdateService(Survey survey)
        {
            return surveyService.UpdateService(survey);
        }

        [HttpDelete]
        [Route("[action]")]
        [Route("api/Survey/DeleteSurvey")]
        public Survey DeleteSurvey(int Id)
        {
            return surveyService.DeleteSurvey(Id);
        }


    }
}