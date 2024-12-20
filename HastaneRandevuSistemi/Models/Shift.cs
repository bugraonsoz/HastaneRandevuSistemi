using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
	public class Shift
	{
		[Key] // Primary Key olarak tanımlıyoruz.
		public int ShiftId { get; set; } // Nöbet kimlik numarası.
		public int AssistantId { get; set; } // Nöbetteki asistanın kimlik numarası.
		public Assistant? Assistant { get; set; } // Foreign Key bağlantısı.
		public int DepartmentId { get; set; } // Nöbetin tutulduğu bölümün kimlik numarası.
		public Department? Department { get; set; } // Foreign Key bağlantısı.
		public DateTime ShiftDate { get; set; } // Nöbetin yapıldığı tarih.
		public string ShiftDuration { get; set; } // Nöbetin süresi(Saat,Dakika).
	}
}
