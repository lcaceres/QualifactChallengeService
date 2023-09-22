using QualifactChallengeService.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifactChallengeService.Application.Interfaces
{
    public interface IDivisivilityService
    {
        IEnumerable<DivisivilityResult> GetResults(int input1, int input2, int size);
        string CalculateResult(int number, int input1, int input2);
    }
}
