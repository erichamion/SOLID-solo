using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CreditCardInterest.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Person_PassTimeCallsAllWalletPassTimes()
        {
            // Arrange
            var periods = 27;
            var mockData = new List<Mock<IWallet>>
            {
                new Mock<IWallet>(),
                new Mock<IWallet>(),
                new Mock<IWallet>(),
            };
            mockData.ForEach(x => x.Setup(y => y.PassTime(periods)));
            var data = mockData.Select(x => x.Object).ToList();
            var target = new Person(data);

            // Act
            target.PassTime(periods);

            // Assert
            mockData.ForEach(x => x.VerifyAll());
        }

        [TestMethod]
        public void Person_InterestUsesInterestBalanceCollector()
        {
            // Arrange
            var expected = 27.0;
            var mockCollector = new Mock<IInterestBalanceCollector>();
            var data = new List<IWallet>();
            mockCollector.Setup(x => x.GetTotal(data, It.IsAny<Func<IWallet, double>>())).Returns(expected);
            var target = new Person(data, mockCollector.Object);
            double actual;

            // Act
            actual = target.Interest;

            // Assert
            mockCollector.VerifyAll();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Person_PrincipalUsesInterestBalanceCollector()
        {
            // Arrange
            var expected = 27.0;
            var mockCollector = new Mock<IInterestBalanceCollector>();
            var data = new List<IWallet>();
            mockCollector.Setup(x => x.GetTotal(data, It.IsAny<Func<IWallet, double>>())).Returns(expected);
            var target = new Person(data, mockCollector.Object);
            double actual;

            // Act
            actual = target.Principal;

            // Assert
            mockCollector.VerifyAll();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Person_InterestSumsWalletInterest()
        {
            // Arrange
            var mockData = new List<Mock<IWallet>>
            {
                new Mock<IWallet>(),
                new Mock<IWallet>(),
                new Mock<IWallet>(),
            };
            var individualInterest = 27.0;
            var expected = individualInterest * mockData.Count;
            mockData.ForEach(x => x.Setup(y => y.Interest).Returns(individualInterest));
            var data = mockData.Select(x => x.Object).ToList();
            var target = new Person(data);
            double actual;

            // Act
            actual = target.Interest;

            // Assert
            mockData.ForEach(x => x.VerifyAll());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Person_PrincipalSumsWalletPrincipal()
        {
            // Arrange
            var mockData = new List<Mock<IWallet>>
            {
                new Mock<IWallet>(),
                new Mock<IWallet>(),
                new Mock<IWallet>(),
            };
            var individualPrincipal = 27.0;
            var expected = individualPrincipal * mockData.Count;
            mockData.ForEach(x => x.Setup(y => y.Principal).Returns(individualPrincipal));
            var data = mockData.Select(x => x.Object).ToList();
            var target = new Person(data);
            double actual;

            // Act
            actual = target.Principal;

            // Assert
            mockData.ForEach(x => x.VerifyAll());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Person_Wallets()
        {
            // Arrange
            var mockData = new List<Mock<IWallet>>
            {
                new Mock<IWallet>(),
                new Mock<IWallet>(),
                new Mock<IWallet>(),
            };
            var expectedList = mockData.Select(x => x.Object).ToList();
            var target = new Person(expectedList);
            IList<IWallet> actualList;

            // Act
            actualList = target.Accounts;

            // Assert
            Assert.IsTrue(expectedList.SequenceEqual(actualList));
        }
    }
}
