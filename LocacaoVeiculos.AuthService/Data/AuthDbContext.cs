﻿using LocacaoVeiculos.AuthService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LocacaoVeiculos.AuthService.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
