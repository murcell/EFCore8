using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EFCore8.ConsoleApp.Entities
{
	public class Writer
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        //[Timestamp]
        //public byte[] ConcurencyToken { get; set; } = new byte[8];
        //[Timestamp]
        //public byte[] ConcurencyToken { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
