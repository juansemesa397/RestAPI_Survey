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
    public class RespondentController : ControllerBase
    {
        private readonly IRespondentServices respondentServices;

        public RespondentController(IRespondentServices respondent)
        {
            respondentServices = respondent;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Respondent/GetRespondent")]
        public IEnumerable<Respondent> GetRespondent()
        {
            return respondentServices.GetRespondent();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Respondent/AddRespondent")]
        public Respondent AddRespondent(Respondent respondent)
        {
            return respondentServices.AddRespondent(respondent);
        }

        [HttpPut]
        [Route("[action]")]
        [Route("api/Respondent/UpdateRespondent")]
        public Respondent UpdateRespondent(Respondent respondent)
        {
            return respondentServices.UpdateRespondent(respondent);
        }

        [HttpDelete]
        [Route("[action]")]
        [Route("api/Respondent/DeleteRespondent")]
        public Respondent DeleteRespondent(int Id)
        {
            return respondentServices.DeleteRespondent(Id);
        }

    }
}

   