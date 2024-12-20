using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
	public class Role
	{
		[Key] // Primary Key olarak tanımlıyoruz.
		public int RoleId { get; set; } // Rol kimlik numarası (örneğin 1 = Admin, 2 = Asistan).
		public string RoleName { get; set; } // Rol adı.

		public ICollection<User> Users { get; set; } // Bir rol birden fazla kullanıcının olabilir. Foreign Key bağlantısını sağlıyoruz.
	}
}
