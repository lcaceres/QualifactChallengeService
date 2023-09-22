using QualifactChallengeService.Application.Interfaces;
using QualifactChallengeService.Application.Models;
using QualifactChallengeService.Infraestructure.Localization;
using Timeportal.Infrastructure.Exceptions;

namespace QualifactChallengeService.Application.Services { 
    public class DivisivilityService : IDivisivilityService
    {
        public IEnumerable<DivisivilityResult> GetResults(int input1, int input2, int size)
        {
            if (size< 0)
            {
                throw new ApplicationArgumentException(SystemMessages.DivisivilitySizeValidation);
            }

            var results = new List<DivisivilityResult>();
            for (int i = 1; i <= size; i++)
            {
                var result = CalculateResult(i, input1, input2);
                results.Add(new DivisivilityResult { Number = i, Result = result });
            }
            return results;
        }

        public string CalculateResult(int number, int input1, int input2)
        {
            if (input1 <= 0)
            {
                throw new ApplicationArgumentException(SystemMessages.DivisivilityNegativeOrZeroValidation1);
            }
            if (input2 <= 0)
            {
                throw new ApplicationArgumentException(SystemMessages.DivisivilityNegativeOrZeroValidation2);
            }

            if (number % input1 == 0 && number % input2 == 0)
                return SystemMessages.DivisivilityNotKnown;
            else if (number % input1 == 0)
                return SystemMessages.DivisivilityYes;
            else if (number % input2 == 0)
                return SystemMessages.DivisivilityNo;
            else
                return SystemMessages.DivisivilityNA;
        }
    }
}
