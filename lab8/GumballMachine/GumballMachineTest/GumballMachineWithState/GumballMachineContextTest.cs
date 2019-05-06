using Microsoft.VisualStudio.TestTools.UnitTesting;
using GumballMachine.GumballMachineWithState;
using System.IO;
using GumballMachine.Utils;

namespace GumballMachineTest.GumballMachineWithState
{
    [TestClass]
    public class GumballMachineContextTest
    {
        [TestMethod]
        public void NoQuarterStateAtCreationWithSomeBalls()
        {
            var stringWriter = new StringWriter();
            string result = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 10 } gumball{ ( 10 != 1 ? "s" : "" ) } Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";

            var gumballMachine = new GumballMachineContext( 10, stringWriter );
            Assert.AreEqual( result, gumballMachine.ToString() );
            Assert.AreEqual( ( uint ) 10, gumballMachine.GetBallsCount() );
        }

        [TestMethod]
        public void SoldOutStateAtCreationWithZeroBalls()
        {
            var stringWriter = new StringWriter();
            string result = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) } Machine is { BaseConstants.TO_STRING_SOLD_OUT_STATE })";

            var gumballMachine = new GumballMachineContext( 0, stringWriter );
            Assert.AreEqual( result, gumballMachine.ToString() );
            Assert.AreEqual( ( uint ) 0, gumballMachine.GetBallsCount() );
        }

        [TestMethod]
        public void GetBallsCountTest()
        {
            var stringWriter = new StringWriter();
            var gumballMachine = new GumballMachineContext( 0, stringWriter );
            Assert.AreEqual( ( uint ) 0, gumballMachine.GetBallsCount() );
            gumballMachine = new GumballMachineContext( 10, stringWriter );
            Assert.AreEqual( ( uint ) 10, gumballMachine.GetBallsCount() );
        }

        [TestMethod]
        public void ReleaseBallTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            string gumballMachineStateResult = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) } Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 1, stringWriter );

            gumballMachine.ReleaseBall();
            result.WriteLine( BaseConstants.RELEASE_BALL );
            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateResult, gumballMachine.ToString() );
        }

        [TestMethod]
        public void InsertOneQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            string gumballMachineStateResult = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 1 } gumball{ ( 1 != 1 ? "s" : "" ) } Machine is { BaseConstants.TO_STRING_HAS_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 1, stringWriter );

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
            var gumballMachine = new GumballMachineContext( 1, stringWriter );

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
            var gumballMachine = new GumballMachineContext( 0, stringWriter );

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
            var gumballMachine = new GumballMachineContext( 0, stringWriter );

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
            var gumballMachine = new GumballMachineContext( 1, stringWriter );

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
            var gumballMachine = new GumballMachineContext( 1, stringWriter );

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
            var gumballMachine = new GumballMachineContext( 1, stringWriter );

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
            var gumballMachine = new GumballMachineContext( 2, stringWriter );

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
            var gumballMachine = new GumballMachineContext( 1, stringWriter );

            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( BaseConstants.TURN_CRANK_HAS_QUARTER_STATE );
            result.WriteLine( BaseConstants.RELEASE_BALL );
            result.WriteLine( BaseConstants.DISPENSE_SOLD_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateResult, gumballMachine.ToString() );
        }

        [ TestMethod]
        public void GumballMachineInNoQuarterStateTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var hasQuarterStateDescription = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 10 } gumball{ ( 10 != 1 ? "s" : "" ) } Machine is { BaseConstants.TO_STRING_HAS_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 10, stringWriter );

            gumballMachine.InsertQuarter();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );

            Assert.AreEqual( hasQuarterStateDescription, gumballMachine.ToString() );

            gumballMachine.SetNoQuarterState();
            gumballMachine.EjectQuarter();
            result.WriteLine( BaseConstants.EJECT_QUARTER_NO_QUARTER_STATE );
            gumballMachine.TurnCrank();
            result.WriteLine( BaseConstants.TURN_CRANK_NO_QUARTER_STATE );
            result.WriteLine( BaseConstants.DISPENSE_NO_QUARTER_STATE );
            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
        }

        [TestMethod]
        public void GumballMachineInHasQuarterStateTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var noQuarterStateDescription = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 10 } gumball{ ( 10 != 1 ? "s" : "" ) } Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var noQuarterStateDescriptionAfterDispense = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 9 } gumball{ ( 9 != 1 ? "s" : "" ) } Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 10, stringWriter );

            gumballMachine.InsertQuarter();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );

            gumballMachine.InsertQuarter();
            result.WriteLine( BaseConstants.INSERT_QUARTER_HAS_QUARTER_STATE );
            gumballMachine.EjectQuarter();
            result.WriteLine( BaseConstants.EJECT_QUARTER_HAS_QUARTER_STATE );

            Assert.AreEqual( noQuarterStateDescription, gumballMachine.ToString() );

            gumballMachine.SetHasQuarterState();
            gumballMachine.TurnCrank();
            result.WriteLine( BaseConstants.TURN_CRANK_HAS_QUARTER_STATE );
            result.WriteLine( BaseConstants.RELEASE_BALL );

            Assert.AreEqual( noQuarterStateDescriptionAfterDispense, gumballMachine.ToString() );
            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
        }

        [TestMethod]
        public void GumballMachineInSoldOutStateTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachineContext( 0, stringWriter );

            gumballMachine.InsertQuarter();
            result.WriteLine( BaseConstants.INSERT_QUARTER_SOLD_OUT_STATE );
            gumballMachine.EjectQuarter();
            result.WriteLine( BaseConstants.EJECT_QUARTER_SOLD_OUT_STATE );
            gumballMachine.TurnCrank();
            result.WriteLine( BaseConstants.TURN_CRANK_SOLD_OUT_STATE );
            result.WriteLine( BaseConstants.DISPENSE_SOLD_OUT_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
        }

        [TestMethod]
        public void GumballMachineInSoldStateTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachineContext( 0, stringWriter );

            gumballMachine.SetSoldState();
            gumballMachine.InsertQuarter();
            result.WriteLine( BaseConstants.INSERT_QUARTER_SOLD_STATE );
            gumballMachine.EjectQuarter();
            result.WriteLine( BaseConstants.EJECT_QUARTER_SOLD_STATE );
            gumballMachine.TurnCrank();
            result.WriteLine( BaseConstants.TURN_CRANK_SOLD_STATE );
            result.WriteLine( BaseConstants.DISPENSE_SOLD_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
        }
    }
}
