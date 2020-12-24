using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;
using WebAPICore.Services;

namespace WebAPICore.IServices
{
    public interface ISurveyService
    {
        IEnumerable<Survey> GetSurveyService();
        Survey AddSurveyService(Survey surveyService);
        Survey UpdateService(Survey surveyService);
        Survey DeleteSurvey(int id);
    }
}
