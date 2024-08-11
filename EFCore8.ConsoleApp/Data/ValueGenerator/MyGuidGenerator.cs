﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore8.ConsoleApp.Data.ValueGenerator
{
	public class MyGuidGenerator : ValueGenerator<Guid>
	{
		public override bool GeneratesTemporaryValues => false;

		public override Guid Next(EntityEntry? entry)
		{
			return Guid.NewGuid();
		}
	}
}
