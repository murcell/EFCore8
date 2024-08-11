using EFCore8.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore8.ConsoleApp.Data.DnConfigs
{
	public class AddressConfig : IEntityTypeConfiguration<Address>
	{
		public void Configure(EntityTypeBuilder<Address> builder)
		{
			builder
				.ToTable("Adresses")
				.HasKey(k => k.AddressId);

			builder
				.Property(k => k.Contry)
				.HasColumnName("Name")
				.HasColumnType("varchar(100)")
				.IsRequired();

			//builder
			//	.HasOne(u => u.User)
			//	.WithOne(a => a.Address)
			//	.HasForeignKey<Address>(a => a.UserId);


		}
	}
}
