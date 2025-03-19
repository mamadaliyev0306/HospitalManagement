using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityManagement.DataAcces
{
    [Table("Speciality",Schema ="DataAcces")]
    public class Speciality
    {
        public int SpecialityId { get; set; }

        public string Name { get; set; }
    }
}
