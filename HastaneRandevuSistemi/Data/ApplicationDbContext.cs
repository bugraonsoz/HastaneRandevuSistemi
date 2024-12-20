using HastaneRandevuSistemi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HastaneRandevuSistemi.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Assistant> Assistants { get; set; }
		public DbSet<Instructor> Instructors { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Shift> Shifts { get; set; }
		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<Emergency> Emergencies { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<DepAsIns> DepAsInss { get; set; }
		public DbSet<AssistantShiftViewModel> AssistantShiftViewModel { get; internal set; }
		public DbSet<CalendarViewModel> calendarViewModels { get; internal set; }
		public DbSet<AppointmentInfos> appointmentInfos  { get; internal set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-TC3KKGK\\SQLEXPRESS;Initial Catalog=HastaneDb;Integrated Security=true;TrustServerCertificate=True;Trusted_Connection=True;");
		}
	}

}
