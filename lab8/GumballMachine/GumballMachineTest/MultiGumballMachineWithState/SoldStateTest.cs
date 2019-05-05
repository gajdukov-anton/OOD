using GumballMachine.MultiGumballMachine;
using GumballMachine.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace GumballMachineTest.MultiGumballMachineWithState
{
    [TestClass]
    public class SoldStateTest
    {
        [TestMethod]
        public void InsertQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.MultiGumballMachine.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
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
            var gumballMachine = new GumballMachine.MultiGumballMachine.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
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
            var gumballMachine = new GumballMachine.MultiGumballMachine.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var soldState = new SoldState( gumballMachine, stringWriter );

            soldState.TurnCrank();
            result.WriteLine( BaseConstants.TURN_CRANK_SOLD_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void DispenseWithSomeQuarterAndSomeBallsTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.MultiGumballMachine.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 1 } gumball{ ( 1 != 1 ? "s" : "" ) }" +
                $" { 2 } quarter{ ( 2 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_HAS_QUARTER_STATE })";
            var soldState = new SoldState( gumballMachine, stringWriter );

            gumballMachine.InsertQuarter();
            gumballMachine.InsertQuarter();
            soldState.Dispense();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 2 ) );
            result.WriteLine( BaseConstants.RELEASE_BALL );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void DispenseWithSomeBallsAndZeroQuartersTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.MultiGumballMachine.GumballMachine( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 1 } gumball{ ( 1 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var soldState = new SoldState( gumballMachine, stringWriter );

            soldState.Dispense();
            result.WriteLine( BaseConstants.RELEASE_BALL );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void DispenseWithZeroBallsAndSomeQuartersTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.MultiGumballMachine.GumballMachine( 1, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) }" +
                $" { 1 } quarter{ ( 1 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_SOLD_OUT_STATE })";
            var soldState = new SoldState( gumballMachine, stringWriter );
            var hasQuarterState = new HasQuarterState( gumballMachine, stringWriter );

            gumballMachine.InsertQuarter();
            gumballMachine.InsertQuarter();
            hasQuarterState.TurnCrank();
            soldState.Dispense();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 2 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 1 ) );
            result.WriteLine( BaseConstants.RELEASE_BALL );
            result.WriteLine( BaseConstants.DISPENSE_SOLD_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void DispenseWithZeroBallsAndZeroQuartersTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.MultiGumballMachine.GumballMachine( 1, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_SOLD_OUT_STATE })";
            var soldState = new SoldState( gumballMachine, stringWriter );
            var hasQuarterState = new HasQuarterState( gumballMachine, stringWriter );

            gumballMachine.InsertQuarter();
            hasQuarterState.TurnCrank();
            soldState.Dispense();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 0 ) );
            result.WriteLine( BaseConstants.RELEASE_BALL );
            result.WriteLine( BaseConstants.DISPENSE_SOLD_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }
    }
}
