using EFCore8.ConsoleApp.Data.DnConfigs;
using EFCore8.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Reflection;

namespace EFCore8.ConsoleApp.Data
{
	public class MgDbContext : DbContext
	{
        public MgDbContext(DbContextOptions<MgDbContext> opt):base(opt)
        {
            
        }
        public DbSet<UserMg> Users { get; set; }

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	//optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EFCoreEducation; User=sa; Password=Pass1234.?;TrustServerCertificate=True");
		//	//optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
		//}


		// Coloum ayarlarını yapmanın ilk yolu OnModelCreating
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.ApplyConfiguration(new UserMgConfig());
			//modelBuilder.ApplyConfiguration(new Address());
			//modelBuilder.ApplyConfiguration(new Product());

			//// birden fazla config sını olduğunda hepsini tek tek eklmek 
			///yerine bu şekilde ekleyebiliriz
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			#region ConfigureTableAndColumns
			////UserMgConfig'e taşıdık 
			//modelBuilder.Entity<UserMg>()
			//	.ToTable("Users")
			//	.HasKey(h => h.UserID);

			//modelBuilder.Entity<UserMg>()
			//	.Property(h => h.UserID)
			//	.HasColumnName("Id");

			//modelBuilder.Entity<UserMg>()
			//	.Property(h => h.Name)
			//	.HasColumnName("Name")
			//	.HasColumnType("varchar(50)")
			//	.IsRequired(); 
			#endregion

		}
	}
}
