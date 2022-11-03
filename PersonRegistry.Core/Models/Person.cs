namespace PersonRegistry.Core.Models;

public class Person : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BirthDate { get; set; }
    //public Person? Spouse { get; set; }
}