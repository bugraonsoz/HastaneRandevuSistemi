using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
	public class Appointment
	{
		[Key] // Primary Key olarak tanımlıyoruz.
		public int AppointmentId { get; set; } // Randevu kimlik numarası.
		public int AssistantId { get; set; } // Randevudaki asistanın kimlik numarası.
		public Assistant? Assistant { get; set; } //Foreign Key bağlantısı.
		public int InstructorId { get; set; } // Randevunun gerçekleştiren öğretim üyesinin kimlik numarası.
		public Instructor? Instructor { get; set; } // Foreign Key bağlantısı.
		public DateTime ShiftDate { get; set; } // Randevunun yapıldığı tarih.
		public string TimeSlot { get; set; } // Randevu zamanı(Örneğin 13.00-13.30).
	}
}
