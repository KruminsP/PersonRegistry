using Microsoft.AspNetCore.Mvc;
using PersonRegistry.Core.Models;
using PersonRegistry.Core.Services;
using PersonRegistry.Core.Validations;

namespace PersonRegistry.Controllers
{
    [Microsoft.AspNetCore.Components.Route("number")]
    [ApiController]
    public class NumberController : Controller
    {
        private readonly IPhoneService _phoneService;
        private readonly NumberValidator _numberValidator;

        public NumberController(IPhoneService phoneService,
        NumberValidator numberValidator)
        {
            _phoneService = phoneService;
            _numberValidator = numberValidator;
        }

        [Route("number")]
        [HttpPost]
        public IActionResult AddPhoneNumber(PhoneNumber[] numbers)
        {
            if (numbers.Length < 1)
            {
                return BadRequest();
            }

            foreach (var number in numbers)
            {
                if (_numberValidator.IsValid(number))
                {
                    _phoneService.AddPhone(number);
                }
            }

            return Created("", numbers);
        }
    }
}
