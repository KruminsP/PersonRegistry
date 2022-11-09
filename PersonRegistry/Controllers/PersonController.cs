using Microsoft.AspNetCore.Mvc;
using PersonRegistry.Core.Models;
using PersonRegistry.Core.Requests;
using PersonRegistry.Core.Services;
using PersonRegistry.Core.Validations;

namespace PersonRegistry.Controllers
{
    [Microsoft.AspNetCore.Components.Route("person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly PersonValidator _personValidator;

        public PersonController(IPersonService persons,
            PersonValidator personValidator)
        {
            _personService = persons;
            _personValidator = personValidator;
        }

        [Route("person")]
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if (!_personValidator.IsValid(person))
            {
                return BadRequest();
            }

            if (_personService.Exists(person))
            {
                return Conflict();
            }

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

            return Ok(request);
        }

        [Route("person/{id}")]
        [HttpDelete]
        public IActionResult Divorce(int id)
        {
            _personService.Divorce(id);
            return Ok();
        }
    }
}