using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class AppointmentInfos
    {
        [Key]
        public int Id { get; set; }
        public string AssistantName { get; set; }
        public string AssistantTitle { get; set; }
        public string InstructorName { get; set; }
        public string InstructorTitle { get; set; }
        public string TimeSlot { get; set; }
        public DateTime MeetDate { get; set; }

    }
}
