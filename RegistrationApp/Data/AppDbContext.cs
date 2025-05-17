﻿using Microsoft.EntityFrameworkCore;
using RegistrationApp.Models;

namespace RegistrationApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> Users { get; set; }
    }
}
