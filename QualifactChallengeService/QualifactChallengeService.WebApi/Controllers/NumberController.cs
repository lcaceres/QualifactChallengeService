using Microsoft.AspNetCore.Mvc;
using QualifactChallengeService.Application.Interfaces;
using QualifactChallengeService.Application.Models;

namespace QualifactChallengeService.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberController : ControllerBase
    {
        private readonly ILogger<NumberController> _logger;
        private readonly IDivisivilityService _divisivilityService;

        public NumberController(ILogger<NumberController> logger, IDivisivilityService divisivilityService)
        {
            _logger = logger;
            _divisivilityService = divisivilityService;
        }

        [HttpGet]
        [Route("{GetDivisions}")]
        public IEnumerable<DivisivilityResult> GetDivisions(int input1,int input2, int size)
        {
            var results= _divisivilityService.GetResults(input1, input2, size);
            return results;
        }
    }
}
