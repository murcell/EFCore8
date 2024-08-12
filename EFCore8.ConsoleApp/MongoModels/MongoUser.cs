using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore8.ConsoleApp.MongoModels
{
	public class MongoUser
	{
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public MongoAddress? MongoAddress { get; set; }
		public List<MongoAddress> MongoAddresses { get; set; } = null!;
	}
}
