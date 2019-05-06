using GumballMachine.MultiGumballMachine;
using GumballMachine.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace GumballMachineTest.MultiGumballMachineWithState
{
    [TestClass]
    public class SoldOutStateTest
    {
        [TestMethod]
        public void InsertQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachineContext( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var soldOutState = new SoldOutState( gumballMachine, stringWriter );

            soldOutState.InsertQuarter();
            result.WriteLine( BaseConstants.INSERT_QUARTER_SOLD_OUT_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void EjectQuarterWithSomeQuartersTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachineContext( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_HAS_QUARTER_STATE })";
            var soldOutState = new SoldOutState( gumballMachine, stringWriter );

            gumballMachine.InsertQuarter();
            gumballMachine.InsertQuarter();
            soldOutState.EjectQuarter();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 2 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetEjectQuarterSoldOutStateConst( 2 ) );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void EjectQuarterWithZeroQuartersTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachineContext( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
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
            var gumballMachine = new GumballMachineContext( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
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
            var gumballMachine = new GumballMachineContext( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var soldOutState = new SoldOutState( gumballMachine, stringWriter );

            soldOutState.Dispense();
            result.WriteLine( BaseConstants.DISPENSE_SOLD_OUT_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ReFillWithZeroBallsTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachineContext( 0, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_SOLD_OUT_STATE })";
            var soldOutState = new SoldOutState( gumballMachine, stringWriter );

            soldOutState.ReFill( 0 );
            result.WriteLine( MultiGumbalMachineConstants.GetReFillSoldOutStateConst( 0 ) );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ReFillWithSomeBallsTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachineContext( 0, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 10 } gumball{ ( 10 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var soldOutState = new SoldOutState( gumballMachine, stringWriter );

            soldOutState.ReFill( 10 );
            result.WriteLine( MultiGumbalMachineConstants.GetReFillSoldOutStateConst( 10 ) );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ReFillWithSomeQuartersTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachineContext( 1, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 10 } gumball{ ( 10 != 1 ? "s" : "" ) }" +
                $" { 1 } quarter{ ( 1 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_HAS_QUARTER_STATE })";
            var soldOutState = new SoldOutState( gumballMachine, stringWriter );

            gumballMachine.InsertQuarter();
            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            soldOutState.ReFill( 10 );
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 2 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 1 ) );
            result.WriteLine( BaseConstants.RELEASE_BALL );
            result.WriteLine( BaseConstants.DISPENSE_SOLD_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetReFillSoldOutStateConst( 10 ) );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ToStringTest()
        {
            var stringWriter = new StringWriter();
            var gumballMachine = new GumballMachineContext( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var soldOutState = new SoldOutState( gumballMachine, stringWriter );

            Assert.AreEqual( soldOutState.ToString(), BaseConstants.TO_STRING_SOLD_OUT_STATE );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }
    }
}
