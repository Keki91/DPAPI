using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DPAPI.Context;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DPAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly KeysContext _context;
        private readonly IDataProtector _protector;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDataProtectionProvider provider, KeysContext context)
        {
            _logger = logger;
            _context = context;
            _protector = provider.CreateProtector("DPAPI.Test.Class");
        }


        [HttpGet]
        public IActionResult Get(string input)
        {
            var y  = _context.DataProtectionKeys.FirstOrDefault();

            // protect the payload
            try
            {


                string protectedPayload = _protector.Protect(input);
                string unprotectedPayload = _protector.Unprotect(protectedPayload);
                // unprotect the payload
          

                dynamic x = new
                {
                    protectedString = protectedPayload,
                    unprotectedPayload = unprotectedPayload
                };

                return Ok(x);
            }
            catch (Exception ex)
            {
                throw ex;
            }

         
        }

    }
}
