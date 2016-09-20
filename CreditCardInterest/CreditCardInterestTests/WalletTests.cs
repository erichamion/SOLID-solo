﻿using System;
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
        public void Wallet_BalanceSumsCardBalances()
        {
            // Arrange
            var mockData = new List<Mock<ICreditCard>>
            {
                new Mock<ICreditCard>(),
                new Mock<ICreditCard>(),
                new Mock<ICreditCard>(),
            };
            var individualBalance = 27.0;
            var expected = individualBalance * mockData.Count;
            mockData.ForEach(x => x.Setup(y => y.Balance).Returns(individualBalance));
            var data = mockData.Select(x => x.Object).ToList();
            var target = new Wallet(data);
            double actual;

            // Act
            actual = target.Balance;

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
