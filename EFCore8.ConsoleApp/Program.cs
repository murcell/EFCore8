using EFCore8.ConsoleApp.Data;

Console.WriteLine("Uygulama başladı!");

//// veri tabanı üretmenin bir yolu, başka yolları da var.
//MgDbContext _context = new MgDbContext();
//_context.Database.EnsureDeleted();
//_context.Database.EnsureCreated();

//var user = _context.Users.FirstOrDefault();
//Console.WriteLine($"ilk user : {user!.Name}");

Console.ReadLine();
