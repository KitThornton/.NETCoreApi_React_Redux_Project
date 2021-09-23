using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Entities;
using WebApplication.Repository;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OwnerController : ControllerBase
    {
        // Fields
        private readonly IOwnerRepository _ownerRepository;
        private readonly IAccountRepository _accountRepository;
        private ILogger<OwnerController> _logger;
        
        // Constructor
        public OwnerController(IOwnerRepository ownerRepository, IAccountRepository accountRepository, ILogger<OwnerController> ownerControllerLogger)
        {
            _ownerRepository = ownerRepository;
            _accountRepository = accountRepository;
            _logger = ownerControllerLogger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var listOwner = _ownerRepository.GetAllOwners();
            var result = new ObjectResult(listOwner)
            {
                StatusCode = (int) HttpStatusCode.OK
            };
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
        
            return result;
        }
        
        [HttpGet("{id}/account")]
        public IActionResult GetOwnerWithDetails(int id)
        {
            try
            {
                var owner = _ownerRepository.GetOwnerById(id);

                var accounts = _accountRepository.AccountsByOwner(id);

                var ownerExtended = new OwnerExtended(owner, accounts);
                
                if (ownerExtended == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    // _logger.Log($"Returned owner with details for id: {id}");
                    Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    return Ok(ownerExtended);
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