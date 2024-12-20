using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
	public class Emergency
	{
		[Key] // Primary Key olarak tanımlıyoruz.
		public int ShiftId { get; set; } // Acil durum bildirimi kimlik numarası.
		public string Title { get; set; } // Acil durum başlığı.
		public string Description { get; set; } // Acil durum açıklaması.
		public DateTime SendDate { get; set; } // Acil durumun bildirildiği tarih.
		public string DepartmentName {  get; set; } // Acil durumun bağlı olduğu bölümün adı.
    }
}
