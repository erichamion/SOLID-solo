using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace CreditCardInterest.Tests
{
    [TestClass]
    public class GroupTimePasserTests
    {
        [TestMethod]
        public void GroupTimePasser_PassTimeForAll()
        {
            // Arrange
            var target = new GroupTimePasser();
            var periods = 3;
            var mockData = new List<Mock<ITimeSensitiveAccount>>
            {
                new Mock<ITimeSensitiveAccount>(),
                new Mock<ITimeSensitiveAccount>(),
                new Mock<ITimeSensitiveAccount>(),
                new Mock<ITimeSensitiveAccount>(),
            };
            mockData.ForEach(x => x.Setup(y => y.PassTime(periods)));
            var data = mockData.Select(x => x.Object).ToList();

            // Act
            target.PassTimeForAll(data, periods);

            // Assert
            mockData.ForEach(x => x.VerifyAll());
        }
    }
}
