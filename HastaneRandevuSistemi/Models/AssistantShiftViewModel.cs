using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class AssistantShiftViewModel
    {
        [Key]
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }
        public DateTime ShiftDate { get; set; }
        public string ShiftDuration { get; set; }
    }
}
