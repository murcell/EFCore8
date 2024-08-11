using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore8.ConsoleApp.Entities
{
	//[Table("Users")]
	public class UserMg
	{
		// bu şekillerde verdiğimizde ef
		// tanıyor ve primary key olarak set ediyor
		//[Key]
		//[Column("Id")]
	    //public int UserID { get; set; }
		public int Id { get; set; }
		//[Column("Name", TypeName = "varchar(75)")]
		public string Name { get; set; } = null!;

        public int Age { get; set; }

		public Address Address { get; set; } = null!;

		public ICollection<RoleMg> Roles { get; set; } = new HashSet<RoleMg>();

		public ICollection<RoleUser> RoleUsers { get; set; } = new HashSet<RoleUser>();
	}
}
