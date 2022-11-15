using PersonRegistry.Core.Models;

namespace PersonRegistry.Core.Validations;

public class NumberValidator
{
    public bool IsValid(PhoneNumber number)
    {
        if (string.IsNullOrEmpty(number.Number) ||
            string.IsNullOrEmpty(number.User))
        {
            return false;
        }

        return true;
    }
}