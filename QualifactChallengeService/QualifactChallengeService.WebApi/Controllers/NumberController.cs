using Microsoft.AspNetCore.Mvc;
using QualifactChallengeService.Application.Interfaces;
using QualifactChallengeService.Application.Models;

namespace QualifactChallengeService.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberController : ControllerBase
    {
        private readonly IDivisivilityService _divisivilityService;

        public NumberController(IDivisivilityService divisivilityService)
        {
            _divisivilityService = divisivilityService;
        }

        [HttpGet]
        public IEnumerable<DivisivilityResult> Get(int input1,int input2, int size)
        {
            var results= _divisivilityService.GetResults(input1, input2, size);
            return results;
        }
    }
}
