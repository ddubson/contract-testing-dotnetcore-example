using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
        }

        public class Profile
        {
            public long Id { get; set; }
            public string FirstName { get; set; }
        }

        [HttpGet("api/profiles")]
        public Profile GetProfiles() => new Profile { Id = 1L, FirstName = "Jill" };
        
        [HttpGet]
        [Route("api/profiles/{id}")]
        public Profile GetProfileById(int id) => new Profile { Id = 1L, FirstName = "Jill" };
    }
}