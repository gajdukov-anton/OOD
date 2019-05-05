using GumballMachine.GumbalMachineWithState;
using GumballMachine.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace GumballMachineTest.GumballMachineWithState
{
    [TestClass]
    public class SoldOutStateTest
    {
        [TestMethod]
        public void InsertQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var soldOutState = new SoldOutState( gumballMachine, stringWriter );

            soldOutState.InsertQuarter();
            result.WriteLine( BaseConstants.INSERT_QUARTER_SOLD_OUT_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void EjectQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var soldOutState = new SoldOutState( gumballMachine, stringWriter );

            soldOutState.EjectQuarter();
            result.WriteLine( BaseConstants.EJECT_QUARTER_SOLD_OUT_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void EjectQuarterWithZeroQuartersTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var soldOutState = new SoldOutState( gumballMachine, stringWriter );

            soldOutState.EjectQuarter();
            result.WriteLine( BaseConstants.EJECT_QUARTER_SOLD_OUT_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void TurnCrankTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var soldOutState = new SoldOutState( gumballMachine, stringWriter );

            soldOutState.TurnCrank();
            result.WriteLine( BaseConstants.TURN_CRANK_SOLD_OUT_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void DispenseTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var soldOutState = new SoldOutState( gumballMachine, stringWriter );

            soldOutState.Dispense();
            result.WriteLine( BaseConstants.DISPENSE_SOLD_OUT_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ToStringTest()
        {
            var stringWriter = new StringWriter();
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var soldOutState = new SoldOutState( gumballMachine, stringWriter );

            Assert.AreEqual( soldOutState.ToString(), BaseConstants.TO_STRING_SOLD_OUT_STATE );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }
    }
}
