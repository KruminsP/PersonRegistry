using PersonRegistry.Core.Models;
using PersonRegistry.Core.Services;
using PersonRegistry.Data;

namespace PersonRegistry.Services;

public class PhoneService : EntityService<PhoneNumber>, IPhoneService
{
    public PhoneService(IPersonRegistryDbContext context) : base(context)
    {

    }

    public bool Exists(PhoneNumber number)
    {
        return _context.PhoneNumbers.FirstOrDefault(p =>
            p.Number == number.Number) != null;
    }
}