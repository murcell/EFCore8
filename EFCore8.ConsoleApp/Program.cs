using EFCore8.ConsoleApp.Data;
using EFCore8.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Uygulama başladı!");

//// veri tabanı üretmenin bir yolu, başka yolları da var.
//MgDbContext _context = new MgDbContext();
//_context.Database.EnsureDeleted();
//_context.Database.EnsureCreated();
//var user = _context.Users.FirstOrDefault();
//Console.WriteLine($"ilk user : {user!.Name}");

//DBCreate();

#region ChangeTracking

//UserMg user = new UserMg()
//{
//	Name = "Fourth User",
//	Age = 33
//};

//using (var db = new MgDbContext())
//{
//	var entry = db.Entry(user);
//	db.Entry(user).State = EntityState.Added;
//	entry = db.Entry(user);
//	db.SaveChanges();

//	user.Name = "Fourth User Updated";
//	entry = db.Entry(user);
//	db.SaveChanges();
//}



//using (var db = new MgDbContext())
//{
//	// var user = db.Users.FirstOrDefault();
//	var user = db.Users.AsNoTracking().FirstOrDefault();

//	var entries = db.ChangeTracker.Entries();
//	foreach ( var entry in entries)
//	{
//		Console.WriteLine(entry);
//	}

//}

//Console.WriteLine($"{user.Id}'li user eklenmiştir."); 
#endregion

Console.ReadLine();



void DBCreate()
{
	using var db = new MgDbContext();
	db.Database.EnsureDeleted();
	db.Database.EnsureCreated();
}