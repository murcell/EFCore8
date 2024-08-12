using EFCore8.ConsoleApp.Data;
using EFCore8.ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCore8.ConsoleApp.Repository
{
	public class UserMgQueries
	{
		private readonly MgDbContext _context;

		public UserMgQueries(MgDbContext context)
		{
			_context = context;
		}

		public UserMg? GetUser(int id)
		{
			using (_context)
			{
				return _context.Users.FirstOrDefault(u => u.Id == id);
			}
		}

		public List<UserMg> GetAllUsers()
		{
			
			return _context.Users.ToList();
			
		}

		public List<UserMg> GetUsers(string name)
		{
			using (_context)
			{
				return _context.Users.Where(u=>u.Name==name).ToList();
			}
		}

		public List<UserMg> GetUsers(int page=1, int pageSize=10)
		{
			using (_context)
			{
				return _context.Users.Skip((page - 1* pageSize)).Take(pageSize).ToList();
			}
		}

		public List<UserMg> GetUsesr(Expression<Func<UserMg,bool>> exp)
		{
			using (_context)
			{
				return _context.Users.Where(exp).ToList();
			}
		}

	}
}
