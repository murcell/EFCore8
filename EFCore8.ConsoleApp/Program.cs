using EFCore8.ConsoleApp.Data;
using EFCore8.ConsoleApp.Data.ValueGenerator;
using EFCore8.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;


//==================================== Optimistic Concurrency =====================


MgDbContext _context = new();
_context.Database.EnsureDeleted();
_context.Database.EnsureCreated();


UserMg? userMg1 = _context.Users.FirstOrDefault();
userMg1!.Name = "John Doe";


MgDbContext _context2 = new();
UserMg? userMg2 = _context2.Users.FirstOrDefault();
userMg2!.Name = "Mon Do";


_context.SaveChanges();

try
{
	_context2.SaveChanges();
}
catch (DbUpdateConcurrencyException ex)
{
	Console.WriteLine(ex.Message);
	Console.WriteLine(ex.StackTrace);
	Console.WriteLine("Rollback");
	_context2.Entry(userMg2!).Reload();
	userMg2.Name = "Mon Do";
	_context2.SaveChanges();
}


Console.WriteLine("OK");
Console.ReadLine();





//object lockObj = new();
//for (int i = 0; i < 3; i++)
//{
//	Thread tx = new(() =>
//	{
//		try
//		{
//			UserMg? user = _context.Users.FirstOrDefault();
//			if (user != null)
//			{
//				user.Name = "çAtıdaki Keratta";
//				_context.SaveChanges();
//			}

//			Console.WriteLine(user?.Name);
//		}
//		catch (Exception ex)
//		{
//            Console.WriteLine(ex.StackTrace);
//        }
//	});

//}


//UserMg? userMg1 = _context.Users.FirstOrDefault();
//userMg1!.Name = "John Doe";


//MgDbContext _context2 = new();
//UserMg? userMg2 = _context2.Users.FirstOrDefault();
//userMg2!.Name = "Mon Do";


//_context.SaveChanges();

//try
//{
//	_context2.SaveChanges();
//}
//catch (DbUpdateConcurrencyException ex)
//{
//	Console.WriteLine(ex.Message);
//	Console.WriteLine(ex.StackTrace);
//	Console.WriteLine("Rollback");
//	_context2.Entry(userMg2!).Reload();
//	userMg2.Name = "Mon Do";
//	_context2.SaveChanges();
//}


//Console.WriteLine("OK");
//Console.ReadLine();



List<RoleMg> roles = new()
{
	new RoleMg
	{
		Name = "Admin",
	},
	new RoleMg
	{
		Name = "Moderator",

	},
	new RoleMg
	{
		Name = "User"
	},
	new RoleMg
	{
		Name = "Guest"
	}
};

Writer writer = new()
{
	Age = 25,

	Name = "John Doe",
	//Name = new MyNameGenerator().Next(null),

	//Address = new Address
	//{
	//	AddressDetails = new("TR", "Ist")
	//},
	Books = new List<Book>
	{
		new Book
		{
			Name = "Introduction to C#",
			BookType = BookType.Novel


		},
		new Book
		{
			Name = "Data Structures and Algorithms",
			BookType = BookType.Story

		},
		new Book
		{
			Name = "alo melo ",
			BookType = BookType.Poem

		}
	}
	//Roles = roles

};
Writer writer1 = new()
{
	Age = 25,

	Name = "Mon Do",

	//Name = new MyNameGenerator().Next(null),

	//Address = new Address
	//{
	//	AddressDetails = new("FR", "Pr")
	//},
	Books = new List<Book>
	{
		new Book
		{
			Name = "olalala",
			BookType = BookType.Novel

		},
		new Book
		{
			Name = "Tollala",
			BookType = BookType.Story

		},
		new Book
		{
			Name = "follala ",
			BookType = BookType.Poem

		}
	}
	//Roles = roles.Skip(1).ToList()

};







//=============================================== Creatre DB ====================
MgDbContext db = new();
db.Database.EnsureDeleted();
db.Database.EnsureCreated();



//=============================================== Add  Entities =================
db.Writers.Add(writer);
db.SaveChanges();

Thread.Sleep(1000);

db.Writers.Add(writer1);
db.SaveChanges();



//=============================================== Remove Entities =================
//db.Users.Remove(UserMg);
//db.SaveChanges();

//db.Users.Remove(UserMg2);
//db.SaveChanges();



//db.Roles.RemoveRange(roles[0]);
//db.Roles.RemoveRange(roles[1]);
//db.SaveChanges();




//=============================== ManyToMany  Queries==============================

//var users = db.Users.Include(m => m.Roles).Where(m => m.Id == 1).ToList();

//foreach (var item in users)
//{
//	Console.WriteLine(item);
//	foreach (var item2 in item.Roles)
//	{
//		Console.WriteLine(item2);
//	}
//}


//Console.WriteLine("=================");

//List<RoleUser> result = db.RolesUsers.Include(m => m.Role)
//	.Include(m => m.User)
//	.Where(m => m.UserId == 1)
//	.ToList();


//foreach (var item in result)
//{
//	Console.WriteLine(item);
//	Console.WriteLine(item.Role);
//	Console.WriteLine(item.User);
//	Console.WriteLine("====");
//}






//==================================== SQL Raw ====================================
//int minLen = 1;
//var rslt = db.Users.FromSqlRaw($"EXEC getUsers @minLen={minLen}").ToList();
//rslt = db.Users.FromSqlInterpolated($"EXEC getUsers @minLen={minLen}").ToList();
//rslt = db.Users.FromSql($"SELECT * FROM Users  WHERE LEN(Name) > 1;").ToList();







#region MyTries

//MgDbContext _context = new MgDbContext();
//_context.Database.EnsureDeleted();
//_context.Database.EnsureCreated();

//var writer = new Writer()
//{
//	Name = "Dostoyewski",
//	Age = 48,
//	Books = new List<Book>() {
//		new Book { Name = "Suç ve Cezea", PublishYear = 1854, BookType=BookType.Mystery },
//		new Book { Name = "Yeraltından Notlat", PublishYear = 1865, BookType=BookType.ClassicFiction },
//		new Book { Name = "Kumarbaz", PublishYear = 1842, BookType=BookType.Satire },
//		new Book { Name = "İnsancıklar", PublishYear = 1853, BookType=BookType.HistoricalFiction }
//	}
//};

//_context.Writers.Add(writer);
//_context.SaveChanges();

//UserMg user = new UserMg()
//{
//	Name = "Second User",
//	Age = 45,
//	Address = new Address { AddressDetails = new AddressDetails("Dreamland","Patagonya" ) }
//};
//_context.Users.Add(user);
//_context.SaveChanges();
////_context.Users.Remove(user);
////_context.SaveChanges();

//int minLen = 3;
//var result1 =_context.Users.FromSqlRaw($"EXEC getUsers @minLen={minLen}").ToList();
//var result2 = _context.Users.FromSqlInterpolated($"EXEC getUsers @minLen={minLen}").ToList();
//var result3 = _context.Users.FromSql($"SELECT * FROM Users where Len(Name) > 1").ToList();

//// create proc getUsers
//// @minLen INT
//// AS
//// Select * from Users Where LEN(Name) > @minLen; 
#endregion




#region Eski örnekler
////IConfiguration configuration = new ConfigurationBuilder()
////	.SetBasePath(Environment.CurrentDirectory)
////	.AddJsonFile("appsettins.json", optional: true, reloadOnChange: true)
////	.Build();

////  var ops = new DbContextOptionsBuilder<MgDbContext>()
////  .UseSqlServer(configuration.GetConnectionString("EfcoreConStr"))
////	.LogTo(Console.WriteLine, LogLevel.Information)
////	.Options;

////// MgDbContext db = new (ops);
////// db.Database.EnsureDeleted();
////// db.Database.EnsureCreated();

//var services = new ServiceCollection();
////services.AddDbContext<MgDbContext>(options => {
////	new MgDbContext(ops);
////});

//services.AddDbContext<MgDbContext>(options =>
//{
//	IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
//	options.UseSqlServer(configuration.GetConnectionString("EfcoreConStr"));
//	options.LogTo(Console.WriteLine, LogLevel.Information);
//});

//services.AddSingleton<IConfiguration>(cfg =>
//{
//	return new ConfigurationBuilder()
//	.SetBasePath(Environment.CurrentDirectory)
//	.AddJsonFile("appsettins.json", optional: true, reloadOnChange: true)
//	.Build();
//});
//services.AddScoped<UserMgCommands>();
//services.AddScoped<UserMgQueries>();

//ServiceProvider provider = services.BuildServiceProvider();

//MgDbContext db = provider.GetRequiredService<MgDbContext>();
//db.Database.EnsureDeleted();
//db.Database.Migrate();

//UserMgCommands userCommand = provider.GetRequiredService<UserMgCommands>();
//userCommand.AddUser(new UserMg { Name = "User eleven", Age = 11 });

//UserMgQueries userMgQueries = provider.GetRequiredService<UserMgQueries>();
//var usersAll = userMgQueries.GetAllUsers();

//usersAll.ForEach(user => {
//    Console.WriteLine(user.Id + "\t" + user.Name +"\t"+ user.Age);
//}); 
#endregion




