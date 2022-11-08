namespace PersonRegistry.Core.Requests
{
    public class ChangeMaritalStatusRequest
    {
        public int FirstPersonId { get; set; }
        public int SecondPersonId { get; set; }
    }
}
