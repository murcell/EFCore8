﻿using EFCore8.ConsoleApp.Data.ValueConverters;
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
	public class BookConfig : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder
				.ToTable("Books")
				.HasKey(k => k.Id);

			builder
				.Property(k => k.Name)
				.HasColumnName("Name")
				.HasColumnType("varchar(100)")
				.IsRequired();

			builder
				.Property(k => k.PublishYear)
				.HasColumnName("PublishYear")
				.HasColumnType("int")
				.IsRequired();

			builder
				.Property(u => u.BookType)
				.HasColumnType("varchar(100)")
				//HasConversion güzel bir özellik
				//.HasConversion(v => v.ToString(), // when create
							  // vv => (BookType)Enum.Parse(typeof(BookType), vv)) // when read
				.HasConversion<MyEnumConverter>()
				.IsRequired();


		}
	}
}
