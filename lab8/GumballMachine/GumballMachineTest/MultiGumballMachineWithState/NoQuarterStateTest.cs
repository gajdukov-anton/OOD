using GumballMachine.MultiGumballMachine;
using GumballMachine.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace GumballMachineTest.MultiGumballMachineWithState
{
    [TestClass]
    public class NoQuarterStateTest
    {
        [TestMethod]
        public void InsertQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.MultiGumballMachine.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 1 } quarter{ ( 1 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_HAS_QUARTER_STATE })";
            var noQuarterState = new NoQuarterState( gumballMachine, stringWriter );

            noQuarterState.InsertQuarter();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void EjectQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.MultiGumballMachine.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var noQuarterState = new NoQuarterState( gumballMachine, stringWriter );

            noQuarterState.EjectQuarter();
            result.WriteLine( BaseConstants.EJECT_QUARTER_NO_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void TurnCrankTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.MultiGumballMachine.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var noQuarterState = new NoQuarterState( gumballMachine, stringWriter );

            noQuarterState.TurnCrank();
            result.WriteLine( BaseConstants.TURN_CRANK_NO_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void DespenseTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.MultiGumballMachine.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var noQuarterState = new NoQuarterState( gumballMachine, stringWriter );

            noQuarterState.Dispense();
            result.WriteLine( BaseConstants.DISPENSE_NO_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ReFillTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.MultiGumballMachine.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var noQuarterState = new NoQuarterState( gumballMachine, stringWriter );

            noQuarterState.ReFill( 10 );
            result.WriteLine( MultiGumbalMachineConstants.REFILL_NO_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ToStringTest()
        {
            var stringWriter = new StringWriter();
            var gumballMachine = new GumballMachine.MultiGumballMachine.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var noQuarterState = new NoQuarterState( gumballMachine, stringWriter );

            Assert.AreEqual( noQuarterState.ToString(), BaseConstants.TO_STRING_NO_QUARTER_STATE );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }
    }
}
