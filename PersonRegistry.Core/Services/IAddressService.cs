using PersonRegistry.Core.Models;

namespace PersonRegistry.Core.Services;

public interface IAddressService : IEntityService<PersonAddress>
{
    void AddAddress(PersonAddress address);
    PersonAddress GetAddressByPersonId(int id);
}