using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore8.ConsoleApp.Data.ValueGenerator
{
	public class MyNameGenerator : ValueGenerator<string>
	{
		// true olursa ilgili property'ye söylememiz gerkiyor
		public override bool GeneratesTemporaryValues => false;

		public override string Next(EntityEntry entry)
		{
			return Guid.NewGuid().ToString().Substring(0,7);
		}
	}
}
