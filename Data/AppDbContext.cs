using System;
using System.Security.Cryptography.X509Certificates;
using backend.Models;
using Microsoft.EntityFrameworkCore;
namespace backend.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)

  {

  }
      public DbSet<Transaction> Transactions { get; set; }
      public DbSet<Category> Categories { get; set; }
}
