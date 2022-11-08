using PersonRegistry.Core.Models;
using PersonRegistry.Core.Services;
using PersonRegistry.Data;

namespace PersonRegistry.Services;

public class PersonService : EntityService<Person>, IPersonService
{
    public PersonService(IPersonRegistryDbContext context) : base(context)
    {
    }
}