using System;
using Microsoft.EntityFrameworkCore;


public class ApplicationDbContext : DbContext {
    public DbSet<Despesas> Despesa { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer("Server=regulus.cotuca.unicamp\\SQL2019;Database=BD23015;User Id=BD23015;Password=BD23015;");
    }
}


