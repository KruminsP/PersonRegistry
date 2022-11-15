using PersonRegistry.Core.Models;
using PersonRegistry.Core.Services;
using PersonRegistry.Data;
using System.Net;

namespace PersonRegistry.Services;

public class PhoneService : EntityService<PhoneNumber>, IPhoneService
{
    public PhoneService(IPersonRegistryDbContext context) : base(context)
    {

    }

    public void AddPhone(PhoneNumber number)
    {
        _context.PhoneNumbers.Add(number);
        _context.SaveChanges();
    }
}