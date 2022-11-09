using Microsoft.AspNetCore.Mvc;
using PersonRegistry.Core.Models;
using PersonRegistry.Core.Services;
using PersonRegistry.Services;
using System;

namespace PersonRegistry.Controllers
{
    [Microsoft.AspNetCore.Components.Route("number")]
    [ApiController]
    public class NumberController : Controller
    {
        private readonly IPhoneService _phoneService;

        public NumberController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        [Route("number")]
        [HttpPost]
        public IActionResult AddPhoneNumber(PhoneNumber number)
        {

            if (_phoneService.Exists(number))
            {
                return Conflict();
            }

            _phoneService.Create(number);

            return Created("", number);
        }
    }
}
