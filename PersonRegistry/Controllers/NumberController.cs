using Microsoft.AspNetCore.Mvc;
using PersonRegistry.Core.Models;
using PersonRegistry.Core.Services;
using PersonRegistry.Services;
using System;
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
        public IActionResult AddPhoneNumber(PhoneNumber number)
        {
            if (!_numberValidator.IsValid(number))
            {
                return BadRequest();
            }

            if (_phoneService.Exists(number))
            {
                return Conflict();
            }

            _phoneService.Create(number);

            return Created("", number);
        }
    }
}
