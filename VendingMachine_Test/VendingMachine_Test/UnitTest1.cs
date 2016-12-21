﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
