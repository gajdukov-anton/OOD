using GumballMachine.GumbalMachineWithState;
using GumballMachine.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace GumballMachineTest.GumballMachineWithState
{
    [TestClass]
    public class SoldStateTest
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
            var soldState = new SoldState( gumballMachine, stringWriter );

            soldState.InsertQuarter();
            result.WriteLine( BaseConstants.INSERT_QUARTER_SOLD_STATE );

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
            var soldState = new SoldState( gumballMachine, stringWriter );

            soldState.EjectQuarter();
            result.WriteLine( BaseConstants.EJECT_QUARTER_SOLD_STATE );

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
            var soldState = new SoldState( gumballMachine, stringWriter );

            soldState.TurnCrank();
            result.WriteLine( BaseConstants.TURN_CRANK_SOLD_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void DispenseWithSomeBallsTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 1 } gumball{ ( 1 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var soldState = new SoldState( gumballMachine, stringWriter );

            gumballMachine.InsertQuarter();
            soldState.Dispense();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( BaseConstants.RELEASE_BALL );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void DispenseWithZeroBallsTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 1, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_SOLD_OUT_STATE })";
            var soldState = new SoldState( gumballMachine, stringWriter );
            var hasQuarterState = new HasQuarterState( gumballMachine, stringWriter );

            gumballMachine.InsertQuarter();
            hasQuarterState.TurnCrank();
            soldState.Dispense();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( BaseConstants.TURN_CRANK_HAS_QUARTER_STATE );
            result.WriteLine( BaseConstants.RELEASE_BALL );
            result.WriteLine( BaseConstants.DISPENSE_SOLD_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }
    }
}
