using GumballMachine.GumbalMachineWithState;
using GumballMachine.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace GumballMachineTest.GumballMachineWithState
{
    [TestClass]
    public class HasQuarterStateTest
    {
        [TestMethod]
        public void InsertSomeQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var hasQuarterState = new HasQuarterState( gumballMachine, stringWriter );

            hasQuarterState.InsertQuarter();
            hasQuarterState.InsertQuarter();

            result.WriteLine( BaseConstants.INSERT_QUARTER_HAS_QUARTER_STATE );
            result.WriteLine( BaseConstants.INSERT_QUARTER_HAS_QUARTER_STATE );

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
            var hasQuarterState = new HasQuarterState( gumballMachine, stringWriter );

            hasQuarterState.InsertQuarter();
            hasQuarterState.EjectQuarter();

            result.WriteLine( BaseConstants.INSERT_QUARTER_HAS_QUARTER_STATE );
            result.WriteLine( BaseConstants.EJECT_QUARTER_HAS_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void TurnCrankTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 3, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 3 } gumball{ ( 3 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_SOLD_STATE })";
            var hasQuarterState = new HasQuarterState( gumballMachine, stringWriter );

            hasQuarterState.InsertQuarter();
            hasQuarterState.TurnCrank();

            result.WriteLine( BaseConstants.INSERT_QUARTER_HAS_QUARTER_STATE );
            result.WriteLine( BaseConstants.TURN_CRANK_HAS_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void DispenseTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 3, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 3 } gumball{ ( 3 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var hasQuarterState = new HasQuarterState( gumballMachine, stringWriter );

            hasQuarterState.Dispense();
            result.WriteLine( BaseConstants.DISPENSE_HAS_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ToStringTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 3, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 3 } gumball{ ( 3 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var hasQuarterState = new HasQuarterState( gumballMachine, stringWriter );

            Assert.AreEqual(BaseConstants.TO_STRING_HAS_QUARTER_STATE, hasQuarterState.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }
    }
}
