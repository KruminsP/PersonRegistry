using PersonRegistry.Core.Models;

namespace PersonRegistry.Core.Services;

public interface IPhoneService : IEntityService<PhoneNumber>
{
    bool Exists(PhoneNumber number);
}

