using PersonRegistry.Core.Models;

namespace PersonRegistry.Core.Validations;

public class AddressValidator
{
    public bool IsValid(PersonAddress address)
    {
        if (string.IsNullOrEmpty(address.Address) ||
            address.Primary == null ||
            address.User == null)
        {
            return false;
        }

        return true;
    }
}