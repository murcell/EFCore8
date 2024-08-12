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
	public class WriterConfig : IEntityTypeConfiguration<Writer>
	{
		public void Configure(EntityTypeBuilder<Writer> builder)
		{
			builder.ToTable("Writers")
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
				.HasMany(b => b.Books)
				.WithOne(w => w.Writer)
				.HasForeignKey(b => b.WriterId)
				.OnDelete(DeleteBehavior.Cascade);

			//builder
			//	.Property<byte[]>("ConcurrencyToken")
			//	.IsRowVersion()
			//	.IsConcurrencyToken();
			//	//.HasDefaultValue(new byte[8])
			//	//.IsRequired();


			//builder.HasData(new Writer()
			//{
			//	Id = 1,
			//	Name = "Dostoyewski",
			//	Age = 48,
			//	Books = new List<Book>() {
			//		new Book { Name="Suç ve Cezea", PublishYear=1854},
			//		new Book { Name="Yeraltından Notlat", PublishYear=1865},
			//		new Book { Name="Kumarbaz", PublishYear=1842},
			//		new Book { Name="İnsancıklar", PublishYear=1853}
			//	}
			//});
		}
	}
}
