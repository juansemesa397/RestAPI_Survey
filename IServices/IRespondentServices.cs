using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;

namespace WebAPICore.IServices
{
    public interface IRespondentServices
    {
        IEnumerable<Respondent> GetRespondent();
        Respondent AddRespondent(Respondent surveyService);
        Respondent UpdateRespondent(Respondent surveyService);
        Respondent DeleteRespondent(int id);
    }
}
