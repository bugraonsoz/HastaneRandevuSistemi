using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class CalendarViewModel
    {
        [Key]
        public int Id { get; set; }
        public List<Shift> Shifts { get; set; }
        public List<Assistant> Assistants { get; set; }
        public List<Instructor> Instructors { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
