using System;
using EntityFrameworkWithoutMigration.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkWithoutMigration.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    /// <summary>
    /// Books-->add,update,get, support linq 
    /// </summary>

    public DbSet<Book> Books => Set<Book>();
}
