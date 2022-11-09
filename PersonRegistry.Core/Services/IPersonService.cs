using PersonRegistry.Core.Models;
using PersonRegistry.Core.Requests;

namespace PersonRegistry.Core.Services;

public interface IPersonService : IEntityService<Person>
{
    void ChangeMaritalStatus(ChangeMaritalStatusRequest request);
    bool Exists(Person person);
}