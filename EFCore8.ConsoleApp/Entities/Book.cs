using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore8.ConsoleApp.Entities
{
	public class Book
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int PublishYear { get; set; }

        public BookType BookType { get; set; }
        public int WriterId { get; set; }
        public Writer Writer { get; set; }
    }
}
