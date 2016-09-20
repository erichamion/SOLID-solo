using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CreditCardInterest.Tests
{
    [TestClass]
    public class WalletTests
    {
        [TestMethod]
        public void Wallet_PassTimeCallsAllCardPassTimes()
        {
            // Arrange
            var periods = 27;
            var mockData = new List<Mock<ICreditCard>>
            {
                new Mock<ICreditCard>(),
                new Mock<ICreditCard>(),
                new Mock<ICreditCard>(),
            };
            mockData.ForEach(x => x.Setup(y => y.PassTime(periods)));
            var data = mockData.Select(x => x.Object).ToList();
            var target = new Wallet(data);

            // Act
            target.PassTime(periods);

            // Assert
            mockData.ForEach(x => x.VerifyAll());
        }

        [TestMethod]
        public void Wallet_BalanceUsesInterestBalanceCollector()
        {
            // Arrange
            var expected = 27.0;
            var mockCollector = new Mock<IInterestBalanceCollector>();
            var data = new List<ICreditCard>();
            mockCollector.Setup(x => x.GetTotal(data, It.IsAny<Func<ICreditCard, double>>())).Returns(expected);
            var target = new Wallet(data, mockCollector.Object);
            double actual;

            // Act
            actual = target.Balance;

            // Assert
            mockCollector.VerifyAll();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Wallet_InterestUsesInterestBalanceCollector()
        {
            // Arrange
            var expected = 27.0;
            var mockCollector = new Mock<IInterestBalanceCollector>();
            var data = new List<ICreditCard>();
            mockCollector.Setup(x => x.GetTotal(data, It.IsAny<Func<ICreditCard, double>>())).Returns(expected);
            var target = new Wallet(data, mockCollector.Object);
            double actual;

            // Act
            actual = target.Interest;

            // Assert
            mockCollector.VerifyAll();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Wallet_PrincipalUsesInterestBalanceCollector()
        {
            // Arrange
            var expected = 27.0;
            var mockCollector = new Mock<IInterestBalanceCollector>();
            var data = new List<ICreditCard>();
            mockCollector.Setup(x => x.GetTotal(data, It.IsAny<Func<ICreditCard, double>>())).Returns(expected);
            var target = new Wallet(data, mockCollector.Object);
            double actual;

            // Act
            actual = target.Principal;

            // Assert
            mockCollector.VerifyAll();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Wallet_InterestSumsCardInterest()
        {
            // Arrange
            var mockData = new List<Mock<ICreditCard>>
            {
                new Mock<ICreditCard>(),
                new Mock<ICreditCard>(),
                new Mock<ICreditCard>(),
            };
            var individualInterest = 27.0;
            var expected = individualInterest * mockData.Count;
            mockData.ForEach(x => x.Setup(y => y.Interest).Returns(individualInterest));
            var data = mockData.Select(x => x.Object).ToList();
            var target = new Wallet(data);
            double actual;

            // Act
            actual = target.Interest;

            // Assert
            mockData.ForEach(x => x.VerifyAll());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Wallet_PrincipalSumsCardPrincipal()
        {
            // Arrange
            var mockData = new List<Mock<ICreditCard>>
            {
                new Mock<ICreditCard>(),
                new Mock<ICreditCard>(),
                new Mock<ICreditCard>(),
            };
            var individualPrincipal = 27.0;
            var expected = individualPrincipal * mockData.Count;
            mockData.ForEach(x => x.Setup(y => y.Principal).Returns(individualPrincipal));
            var data = mockData.Select(x => x.Object).ToList();
            var target = new Wallet(data);
            double actual;

            // Act
            actual = target.Principal;

            // Assert
            mockData.ForEach(x => x.VerifyAll());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Wallet_Cards()
        {
            // Arrange
            var mockData = new List<Mock<ICreditCard>>
            {
                new Mock<ICreditCard>(),
                new Mock<ICreditCard>(),
                new Mock<ICreditCard>(),
            };
            var expectedList = mockData.Select(x => x.Object).ToList();
            var target = new Wallet(expectedList);
            IList<ICreditCard> actualList;

            // Act
            actualList = target.Cards;

            // Assert
            Assert.IsTrue(expectedList.SequenceEqual(actualList));
        }
    }
}
