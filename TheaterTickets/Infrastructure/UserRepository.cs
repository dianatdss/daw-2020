using TheaterTicketsManagement.Models;
using TheaterTicketsManagement.Repositiories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheaterTicketsManagement.Infrastructure
{
    public  class UserRepository
    {
        private readonly TheaterDbContext _context;
        public  DbSet<AppUser> Users { get =>
                _context.Users; 
        }

        public UserRepository(TheaterDbContext context)
        {
            this._context = context;
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
