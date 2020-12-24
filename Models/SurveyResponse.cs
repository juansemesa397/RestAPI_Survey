using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPICore.Models
{
    public partial class SurveyResponse
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int RespondentId { get; set; }
        public byte[] Updated { get; set; }

        public virtual Respondent Respondent { get; set; }
        public virtual Survey Survey { get; set; }
    }
}
