using Microsoft.AspNetCore.Mvc;
using PersonRegistry.Core.Models;
using PersonRegistry.Core.Services;

namespace PersonRegistry.Controllers
{
    [Microsoft.AspNetCore.Components.Route("phoneNumbers")]
    [ApiController]
    public class NumberController : Controller
    {
        private readonly IPhoneService _phoneService;

        public NumberController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        [Route("phoneNumbers")]
        [HttpPost]
        public IActionResult AddPhoneNumber(PhoneNumber number)
        {
            _phoneService.Create(number);

            return Created("", number);
        }
    }
}
