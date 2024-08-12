using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore8.ConsoleApp.Entities
{
	public class Address
	{
        public int AddressId { get; set; }
        // public string Contry { get; set; }

        public AddressDetails AddressDetails { get; set; } = null!;

        // [ForeignKey(nameof(UserMg))] // configte yapacağız
        public int UserId { get; set; }
        public UserMg User { get; set; }
    }
}
