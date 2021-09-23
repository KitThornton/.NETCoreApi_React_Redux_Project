using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Repository;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OwnerController : ControllerBase
    {
        // Fields
        private readonly IOwnerRepository _ownerRepository;
        private ILogger<OwnerController> _logger;
        
        // Constructor
        public OwnerController(IOwnerRepository ownerRepository, ILogger<OwnerController> ownerControllerLogger)
        {
            _ownerRepository = ownerRepository;
            _logger = ownerControllerLogger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var listOwner = _ownerRepository.GetAll();
            var result = new ObjectResult(listOwner)
            {
                StatusCode = (int) HttpStatusCode.OK
            };
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
        
            return result;
        }
        
        HttpGet("{id}/account")]
        public IActionResult GetOwnerWithDetails(Guid id)
        {
            try
            {
                var owner = _ownerRepository.Owner.GetOwnerWithDetails(id);

                if (owner.IsEmptyObject())
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    // _logger.Log($"Returned owner with details for id: {id}");
                    return Ok(owner);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

// IEnumerable<Owner> listOwner = new List<Owner>(){_owner};
// Response.Headers.Add("Access-Control-Allow-Credentials", "true");
// IEnumerable<Owner> result = new List<Owner>(){_owner};
// Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
// Response.Headers.Add("Access-Control-Allow-Credentials", "true");