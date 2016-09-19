using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterest.Tests
{
    [TestClass]
    public class SimpleInterestCalculatorTests
    {
        [TestMethod]
        public void SimpleInterestCalculator_CalculateInterestGivesCorrectInterest()
        {
            // Arrange
            var startingPrincipal = 100.0;
            var rate = 0.15;
            var expected = startingPrincipal * rate;
            var target = new SimpleInterestCalculator();
            PrincipalInterestBalance result;
            double actual;

            // Act
            result = target.CalculateInterest(startingPrincipal, rate, 1);
            actual = result.Interest;

            // Assert
            Assert.AreEqual(expected, actual, 0.0000001);
        }

        [TestMethod]
        public void SimpleInterestCalculator_CalculateInterestGivesKeepsOriginalPrincipal()
        {
            // Arrange
            var startingPrincipal = 100.0;
            var rate = 0.15;
            var expected = startingPrincipal;
            var target = new SimpleInterestCalculator();
            PrincipalInterestBalance result;
            double actual;

            // Act
            result = target.CalculateInterest(startingPrincipal, rate, 1);
            actual = result.Principal;

            // Assert
            Assert.AreEqual(expected, actual, 0.0000001);
        }
    }
}
