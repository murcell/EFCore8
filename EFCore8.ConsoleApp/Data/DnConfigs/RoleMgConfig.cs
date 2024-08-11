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
	public class RoleMgConfig : IEntityTypeConfiguration<RoleMg>
	{
		public void Configure(EntityTypeBuilder<RoleMg> builder)
		{
			builder.ToTable("Roles")
			.HasKey(k => k.Id);

			builder.Property(p => p.Name)
				.HasColumnName("Name")
				.HasColumnType("varchar(50)")
				.IsRequired();

			

		}
	}
}
