using Microsoft.AspNetCore.Mvc;
using PersonRegistry.Models;
using System.Diagnostics;
using PersonRegistry.Core.Models;
using PersonRegistry.Core.Services;
using PersonRegistry.Data;

namespace PersonRegistry.Controllers
{
    [Microsoft.AspNetCore.Components.Route("person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _persons;

        public PersonController(IPersonService persons)
        {
            _persons = persons;
        }

        [Route("person")]
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            _persons.Create(person);

            return Created("",person);
        }

        [Route("person")]
        [HttpGet]
        public IActionResult GetAllPersons()
        {
            return Ok(_persons.GetAll());
        }
    }
}