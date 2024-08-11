using EFCore8.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EFCore8.ConsoleApp.Data.DnConfigs
{
	public class UserMgConfig : IEntityTypeConfiguration<UserMg>
	{
		public void Configure(EntityTypeBuilder<UserMg> builder)
		{
			builder.ToTable("Users")
			.HasKey(k => k.Id);

			builder.Property(p => p.Name)
				.HasColumnName("Name")
				.HasColumnType("varchar(50)")
				.IsRequired();

			builder.Property(p => p.Age)
				.HasColumnName("Age")
				.HasColumnType("int")
				.IsRequired();

			builder
				.HasOne(u => u.Address)
				.WithOne(a => a.User)
				.HasForeignKey<Address>(a => a.UserId);

			builder
				.HasMany(u => u.Roles)
				.WithMany(r => r.Users)
				.UsingEntity<RoleUser>(l=>l
									  .HasOne(ru=>ru.Role)
									  .WithMany(r=>r.RoleUsers)
									  //.HasPrincipalKey(rux=>rux.RoleId)
									  .HasForeignKey(ru=>ru.RoleId),
									  //.OnDelete(DeleteBehavior.Cascade),
									  r=>r
									  .HasOne(ru=>ru.User)
									  .WithMany(u=>u.RoleUsers)
									  //.HasPrincipalKey(rux => rux.UserId)
									  .HasForeignKey(ru=>ru.UserId)
									  //.OnDelete(DeleteBehavior.Cascade)
									  //,j=>j.ToTable("RolesUsers")

									  // RoleUserConfig dosyasında HasPrincipalKey ve tablo isimlerini vermeseydik ya da RoleUserConfig sınıfını oluşturmasaydık HasPrincipalKey ve ToTable alanlarını yorumdan kaldırıp bu şekilde de çözebilirdik. Ayrıca  .OnDelete(DeleteBehavior.SetNull) yapmak istersek RoleUser sınıfındaki RoleId ve UserId alanlarını nullable yapmalıyız ve de Id eklemeliyiz

									  );
			 


			builder.HasData(new UserMg()
			{
				Id = 1,
				Name = "First User"
			});
		}
	}
}
