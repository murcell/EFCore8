using EFCore8.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore8.ConsoleApp.Data.DnConfigs
{
	public class RoleUserConfig : IEntityTypeConfiguration<RoleUser>
	{
		public void Configure(EntityTypeBuilder<RoleUser> builder)
		{
			builder.ToTable("RolesUsers")
			//.HasKey(k => k.Id);
			.HasKey(k => new { k.RoleId, k.UserId });

		}
	}
}
