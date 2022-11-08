namespace PersonRegistry.Core.Models;

public class PersonAddress : Entity
{
    public string Address { get; set; }
    public int User { get; set; }
    public bool Primary { get; set; }

}