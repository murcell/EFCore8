using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore8.ConsoleApp.Entities
{
	public class RoleMg
	{
        public int Id { get; set; }
        public string Name { get; set; } = null!;

		public ICollection<UserMg> Users { get; set; } = new HashSet<UserMg>();
		public ICollection<RoleUser> RoleUsers { get; set; } = new HashSet<RoleUser>();
	}
}
