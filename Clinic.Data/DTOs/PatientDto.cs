using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Data.DTOs
{
    public class PatientDto
    {     
         public string Name { get; set; } = string.Empty;

        public string Telephone { get; set; } = string.Empty;

        public string NIF { get; set; } = string.Empty;

        public int SocialNumber { get; set; }

        public int CollegueNumber { get; set; }

        public string StartDate { get; set; } = string.Empty;

        public string EndDate { get; set; } = string.Empty;

        public string PositionName { get; set; } = string.Empty;
    }
}

