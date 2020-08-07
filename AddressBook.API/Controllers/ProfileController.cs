using System.Collections.Generic;
using API.Domain;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly PersonProfileRepository _personProfileRepository;

        public ProfileController(ILogger<ProfileController> logger, PersonProfileRepository personProfileRepository)
        {
            _logger = logger;
            _personProfileRepository = personProfileRepository;
        }

        [HttpGet("api/profiles")]
        public IEnumerable<PersonProfile> GetProfiles()
        {
            _logger.LogInformation("Fetched all profiles.");
            return _personProfileRepository.FetchAll();
        }

        [HttpGet]
        [Route("api/profiles/{id}")]
        public PersonProfile GetProfileById(int id)
        {
            _logger.LogInformation("Fetched all profiles.");
            return _personProfileRepository.FindById(id);
        }
    }
}