using Microsoft.AspNetCore.Mvc;
using PersonRegistry.Core.Models;
using PersonRegistry.Core.Services;

namespace PersonRegistry.Controllers
{
    [Microsoft.AspNetCore.Components.Route("addresses")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [Route("addresses")]
        [HttpPost]
        public IActionResult AddAddress(PersonAddress address)
        {
            _addressService.AddAddress(address);

            return Created("", address);
        }
    }
}