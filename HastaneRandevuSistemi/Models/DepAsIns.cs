using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class DepAsIns
    {
        [Key]
        public int Id { get; set; }
        public List<Assistant> Assistants { get; set; } // Asistanların bağlantısını sağlıyoruz.
        public List<Department> Departments { get; set; } // Departmanların bağlantısını sağlıyoruz.
        public List<Instructor> Instructors { get; set; } // Öğretim üyelerinin bağlantısını sağlıyoruz.
        public List<Shift> Shifts { get; set; } // Nöbetlerin bağlantısını sağlıyoruz.
    }   
}
