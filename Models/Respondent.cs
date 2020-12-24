﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPICore.Models
{
    public partial class Respondent
    {
        public Respondent()
        {
            SurveyResponses = new HashSet<SurveyResponse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Hashedpassword { get; set; }
        public string Email { get; set; }
        public byte[] Created { get; set; }

        public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }
    }
}
