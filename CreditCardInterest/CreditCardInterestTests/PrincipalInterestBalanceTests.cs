using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreditCardInterest.Tests
{
    [TestClass]
    public class PrincipalInterestBalanceTests
    {
        [TestMethod]
        public void PrincipalInterestBalance_GivesCorrectTotal()
        {
            // Arrange
            var principal = 27.0;
            var interest = 42.0;
            var expected = principal + interest;
            var target = new PrincipalInterestBalance { Principal = principal, Interest = interest };
            double actual;

            // Act
            actual = target.Total;

            // Assert
            Assert.AreEqual(expected, actual, 0.0000001);
        }
    }
}
