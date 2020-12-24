using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPICore.Models
{
    public partial class Survey
    {
        public Survey()
        {
            SurveyResponses = new HashSet<SurveyResponse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public byte[] Updated { get; set; }

        public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }
    }
}
