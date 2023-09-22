using NUnit.Framework;
using QualifactChallengeService.Application.Models;
using QualifactChallengeService.Application.Services;
using QualifactChallengeService.Infraestructure.Localization;
using System.Drawing;
using Timeportal.Infrastructure.Exceptions;

namespace QualifactChallengerService.UnitTest
{
    [TestFixture]
    public class DivisivilityServiceTests
    {
        [Test]
        public void CalculateResult_InputDivisibleByBoth_ReturnsIDontKnow()
        {
            var service = new DivisivilityService();
            int input1 = 3;
            int input2 = 5;
            int number = 15;

            string result = service.CalculateResult(number, input1, input2);

            Assert.AreEqual(SystemMessages.DivisivilityNotKnown, result);
        }

        [Test]
        public void CalculateResult_InputDivisibleByInput1_ReturnsYes()
        {
            var service = new DivisivilityService();
            int input1 = 3;
            int input2 = 5;
            int number = 9;

            string result = service.CalculateResult(number, input1, input2);

            Assert.AreEqual(SystemMessages.DivisivilityYes, result);
        }

        [Test]
        public void CalculateResult_InputDivisibleByInput2_ReturnsNo()
        {
            var service = new DivisivilityService();
            int input1 = 3;
            int input2 = 5;
            int number = 10;
            string result = service.CalculateResult(number, input1, input2);

            Assert.AreEqual(SystemMessages.DivisivilityNo, result);
        }

        [Test]
        public void CalculateResult_InputNotDivisibleByEither_ReturnsNA()
        {
            var service = new DivisivilityService();
            int input1 = 3;
            int input2 = 5;
            int number = 7;

            string result = service.CalculateResult(number, input1, input2);
            Assert.AreEqual(SystemMessages.DivisivilityNA, result);
        }

        [Test]
        public void GetResults_ReturnsCorrectNumberOfResults()
        {
            var service = new DivisivilityService();
            int input1 = 2;
            int input2 = 3;
            int size = 5;

            IEnumerable<DivisivilityResult> results = service.GetResults(input1, input2, size);

            Assert.AreEqual(size, results.Count());
        }

        [Test]
        public void GetResults_SizeNegative_InvalidResult()
        {
            var service = new DivisivilityService();
            int input1 = 2;
            int input2 = 3;
            int size = -4;


            Assert.That(() => service.GetResults(input1, input2, size), Throws.TypeOf<ApplicationArgumentException>().With
                .Message.Contains(SystemMessages.DivisivilitySizeValidation));
        }

        [Test]
        public void CalculateResult_Input1Zero_InvalidResult()
        {
            var service = new DivisivilityService();
            int input1 = 0;
            int input2 = 5;
            int number = 10;

            Assert.That(() => service.CalculateResult(number,input1, input2), Throws.TypeOf<ApplicationArgumentException>().With
                .Message.Contains(SystemMessages.DivisivilityNegativeOrZeroValidation1));
        }


        [Test]
        public void CalculateResult_Input2Zero_InvalidResult()
        {
            var service = new DivisivilityService();
            int input1 = 5;
            int input2 = 0;
            int number = 10;

            Assert.That(() => service.CalculateResult(number, input1, input2), Throws.TypeOf<ApplicationArgumentException>().With
                .Message.Contains(SystemMessages.DivisivilityNegativeOrZeroValidation2));
        }

    }
}