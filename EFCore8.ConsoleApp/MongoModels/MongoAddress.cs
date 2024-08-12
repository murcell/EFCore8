using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore8.ConsoleApp.MongoModels
{
	public class MongoAddress
	{
		public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
		public string PostalCode { get; set; } = null!;

		public override string ToString()
		{
			return $"City: {City}, Street: {Street}, PostalCode {PostalCode},";
		}
	}
}
