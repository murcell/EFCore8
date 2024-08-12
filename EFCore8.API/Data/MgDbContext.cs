using EFCore8.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore8.API.Data
{
	public class MgDbContext : DbContext
	{
        public MgDbContext(DbContextOptions<MgDbContext> options):base(options)
        {
            
        }

        public DbSet<UserMg> Users { get; set; }
    }
}
