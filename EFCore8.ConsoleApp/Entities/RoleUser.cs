using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore8.ConsoleApp.Entities
{
	public class RoleUser
	{
        //public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public RoleMg Role { get; set; } = null!;
        public UserMg User { get; set; } = null!;
    }
}
