using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PersonRegistry.Core.Models;

namespace PersonRegistry.Data;

public class PersonRegistryDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<Person> Persons { get; set; }
    public DbSet<PersonAddress> Addresses { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }

    public PersonRegistryDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_configuration.GetConnectionString("person-registry"));
    }
}