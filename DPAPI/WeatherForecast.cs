using System;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace DPAPI
{
    public class WeatherForecast
    {
        readonly IDataProtector _protector;

        // the 'provider' parameter is provided by DI
        public WeatherForecast(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("DPAPI.Test.Class");
        }

   
    }
}
