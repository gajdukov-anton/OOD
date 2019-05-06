using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using GumballMachine.Utils;

namespace GumballMachineTest.GumballMachineWithState
{
    [TestClass]
    public class GumballMachineTest 
    {
        [TestMethod]
        public void NoQuarterStateAtCreationWithSomeBalls()
        {
            var stringWriter = new StringWriter();
            string result = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 10 } gumball{ ( 10 != 1 ? "s" : "" ) } Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";

            var gumballMachine = new GumballMachine.GumballMachineWithState.GumballMachine( 10, stringWriter );
            Assert.AreEqual( result, gumballMachine.ToString() );
        }

        [TestMethod]
        public void SoldOutStateAtCreationWithZeroBalls()
        {
            var stringWriter = new StringWriter();
            string result = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) } Machine is { BaseConstants.TO_STRING_SOLD_OUT_STATE })";

            var gumballMachine = new GumballMachine.GumballMachineWithState.GumballMachine( 0, stringWriter );
            Assert.AreEqual( result, gumballMachine.ToString() );
        }

        [TestMethod]
        public void InsertOneQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            string gumballMachineStateResult = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 1 } gumball{ ( 1 != 1 ? "s" : "" ) } Machine is { BaseConstants.TO_STRING_HAS_QUARTER_STATE })";
            var gumballMachine = new GumballMachine.GumballMachineWithState.GumballMachine( 1, stringWriter );

            gumballMachine.InsertQuarter();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateResult, gumballMachine.ToString() );
        }

        [TestMethod]
        public void InsertSomeQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            string gumballMachineStateResult = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 1 } gumball{ ( 1 != 1 ? "s" : "" ) } Machine is { BaseConstants.TO_STRING_HAS_QUARTER_STATE })";
            var gumballMachine = new GumballMachine.GumballMachineWithState.GumballMachine( 1, stringWriter );

            gumballMachine.InsertQuarter();
            gumballMachine.InsertQuarter();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( BaseConstants.INSERT_QUARTER_HAS_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateResult, gumballMachine.ToString() );
        }

        [TestMethod]
        public void InsertQuarterWithZeroBallsTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            string gumballMachineStateResult = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) } Machine is { BaseConstants.TO_STRING_SOLD_OUT_STATE })";
            var gumballMachine = new GumballMachine.GumballMachineWithState.GumballMachine( 0, stringWriter );

            gumballMachine.InsertQuarter();
            result.WriteLine( BaseConstants.INSERT_QUARTER_SOLD_OUT_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateResult, gumballMachine.ToString() );
        }

        [TestMethod]
        public void EjectQuarterWithZeroBalls()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            string gumballMachineStateResult = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) } Machine is { BaseConstants.TO_STRING_SOLD_OUT_STATE })";
            var gumballMachine = new GumballMachine.GumballMachineWithState.GumballMachine( 0, stringWriter );

            gumballMachine.EjectQuarter();
            result.WriteLine( BaseConstants.EJECT_QUARTER_SOLD_OUT_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateResult, gumballMachine.ToString() );
        }

        [TestMethod]
        public void InsertAndEjectQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            string gumballMachineStateResult = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 1 } gumball{ ( 1 != 1 ? "s" : "" ) } Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachine.GumballMachineWithState.GumballMachine( 1, stringWriter );

            gumballMachine.InsertQuarter();
            gumballMachine.EjectQuarter();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( BaseConstants.EJECT_QUARTER_HAS_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateResult, gumballMachine.ToString() );
        }

        [TestMethod]
        public void InsertAndTwiceEjectQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            string gumballMachineStateResult = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 1 } gumball{ ( 1 != 1 ? "s" : "" ) } Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachine.GumballMachineWithState.GumballMachine( 1, stringWriter );

            gumballMachine.InsertQuarter();
            gumballMachine.EjectQuarter();
            gumballMachine.EjectQuarter();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( BaseConstants.EJECT_QUARTER_HAS_QUARTER_STATE );
            result.WriteLine( BaseConstants.EJECT_QUARTER_NO_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateResult, gumballMachine.ToString() );
        }

        [TestMethod]
        public void TurnCrankWithSomeBallsAndZeroQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            string gumballMachineStateResult = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 1 } gumball{ ( 1 != 1 ? "s" : "" ) } Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachine.GumballMachineWithState.GumballMachine( 1, stringWriter );

            gumballMachine.TurnCrank();
            result.WriteLine( BaseConstants.TURN_CRANK_NO_QUARTER_STATE );
            result.WriteLine( BaseConstants.DISPENSE_NO_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateResult, gumballMachine.ToString() );
        }

        [TestMethod]
        public void TurnCrankWithQuarterAndSomeBalls()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            string gumballMachineStateResult = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 1 } gumball{ ( 1 != 1 ? "s" : "" ) } Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachine.GumballMachineWithState.GumballMachine( 2, stringWriter );

            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( BaseConstants.TURN_CRANK_HAS_QUARTER_STATE );
            result.WriteLine( BaseConstants.RELEASE_BALL );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateResult, gumballMachine.ToString() );
        }

        [TestMethod]
        public void TurnCrankWithOneBallsAndQuartersTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            string gumballMachineStateResult = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) } Machine is { BaseConstants.TO_STRING_SOLD_OUT_STATE })";
            var gumballMachine = new GumballMachine.GumballMachineWithState.GumballMachine( 1, stringWriter );

            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( BaseConstants.TURN_CRANK_HAS_QUARTER_STATE );
            result.WriteLine( BaseConstants.RELEASE_BALL );
            result.WriteLine( BaseConstants.DISPENSE_SOLD_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateResult, gumballMachine.ToString() );
        }

    }
}
