namespace PersonRegistry.Core.Models;

public class Person : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BirthDate { get; set; }
    public bool IsMarried { get; set; }
    public int? SpouseId { get; set; }

    public Person()
    {
        IsMarried=false;
    }
}