using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using b2c_webapi_core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace b2c_webapi_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StretchChallengeController : ControllerBase
    {

        private readonly ILogger<StretchChallengeController> _logger;

        public StretchChallengeController(ILogger<StretchChallengeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async IAsyncEnumerable<ChallengeResultModel> Get()
        {
            _logger.LogInformation("Calling ChallengeResult");
            foreach (Claim c in User.Claims)
            {
                yield return new ChallengeResultModel {
                    ClaimType = c.Type,
                    ClaimValue = c.Value
                };
            }
        }
    }
}