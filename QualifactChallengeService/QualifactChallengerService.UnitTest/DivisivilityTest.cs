using NUnit.Framework;
using QualifactChallengeService.Application.Models;
using QualifactChallengeService.Application.Services;

namespace QualifactChallengerService.UnitTest
{
    [TestFixture]
    public class DivisivilityServiceTests
    {
        [Test]
        public void CalculateResult_InputDivisibleByBoth_ReturnsIDontKnow()
        {
            // Arrange
            var service = new DivisivilityService();
            int input1 = 3;
            int input2 = 5;
            int number = 15;

            // Act
            string result = service.CalculateResult(number, input1, input2);

            // Assert
            Assert.AreEqual("I don’t know", result);
        }

        [Test]
        public void CalculateResult_InputDivisibleByInput1_ReturnsYes()
        {
            // Arrange
            var service = new DivisivilityService();
            int input1 = 3;
            int input2 = 5;
            int number = 9;

            // Act
            string result = service.CalculateResult(number, input1, input2);

            // Assert
            Assert.AreEqual("Yes", result);
        }

        [Test]
        public void CalculateResult_InputDivisibleByInput2_ReturnsNo()
        {
            // Arrange
            var service = new DivisivilityService();
            int input1 = 3;
            int input2 = 5;
            int number = 10;

            // Act
            string result = service.CalculateResult(number, input1, input2);

            // Assert
            Assert.AreEqual("No", result);
        }

        [Test]
        public void CalculateResult_InputNotDivisibleByEither_ReturnsNA()
        {
            // Arrange
            var service = new DivisivilityService();
            int input1 = 3;
            int input2 = 5;
            int number = 7;

            // Act
            string result = service.CalculateResult(number, input1, input2);

            // Assert
            Assert.AreEqual("N/A", result);
        }

        [Test]
        public void GetResults_ReturnsCorrectNumberOfResults()
        {
            // Arrange
            var service = new DivisivilityService();
            int input1 = 2;
            int input2 = 3;
            int size = 5;

            // Act
            IEnumerable<DivisivilityResult> results = service.GetResults(input1, input2, size);

            // Assert
            Assert.AreEqual(size, results.Count());
        }
    }
}