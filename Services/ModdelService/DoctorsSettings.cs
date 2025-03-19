using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesManagement.ModdelService
{
    public class DoctorsSettings
    {
        public WorkTime WorkTime { get; set; }
    }
    public class WorkTime
    {
        public TimeOnly End { get; set; }
        public TimeOnly Start { get; set; }
    }
}
