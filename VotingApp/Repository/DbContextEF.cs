using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VotingApp.Entities;

namespace VotingApp.Entities;

public class DbContextEF: DbContext
{
    public DbSet<President> President { get; set; }
   public DbSet<User> User { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
                                                .SetBasePath(Directory.GetCurrentDirectory())
                                                .AddJsonFile("/Users/aser/Documents/revature/project1/appsettings.json")
                                                .Build();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);
        
    }
}