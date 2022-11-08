namespace PersonRegistry.Core.Models;

public class PhoneNumber : Entity
{
    public string Number { get; set; }
    public int User { get; set; }
}