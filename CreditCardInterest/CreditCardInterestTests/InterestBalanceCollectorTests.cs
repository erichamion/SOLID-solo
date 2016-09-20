using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CreditCardInterest.Tests
{
    [TestClass]
    public class InterestBalanceCollectorTests
    {
        [TestMethod]
        public void InterestBalanceCollector_GetTotalInterest()
        {
            // Arrange
            var target = new InterestBalanceCollector();
            var individualInterest = 27.0;
            var mockData = new List<Mock<IInterestBearingAccount>>
            {
                new Mock<IInterestBearingAccount>(),
                new Mock<IInterestBearingAccount>(),
                new Mock<IInterestBearingAccount>(),
                new Mock<IInterestBearingAccount>(),
            };
            mockData.ForEach(x => x.Setup(y => y.Interest).Returns(individualInterest));
            var data = mockData.Select(x => x.Object).ToList();
            var expected = individualInterest * data.Count;
            double actual;

            // Act
            actual = target.GetTotal(data, x => x.Interest);

            // Assert
            mockData.ForEach(x => x.VerifyAll());
            Assert.AreEqual(expected, actual, 0.0000001);
        }

        [TestMethod]
        public void InterestBalanceCollector_GetTotalPrincipal()
        {
            // Arrange
            var target = new InterestBalanceCollector();
            var individualPrincipal = 27.0;
            var mockData = new List<Mock<IInterestBearingAccount>>
            {
                new Mock<IInterestBearingAccount>(),
                new Mock<IInterestBearingAccount>(),
                new Mock<IInterestBearingAccount>(),
                new Mock<IInterestBearingAccount>(),
            };
            mockData.ForEach(x => x.Setup(y => y.Principal).Returns(individualPrincipal));
            var data = mockData.Select(x => x.Object).ToList();
            var expected = individualPrincipal * data.Count;
            double actual;

            // Act
            actual = target.GetTotal(data, x => x.Principal);

            // Assert
            mockData.ForEach(x => x.VerifyAll());
            Assert.AreEqual(expected, actual, 0.0000001);
        }
    }
}
