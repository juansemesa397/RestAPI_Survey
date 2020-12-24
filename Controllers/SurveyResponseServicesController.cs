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
    public class SurveyResponseServicesController : ControllerBase
    {
        private readonly ISurveyResponseServices surveyResponseServices;

        public SurveyResponseServicesController(ISurveyResponseServices surveyresponse)
        {
            surveyResponseServices = surveyresponse;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/SurveyResponse/GetSurveyResponse")]
        public IEnumerable<SurveyResponse> GetSurveyResponse()
        {
            return surveyResponseServices.GetSurveyResponse();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/SurveyResponse/AddSurveyResponse")]
        public SurveyResponse AddSurveyResponse(SurveyResponse surveyresponse)
        {
            return surveyResponseServices.AddSurveyResponse(surveyresponse);
        }

        [HttpPut]
        [Route("[action]")]
        [Route("api/SurveyResponse/UpdateSurveyResponse")]
        public SurveyResponse UpdateSurveyResponse(SurveyResponse surveyresponse)
        {
            return surveyResponseServices.UpdateSurveyResponse(surveyresponse);
        }

        [HttpDelete]
        [Route("[action]")]
        [Route("api/SurveyResponse/DeleteSurvey")]
        public SurveyResponse DeleteSurvey(int Id)
        {
            return surveyResponseServices.DeleteSurveyResponse(Id);
        }

    }
}