using System;
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
            CollectionAssert.AreEqual(coins, vm.coinReturnSlot());
        }

        [TestMethod]
        public void whenSufficientAmountOfMoneyIsInsertedAndTheProductButtonIsPressed_theMachinePlacesTheProductIntoTheDespenser()
        {
            VendingMachine vm = place2QuartersInMachine();
            stockCandyAndChips(vm);
            vm.pressButton(vm.Button.Chips);
            List<string> contents = new List<string> { "chips" };
            CollectionAssert.AreEqual(vm.dispenser.contents(), contents);
        }

        [TestMethod]
        public void whenContentsAreRemovedFromDispenser_dispenserIsEmpty()
        {
            VendingMachine vm = place2QuartersInMachine();
            stockCandyAndChips(vm);
            vm.pressButton(vm.Button.Chips);
            List<string> contents = new List<string>();
            string item = vm.dispenser.removeContents();
            Assert.AreEqual(item, vm.Button.Chips.ToString());
            CollectionAssert.AreEqual(contents, vm.dispenser.contents());
        }

        [TestMethod]
        public void whenReturnCoinsButtonIsPressed_machineReturnsCoinsToCoinReturnSlot()
        {
            VendingMachine vm = place2QuartersInMachine();
            vm.pressButton(vm.Button.ReturnCoins);
            List<string> coins = new List<string> { sQuarter, sQuarter };
            CollectionAssert.AreEqual(coins, vm.coinReturnSlot());
        }

        [TestMethod]
        public void whenMoreMoneyIsInsertedThanTheItemCosts_machineGivesBackCorrectAmountOfChange()
        {
            VendingMachine vm = place75centsIntoMachine();
            vm.insertCoin(sNickel);
            stockCandyAndChips(vm);
            vm.pressButton(vm.Button.Candy);
            List<string> returnedCoins = new List<string> { sDime, sNickel };
            CollectionAssert.AreEqual(vm.coinReturnSlot(), returnedCoins);
        }

        [TestMethod]
        public void whenSelectedItemIsUnavailable_machineDisplaysSoldOutMessage()
        {
            //this test requires that we know how much inventory we have on hand. 
            //in order for us to not break the prior tests, we will implement a private helper method that stocks the vending
            //machine, then deplete the machine inventory in order to implement this test. This requires at least two phases/commits
            VendingMachine vm = placeOneDollarInMachine();
            vm.pressButton(vm.Button.Cola);
            Assert.AreEqual(vm.display.message, "SOLD OUT");
        }

        private VendingMachine place2QuartersInMachine()
        {
            VendingMachine vm = new VendingMachine();
            vm.insertCoin(sQuarter);
            vm.insertCoin(sQuarter);
            return vm;
        }

        private VendingMachine place75centsIntoMachine()
        {
            VendingMachine vm = place2QuartersInMachine();
            vm.insertCoin(sQuarter);
            return vm;
        }

        private VendingMachine placeOneDollarInMachine()
        {
            VendingMachine vm = place2QuartersInMachine();
            vm.insertCoin(sQuarter);
            vm.insertCoin(sQuarter);
            return vm;
        }

        private void stockCandyAndChips(VendingMachine vm)
        {
            vm.stockProduct(Product.Chips, 1);
            vm.stockProduct(Product.Candy, 1);
        }
    }
}
