using Microsoft.AspNetCore.Mvc;
using PersonRegistry.Core.Models;
using PersonRegistry.Core.Requests;
using PersonRegistry.Core.Services;

namespace PersonRegistry.Controllers
{
    [Microsoft.AspNetCore.Components.Route("person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService persons)
        {
            _personService = persons;
        }

        [Route("person")]
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            _personService.Create(person);

            return Created("", person);
        }

        [Route("person")]
        [HttpGet]
        public IActionResult GetAllPersons()
        {
            return Ok(_personService.GetAll());
        }

        [Route("person")]
        [HttpPut]
        public IActionResult ChangeMaritalStatus(ChangeMaritalStatusRequest request)
        {
            _personService.ChangeMaritalStatus(request);

            return Ok();
        }
    }
}