using QualifactChallengeService.Application.Interfaces;
using QualifactChallengeService.Application.Models;

namespace QualifactChallengeService.Application.Services { 
    public class DivisivilityService : IDivisivilityService
    {
        public IEnumerable<DivisivilityResult> GetResults(int input1, int input2, int size)
        {
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
            if (number % input1 == 0 && number % input2 == 0)
                return "I don’t know";
            else if (number % input1 == 0)
                return "Yes";
            else if (number % input2 == 0)
                return "No";
            else
                return "N/A";
        }
    }
}
