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

			builder.HasData(new UserMg()
			{
				Id = 1,
				Name = "First User"
			});
		}
	}
}
