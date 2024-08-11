using EFCore8.ConsoleApp.Data.ValueGenerator;
using EFCore8.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

			// eski ifade 
			builder
				.ComplexProperty(k => k.AddressDetails)
				.Property(ad=>ad.Country)
				.HasColumnName("Country")
				.HasColumnType("varchar(50)")
				
				.IsRequired();

			builder
				.ComplexProperty(k => k.AddressDetails)
				.Property(ad => ad.City)
				.HasColumnName("Country")
				.HasColumnType("City(50)")
				.IsRequired();

			builder
				.Property<DateTime>("CreatedDate")
				.HasColumnType("datetime")
				//.HasDefaultValue(DateTime.Now)
				//.HasDefaultValueSql("getdate()")
				.HasValueGenerator<MyDateGenerator>()
				.IsRequired();

			//yeni ifade
			//builder.OwnsOne(u => u.AddressDetails, a => {

			//	a.Property(ad => ad.Country)
			//	.HasColumnName("Country")
			//	.HasColumnType("varchar(50)")
			//	.IsRequired();

			//	a.Property(ad => ad.City)
			//	.HasColumnName("Country")
			//	.HasColumnType("City(50)")
			//	.IsRequired();

			//});

			//builder
			//	.Property(k => k.Contry)
			//	.HasColumnName("Name")
			//	.HasColumnType("varchar(100)")
			//	.IsRequired();

			//builder
			//	.HasOne(u => u.User)
			//	.WithOne(a => a.Address)
			//	.HasForeignKey<Address>(a => a.UserId);



		}
	}
}
