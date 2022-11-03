using Microsoft.AspNetCore.Mvc;
using PersonRegistry.Models;
using System.Diagnostics;
using PersonRegistry.Core.Models;
using PersonRegistry.Data;

namespace PersonRegistry.Controllers
{
    [Microsoft.AspNetCore.Components.Route("person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRegistryDbContext _context;

        public PersonController(IPersonRegistryDbContext context)
        {
            _context = context;
        }

        [Route("person")]
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();

            return Created("",person);
        }
    }
}