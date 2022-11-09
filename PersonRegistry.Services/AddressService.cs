using PersonRegistry.Core.Models;
using PersonRegistry.Core.Services;
using PersonRegistry.Data;

namespace PersonRegistry.Services;

public class AddressService : EntityService<PersonAddress>, IAddressService
{
    public AddressService(IPersonRegistryDbContext context) : base(context)
    {
    }

    public void AddAddress(PersonAddress address) //changes all other addresses to non primary
    {
        if (address.Primary)
        {
            foreach (var a in _context.Addresses)
            {
                if (a.User == address.User)
                {
                    a.Primary = false;
                }
            }
        }

        _context.Addresses.Add(address);
        _context.SaveChanges();
    }

    public PersonAddress GetAddressByPersonId(int id)
    {
        var address = _context.Addresses.FirstOrDefault(a => a.User == id);

        return address;
    }
}