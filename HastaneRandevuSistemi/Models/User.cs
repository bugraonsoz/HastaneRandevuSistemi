using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
	public class User
	{
		[Key] // Primary Key olarak tanımlıyoruz.
        public int UserId { get; set; } // Kullanıcının kimlik numarası
		public string Username { get; set; } // Kullanıcı adı.
		public string Image { get; set; } // Resim.
		public string Email { get; set; } // Kullanıcının e-posta adresi.
		public string Password { get; set; } // Şifre (hashlenmiş).
		public int RoleId { get; set; } // Kullanıcının rol kimliği, Role tablosuna Foreign Key olarak bağlıdır.
		public Role? Role { get; set; }
	}
}
