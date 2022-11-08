using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PersonRegistry.Core.Models;

namespace PersonRegistry.Data;

public interface IPersonRegistryDbContext
{
    DbSet<T> Set<T>() where T : class;
    EntityEntry<T> Entry<T>(T entity) where T : class;
    DbSet<Person> Persons { get; set; }
    DbSet<PersonAddress> Addresses { get; set; }
    DbSet<PhoneNumber> PhoneNumbers { get; set; }
    int SaveChanges();
}