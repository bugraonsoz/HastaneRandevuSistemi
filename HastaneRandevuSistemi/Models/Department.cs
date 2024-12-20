using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
	public class Department
	{
		[Key] // Primary Key olarak DepartmentId'yi atıyoruz.
		public int DepartmentId { get; set; } // Bölüm kimlik numarası (örn. Çocuk Acil, Çocuk Yoğun Bakımı).
		public string Name { get; set; } // Bölümün adı.
		public string Description { get; set; } // Bölümün açıklaması.
		public int Capacity { get; set; } // Yatak kapasitesi veya boş yatak sayısı gibi bilgiler.
		public int CurrentPatient {get; set; } // Mevcut hasta sayısı.
		public ICollection<Assistant> Assistants { get; set; } // Asistanlara Foreign Key bağlantısını sağlıyoruz.
		public ICollection<Instructor> Instructors { get; set; } // Öğretim üyelerine Foreign Key bağlantısını sağlıyoruz.
		public ICollection<Shift> Shifts { get; set; } // Nöbetlere Foreign Key bağlantısını sağlıyoruz.
	}
}
