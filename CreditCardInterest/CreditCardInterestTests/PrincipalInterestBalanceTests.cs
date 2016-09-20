using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreditCardInterest.Tests
{
    [TestClass]
    public class PrincipalInterestBalanceTests
    {
        [TestMethod]
        public void PrincipalInterestBalance_AddFunction()
        {
            // Arrange
            var principal1 = 27.0;
            var principal2 = 10.0;
            var interest1 = 42.0;
            var interest2 = 5.0;
            var expectedPrincipal = principal1 + principal2;
            var expectedInterest = interest1 + interest2;
            var target1 = new PrincipalInterestBalance { Principal = principal1, Interest = interest1 };
            var target2 = new PrincipalInterestBalance { Principal = principal2, Interest = interest2 };
            double actualPrincipal;
            double actualInterest;
            PrincipalInterestBalance result;

            // Act
            result = target1.Add(target2);
            actualInterest = result.Interest;
            actualPrincipal = result.Principal;

            // Assert
            Assert.AreEqual(expectedPrincipal, actualPrincipal, 0.0000001);
            Assert.AreEqual(expectedInterest, actualInterest, 0.0000001);
        }

        [TestMethod]
        public void PrincipalInterestBalance_AddOperator()
        {
            // Arrange
            var principal1 = 27.0;
            var principal2 = 10.0;
            var interest1 = 42.0;
            var interest2 = 5.0;
            var expectedPrincipal = principal1 + principal2;
            var expectedInterest = interest1 + interest2;
            var target1 = new PrincipalInterestBalance { Principal = principal1, Interest = interest1 };
            var target2 = new PrincipalInterestBalance { Principal = principal2, Interest = interest2 };
            double actualPrincipal;
            double actualInterest;
            PrincipalInterestBalance result;

            // Act
            result = target1 + target2;
            actualInterest = result.Interest;
            actualPrincipal = result.Principal;

            // Assert
            Assert.AreEqual(expectedPrincipal, actualPrincipal, 0.0000001);
            Assert.AreEqual(expectedInterest, actualInterest, 0.0000001);
        }
    }
}
