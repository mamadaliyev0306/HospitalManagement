using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityManagement.DataAcces
{
    [Table("PatientBlank",Schema ="DataAcces")]
    public class PatientBlank
    {
        public int PatientBlankId { get; set; }

        public string BlankIdentifier { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
        public  int PatientId { get; set; }
        public Patient Patient { get; set; }
    }

}
