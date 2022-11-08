using PersonRegistry.Core.Models;
using PersonRegistry.Core.Requests;
using PersonRegistry.Core.Services;
using PersonRegistry.Data;

namespace PersonRegistry.Services;

public class PersonService : EntityService<Person>, IPersonService
{
    public PersonService(IPersonRegistryDbContext context) : base(context)
    {
    }

    public void ChangeMaritalStatus(ChangeMaritalStatusRequest request)
    {
        var first = _context.Persons.SingleOrDefault(p => p.Id == request.FirstPersonId);
        var second= _context.Persons.SingleOrDefault(p => p.Id == request.SecondPersonId);

        if (first != null && second != null && first != second)
        {
            if (!first.IsMarried && !second.IsMarried)
            {
                first.IsMarried = true;
                second.IsMarried = true;
                first.SpouseId = second.Id;
                second.SpouseId = first.Id;
            }
            else if (first.IsMarried &&
                     second.IsMarried &&
                     first.SpouseId == second.Id &&
                     second.SpouseId == first.Id)
            {
                first.IsMarried = false;
                second.IsMarried = false;
                first.SpouseId = null;
                second.SpouseId = null;
            }
        }

        _context.SaveChanges();
    }
}