using PersonRegistry.Core.Models;

namespace PersonRegistry.Core.Services;

public interface IAddressService : IEntityService<PersonAddress>
{
    void AddAddress(PersonAddress address);
    int GetIdByName(AddAddressQuery request);
}