using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;
using WebAPICore.Services;

namespace WebAPICore.IServices
{
    public interface ISurveyResponseServices
    {
        IEnumerable<SurveyResponse> GetSurveyResponse();
        SurveyResponse AddSurveyResponse(SurveyResponse surveyResponse);
        SurveyResponse UpdateSurveyResponse(SurveyResponse surveyResponse);
        SurveyResponse DeleteSurveyResponse(int id);
    }
}
