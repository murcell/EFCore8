using EFCore8.ConsoleApp.Data;
using EFCore8.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore8.ConsoleApp.Repository
{
	public class UserMgRepository
	{
		private readonly MgDbContext _context;

		public UserMgRepository(MgDbContext context)
		{
			_context = context;
		}

		public void AddUser(UserMg user)
		{
			using (_context)
			{
				//_context.Users.Add(user);
				_context.Entry(user).State = EntityState.Added;
				_context.SaveChanges();
			}
		}

		public void UpdateUser(UserMg user)
		{
			using (_context)
			{
				UserMg? updatedUser = _context.Users.FirstOrDefault(u => u.Name == user.Name);

				if (updatedUser != null) 
				{
					updatedUser.Name = user.Name;
					updatedUser.Age = user.Age;

					_context.SaveChanges();
				}

				_context.Users.Update(user);
				//_context.Entry(user).State = EntityState.Modified;
				_context.SaveChanges();
			}
		}

		public void DeleteUser(UserMg user)
		{
			using (_context)
			{
				UserMg? deletedUser = _context.Users.FirstOrDefault(u => u.Name == user.Name);

				if (deletedUser != null)
				{
					_context.Users.Remove(deletedUser);
					_context.SaveChanges();
				}
			}
		}
	}
}
