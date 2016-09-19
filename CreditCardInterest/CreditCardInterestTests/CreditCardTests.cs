using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CreditCardInterest.Tests
{
    [TestClass]
    public class CreditCardTests
    {
        [TestMethod]
        public void CreditCard_PassTimeUsesInterestCalculator()
        {
            // Arrange
            var principalIn = 3.0;
            var rateIn = 0.1;
            var periods = 42;
            var principalOut = 27.0;
            var interestOut = 42.0;
            var expected = principalOut + interestOut;
            var mockInterestCalculator = new Mock<IDiscreteInterestCalculator>();
            mockInterestCalculator.Setup(x => x.CalculateInterest(principalIn, rateIn, periods)).Returns(new PrincipalInterestBalance { Principal = principalOut, Interest = interestOut });
            var target = new CreditCard("foo", principalIn, 0.1, mockInterestCalculator.Object);
            double actual;

            // Act
            target.PassTime(periods);
            actual = target.Balance;

            // Assert
            mockInterestCalculator.Verify(x => x.CalculateInterest(principalIn, rateIn, periods), Times.Once);
            Assert.AreEqual(expected, actual, 0.0000001);
        }
    }
}
