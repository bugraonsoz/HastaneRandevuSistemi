using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
	public class Assistant
	{
        [Key] // Primary Key olarak tanımlıyoruz.
        public int AssistantID { get; set; } // Asistanın kimlik numarası.
		public string Title { get; set; } // Asistanın Unvanı
        public string NameSurname { get; set; } // Ad-Soyad.
		public string? Image {  get; set; } // Resim.
        public string? Phone { get; set; } // Telefon No.
        public string? Email { get; set; }="noemail@gmail.com"; // Varsayılan Mail Adresi. Kullanıcı olunca zaten kendi emailini girmeli.
		public string? Username { get; set; } // Kullanıcı adını admin panelinde görüntüleyebiliriz.
		public string? Password { get; set; } // Şifreyi admin panelinde görüntüleyebiliriz.
		public int DepartmentID { get; set; } // Asistanın bağlı olduğu bölümün numarası. Foreign Key.
		public Department? Department { get; set; }
		public ICollection<Shift> Shifts { get; set; } // Asistanın yaptığı/yapacağı nöbetin numarası. Foreign Key.
		public ICollection<Appointment> Appointments { get; set; } // Asistanın gireceği randevunun numarası. Foreign Key.
	}
}
