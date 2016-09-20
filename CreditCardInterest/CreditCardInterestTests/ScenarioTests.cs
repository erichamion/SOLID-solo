using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace CreditCardInterest.Tests
{
    [TestClass]
    public class ScenarioTests
    {
        /*
         * All Visas have 10% interest per period
         * All MasterCard have 5% interest per period
         * All Discovers have 1% interest per period
         * 
         * All cards are simple interest, and all scenarios retrieve interest after one period.
         */

        private IDiscreteInterestCalculator interestCalc = new SimpleInterestCalculator();

        private void AssertPersonAndCardsMatchExpectedInterest(IPerson actual, double expectedTotal, List<List<double>> expectedCards, double delta)
        {
            // Compare totals
            Assert.AreEqual(expectedTotal, actual.Interest, delta);

            // Must have the same number of wallets
            IList<IWallet> wallets = actual.Accounts;
            Assert.AreEqual(wallets.Count, expectedCards.Count);

            // For each wallet, compare each of the individual cards
            for (int walletIndex = 0; walletIndex < wallets.Count; walletIndex++)
            {
                IList<ICreditCard> actualCards = wallets[walletIndex].Accounts;
                List<double> expectedValues = expectedCards[walletIndex];
                Assert.AreEqual(actualCards.Count, expectedValues.Count);
                for (int cardIndex = 0; cardIndex < actualCards.Count; cardIndex++)
                {
                    Assert.AreEqual(actualCards[cardIndex].Interest, expectedValues[cardIndex]);
                }
            }
        }

        private void AssertPersonAndWalletsMatchExpectedInterest(IPerson actual, double expectedTotal, List<double> expectedWallets, double delta)
        {
            // Compare totals
            Assert.AreEqual(expectedTotal, actual.Interest, delta);

            // Must have the same number of wallets
            IList<IWallet> wallets = actual.Accounts;
            Assert.AreEqual(wallets.Count, expectedWallets.Count);

            // For each wallet, compare total interest
            for (int i = 0; i < wallets.Count; i++)
            {
                Assert.AreEqual(wallets[i].Interest, expectedWallets[i]);                
            }
        }

        [TestMethod]
        public void Scenario1()
        {
            /*
             * 1 person has 1 wallet and 3 cards (1 Visa, 1 MC, 1 Discover) - Each card has a balance of $100 -
             * calculate the total interest for this person and per card.
             */

            // Arrange
            var cards = new List<ICreditCard>
             {
                 new CreditCard("Visa", 100, 0.1, interestCalc),
                 new CreditCard("MasterCard", 100, .05, interestCalc),
                 new CreditCard("Discover", 100, .01, interestCalc),
             };
            var wallets = new List<IWallet> { new Wallet(cards) };
            var target = new Person(wallets);
            var expectedTotal = 10.0 + 5.0 + 1.0;
            List<List<double>> expected = new List<List<double>>
            {
                new List<double> { 10.0, 5.0, 1.0 }
            };

            // Act
            target.PassTime(1);

            // Assert
            AssertPersonAndCardsMatchExpectedInterest(target, expectedTotal, expected, 0.0000001);
        }

        [TestMethod]
        public void Scenario2()
        {
            /*
             * 1 person has 2 wallets Wallet 1 has a Visa and Discover, wallet 2 a MC - Each card has a balance of $100 -
             * calculate the total interest for this person and per wallet.
             */

            // Arrange
            var cards1 = new List<ICreditCard>
             {
                 new CreditCard("Visa", 100, 0.1, interestCalc),
                 new CreditCard("Discover", 100, .01, interestCalc),
             };
            var cards2 = new List<ICreditCard>
             {
                 new CreditCard("MasterCard", 100, .05, interestCalc),
             };
            var wallets = new List<IWallet> { new Wallet(cards1), new Wallet(cards2) };
            var target = new Person(wallets);
            var expectedTotal = 10.0 + 1.0 + 5.0;
            List<double> expected = new List<double>
            {
                10.0 + 1.0,
                5.0
            };

            // Act
            target.PassTime(1);

            // Assert
            AssertPersonAndWalletsMatchExpectedInterest(target, expectedTotal, expected, 0.0000001);
        }

        [TestMethod]
        public void Scenario3()
        {
            /*
             * 2 people have 1 wallet each, person 1 has 1 wallet with 3 cards (1 MC, 1 Visa, 1 Discover), person 2 has
             * 1 wallet with 2 cards (1 Visa, 1 MC) - calculate the total interest for each person and per wallet.
             */

            // Arrange
            var cards1 = new List<ICreditCard>
             {
                 new CreditCard("MasterCard", 100, .05, interestCalc),
                 new CreditCard("Visa", 100, 0.1, interestCalc),
                 new CreditCard("Discover", 100, .01, interestCalc),
             };
            var wallets1 = new List<IWallet> { new Wallet(cards1) };
            var target1 = new Person(wallets1);
            var expectedTotal1 = 5.0 + 10.0 + 1.0;
            List<double> expected1 = new List<double>
            {
                5.0 + 10.0 + 1.0,
            };
            var cards2 = new List<ICreditCard>
             {
                 new CreditCard("Visa", 100, 0.1, interestCalc),
                 new CreditCard("MasterCard", 100, .05, interestCalc),
             };
            var wallets2 = new List<IWallet> { new Wallet(cards2) };
            var target2 = new Person(wallets2);
            var expectedTotal2 = 10.0 + 5.0;
            List<double> expected2 = new List<double>
            {
                10.0 + 5.0,
            };

            // Act
            target1.PassTime(1);
            target2.PassTime(1);

            // Assert
            AssertPersonAndWalletsMatchExpectedInterest(target1, expectedTotal1, expected1, 0.0000001);
            AssertPersonAndWalletsMatchExpectedInterest(target2, expectedTotal2, expected2, 0.0000001);
        }
    }
}
