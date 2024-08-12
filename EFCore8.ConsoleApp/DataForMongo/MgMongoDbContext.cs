using EFCore8.ConsoleApp.MongoModels;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore8.ConsoleApp.DataForMongo
{
	public class MgMongoDbContext : DbContext
	{
        public DbSet<MongoUser> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMongoDB("mongodb://127.0.0.1:27017","mgDB");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<MongoUser>(m =>
			{
				m.ToCollection("Users");
				m.Property(x => x.Name).HasElementName("firstName");
			});
		}
	}
}
