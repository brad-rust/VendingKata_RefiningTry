﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using VendingMachine_Kata;

namespace VendingMachine_Test
{
    [TestClass]
    public class UnitTest1
    {
        private const string sQuarter = "quarter";
        private const string sDime = "dime";
        private const string sNickel = "nickel";

        [TestMethod]
        public void whenNoCoinsHaveBeenInserted_displayReadsInsertCoin()
        {
            VendingMachine vm = new VendingMachine();
            Assert.AreEqual(vm.display.message, "INSERT COIN");
        }

        [TestMethod]
        public void whenCoinIsInserted_displayShowsAmountOfMoneyInserted()
        {
            VendingMachine vm = new VendingMachine();
            vm.insertCoin(sQuarter);
            Assert.AreEqual(vm.display.message, "0.25");
        }

        [TestMethod]
        public void whenInvalidCoinIsInserted_VendingMachinePlacesObjectInCoinReturn()
        {
            VendingMachine vm = new VendingMachine();
            vm.insertCoin("wooden nickel");
            List<string> coins = new List<string>() { "wooden nickel" };
            CollectionAssert.AreEqual(coins, vm.coinReturn.slot());
        }

        [TestMethod]
        public void whenSufficientAmountOfMoneyIsInsertedAndTheProductButtonIsPressed_theMachinePlacesTheProductIntoTheDespenser()
        {
            VendingMachine vm = place2QuartersInMachine();
            vm.pressButton(vm.chipsButton);
            List<string> contents = new List<string> { "chips" };
            CollectionAssert.AreEqual(vm.dispenser.contents(), contents);
        }

        private VendingMachine place2QuartersInMachine()
        {
            VendingMachine vm = new VendingMachine();
            vm.insertCoin(sQuarter);
            vm.insertCoin(sQuarter);
            return vm;
        }
    }
}
