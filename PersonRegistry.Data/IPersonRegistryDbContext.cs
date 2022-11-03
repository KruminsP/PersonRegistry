using Microsoft.EntityFrameworkCore;
using PersonRegistry.Core.Models;

namespace PersonRegistry.Data;

public interface IPersonRegistryDbContext
{
    DbSet<Person> Persons { get; set; }
    DbSet<PersonAddress> Addresses { get; set; }
    DbSet<PhoneNumber> PhoneNumbers { get; set; }
    int SaveChanges();
}