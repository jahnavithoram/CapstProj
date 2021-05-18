using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CapstProj.Models;

namespace CapstProj.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CapstProj.Models.ProductModel> ProductModel { get; set; }
        public DbSet<CapstProj.Models.CartModel> CartModel { get; set; }
    }
}
