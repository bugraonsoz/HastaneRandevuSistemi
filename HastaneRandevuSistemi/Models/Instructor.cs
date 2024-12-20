using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
	public class Instructor
	{
		[Key] // Primary Key tanımlıyoruz.
		public int InstructorID { get; set; } // Öğretim üyesinin kimlik numarası.
		public string Title { get; set; } // Unvan.
		public string NameSurname { get; set; } // Ad-Soyad.
		public string? Image { get; set; } // Resim.
		public string? Phone { get; set; } // Telefon No.
		public string? Email { get; set; } // Mail Adresi.
		public string? Username { get; set; } // Kullanıcı adını admin panelinde görüntüleyebiliriz.
		public string? Password { get; set; } // Şifreyi admin panelinde görüntüleyebiliriz.
		public int DepartmentID { get; set; } // Öğretim üyesinin bağlı olduğu bölümün numarası. Foreign Key.
		public Department? Department { get; set; }
		public ICollection<Appointment> Appointments { get; set; } // Öğretim Üyesinin gireceği randevunun numarası. Foreign Key.
	}
}
