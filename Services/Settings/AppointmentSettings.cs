using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesManagement.Settings
{
    public class AppointmentSettings
    {
        public int CancellationDeadlineHours { get; set; }
        public int NotificationReminderHours { get; set; }
    }
}
