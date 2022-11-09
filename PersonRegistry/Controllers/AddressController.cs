using Microsoft.AspNetCore.Mvc;
using PersonRegistry.Core.Models;
using PersonRegistry.Core.Services;
using PersonRegistry.Core.Validations;

namespace PersonRegistry.Controllers
{
    [Microsoft.AspNetCore.Components.Route("address")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly AddressValidator _addressValidator;

        public AddressController(IAddressService addressService,
            AddressValidator addressValidator)
        {
            _addressService = addressService;
            _addressValidator = addressValidator;
        }

        [Route("address")]
        [HttpPost]
        public IActionResult AddAddress(PersonAddress address)
        {
            if (!_addressValidator.IsValid(address))
            {
                return BadRequest();
            }

            _addressService.AddAddress(address);

            return Created("", address);
        }

        [Route("address/{id}")]
        [HttpGet]
        public IActionResult GetAddressByPersonId(int id)
        {
            var address = _addressService.GetAddressByPersonId(id);

            return Ok(address);
        }
    }
}