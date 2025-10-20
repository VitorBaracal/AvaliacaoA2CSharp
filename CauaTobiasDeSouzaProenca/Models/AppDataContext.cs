using System;
using Microsoft.EntityFrameworkCore;

namespace CauaTobiasDeSouzaProenca.Models;

public class AppDataContext : DbContext
{
    public DbSet<Sanepar> Sanepar { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=DataBase.db");
    }
}
