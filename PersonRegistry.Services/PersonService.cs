using PersonRegistry.Core.Models;
using PersonRegistry.Data;

namespace PersonRegistry.Core.Services;

public class PersonService : EntityService<Person>, IPersonService
{
    public PersonService(IPersonRegistryDbContext context) : base(context)
    {
    }
}