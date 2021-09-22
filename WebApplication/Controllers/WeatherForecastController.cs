using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Web;
using WebApplication.Entities;
using WebApplication.Repository;

namespace WebApplication.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000/owner-list");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }

    [ApiController]
    [Route("api")]
    public class DefaultController : ControllerBase
    {
        // Fields
        // private readonly Owner _owner;
        private readonly IOwnerRepository _ownerRepository;
        
        // Constructor
        public DefaultController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //IEnumerable<Owner> listOwner = new List<Owner>(){_owner};
            var listOwner = _ownerRepository.GetAll();
            
            var result = new ObjectResult(listOwner)
            {
                StatusCode = (int) HttpStatusCode.OK
            };
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            
            // Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            // IEnumerable<Owner> result = new List<Owner>(){_owner};
            // Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
            // Response.Headers.Add("Access-Control-Allow-Credentials", "true");

            return result;
        }
    }
}