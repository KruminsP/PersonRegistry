using PersonRegistry.Core.Models;

namespace PersonRegistry.Core.Validations;

public class PersonValidator
{
    public bool IsValid(Person person)
    {
        if (string.IsNullOrEmpty(person.LastName) ||
            string.IsNullOrEmpty(person.FirstName) ||
            string.IsNullOrEmpty(person.BirthDate))
        {
            return false;
        }

        return true;
    }
}