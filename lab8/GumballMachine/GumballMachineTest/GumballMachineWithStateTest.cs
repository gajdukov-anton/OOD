using Microsoft.VisualStudio.TestTools.UnitTesting;
using GumballMachine.GumbalMachineWithState;
using System.IO;

namespace GumballMachineTest
{
    [TestClass]
    public class GumballMachineWithStateTest
    {
        [TestMethod]
        public void NoQuarterStateAtCreationWithSomeBalls()
        {
            var stringWriter = new StringWriter();
            string result = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 10 } gumball{ ( 10 != 1 ? "s" : "" ) } Machine is { Constants.TO_STRING_NO_QUARTER_STATE })";

            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 10, stringWriter );
            Assert.AreEqual( result, gumballMachine.ToString() );
            Assert.AreEqual( ( uint ) 10, gumballMachine.GetBallsCount() );
        }

        [TestMethod]
        public void SoldOutStateAtCreationWithZeroBalls()
        {
            var stringWriter = new StringWriter();
            string result = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) } Machine is { Constants.TO_STRING_SOLD_OUT_STATE })";

            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 0, stringWriter );
            Assert.AreEqual( result, gumballMachine.ToString() );
            Assert.AreEqual( ( uint ) 0, gumballMachine.GetBallsCount() );
        }

        [TestMethod]
        public void GetBallsCountTest()
        {
            var stringWriter = new StringWriter();
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 0, stringWriter );
            Assert.AreEqual( ( uint ) 0, gumballMachine.GetBallsCount() );
            gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 10, stringWriter );
            Assert.AreEqual( ( uint ) 10, gumballMachine.GetBallsCount() );
        }

        [TestMethod]
        public void ReleaseBallTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            string gumballMachineStateResult = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) } Machine is { Constants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 1, stringWriter );

            gumballMachine.ReleaseBall();
            result.WriteLine( Constants.RELEASE_BALL );
            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateResult, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ReleaseBallWithSomeBallInMachine()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            string gumballMachineStateResult = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 9 } gumball{ ( 9 != 1 ? "s" : "" ) } Machine is { Constants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 10, stringWriter );

            gumballMachine.InsertQuarter();
            result.WriteLine( Constants.INSERT_QUARTER_NO_QUARTER_STATE );
            gumballMachine.TurnCrank();
            result.WriteLine( Constants.TURN_CRANK_HAS_QUARTER_STATE );
            result.WriteLine( Constants.RELEASE_BALL );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateResult, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ReleaseBallWithOneBallInMachine()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            string gumballMachineStateResult = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) } Machine is { Constants.TO_STRING_SOLD_OUT_STATE })";
            string gumballMachineHasQuarterState = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 1 } gumball{ ( 1 != 1 ? "s" : "" ) } Machine is { Constants.TO_STRING_HAS_QUARTER_STATE })";
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 1, stringWriter );

            gumballMachine.InsertQuarter();
            result.WriteLine( Constants.INSERT_QUARTER_NO_QUARTER_STATE );

            Assert.AreEqual( gumballMachineHasQuarterState, gumballMachine.ToString() );

            gumballMachine.TurnCrank();
            result.WriteLine( Constants.TURN_CRANK_HAS_QUARTER_STATE );
            result.WriteLine( Constants.RELEASE_BALL );
            result.WriteLine( Constants.DISPENSE_SOLD_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateResult, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ReleaseBallWithZeroBallsInMachine()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            string gumballMachineStateResult = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) } Machine is { Constants.TO_STRING_SOLD_OUT_STATE })";
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 0, stringWriter );

            gumballMachine.InsertQuarter();
            result.WriteLine( Constants.INSERT_QUARTER_SOLD_OUT_STATE );
            gumballMachine.TurnCrank();
            result.WriteLine( Constants.TURN_CRANK_SOLD_OUT_STATE );
            result.WriteLine( Constants.DISPENSE_SOLD_OUT_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateResult, gumballMachine.ToString() );
        }

        [TestMethod]
        public void InsertAndEjectWithSomeBallsTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            string gumballMachineStateResult = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 10 } gumball{ ( 10 != 1 ? "s" : "" ) } Machine is { Constants.TO_STRING_NO_QUARTER_STATE })";
            string gumballMachineHasQuarterState = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 10 } gumball{ ( 10 != 1 ? "s" : "" ) } Machine is { Constants.TO_STRING_HAS_QUARTER_STATE })";
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 10, stringWriter );

            gumballMachine.InsertQuarter();
            result.WriteLine( Constants.INSERT_QUARTER_NO_QUARTER_STATE );

            Assert.AreEqual( gumballMachineHasQuarterState, gumballMachine.ToString() );

            gumballMachine.EjectQuarter();
            result.WriteLine( Constants.EJECT_QUARTER_HAS_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateResult, gumballMachine.ToString() );
        }

        [TestMethod]
        public void InsertAndEjectWithZeroBallsTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            string gumballMachineStateResult = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) } Machine is { Constants.TO_STRING_SOLD_OUT_STATE })";
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 0, stringWriter );

            gumballMachine.InsertQuarter();
            result.WriteLine( Constants.INSERT_QUARTER_SOLD_OUT_STATE );
            gumballMachine.EjectQuarter();
            result.WriteLine( Constants.EJECT_QUARTER_SOLD_OUT_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateResult, gumballMachine.ToString() );
        }

        [ TestMethod]
        public void GumballMachineInNoQuarterStateTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var hasQuarterStateDescription = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 10 } gumball{ ( 10 != 1 ? "s" : "" ) } Machine is { Constants.TO_STRING_HAS_QUARTER_STATE })";
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 10, stringWriter );

            gumballMachine.InsertQuarter();
            result.WriteLine( Constants.INSERT_QUARTER_NO_QUARTER_STATE );

            Assert.AreEqual( hasQuarterStateDescription, gumballMachine.ToString() );

            gumballMachine.SetNoQuarterState();
            gumballMachine.EjectQuarter();
            result.WriteLine( Constants.EJECT_QUARTER_NO_QUARTER_STATE );
            gumballMachine.TurnCrank();
            result.WriteLine( Constants.TURN_CRANK_NO_QUARTER_STATE );
            result.WriteLine( Constants.DISPENSE_NO_QUARTER_STATE );
            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
        }

        [TestMethod]
        public void GumballMachineInHasQuarterStateTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var noQuarterStateDescription = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 10 } gumball{ ( 10 != 1 ? "s" : "" ) } Machine is { Constants.TO_STRING_NO_QUARTER_STATE })";
            var noQuarterStateDescriptionAfterDispense = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 9 } gumball{ ( 9 != 1 ? "s" : "" ) } Machine is { Constants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 10, stringWriter );

            gumballMachine.InsertQuarter();
            result.WriteLine( Constants.INSERT_QUARTER_NO_QUARTER_STATE );

            gumballMachine.InsertQuarter();
            result.WriteLine( Constants.INSERT_QUARTER_HAS_QUARTER_STATE );
            gumballMachine.EjectQuarter();
            result.WriteLine( Constants.EJECT_QUARTER_HAS_QUARTER_STATE );

            Assert.AreEqual( noQuarterStateDescription, gumballMachine.ToString() );

            gumballMachine.SetHasQuarterState();
            gumballMachine.TurnCrank();
            result.WriteLine( Constants.TURN_CRANK_HAS_QUARTER_STATE );
            result.WriteLine( Constants.RELEASE_BALL );

            Assert.AreEqual( noQuarterStateDescriptionAfterDispense, gumballMachine.ToString() );
            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
        }

        [TestMethod]
        public void GumballMachineInSoldOutStateTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 0, stringWriter );

            gumballMachine.InsertQuarter();
            result.WriteLine( Constants.INSERT_QUARTER_SOLD_OUT_STATE );
            gumballMachine.EjectQuarter();
            result.WriteLine( Constants.EJECT_QUARTER_SOLD_OUT_STATE );
            gumballMachine.TurnCrank();
            result.WriteLine( Constants.TURN_CRANK_SOLD_OUT_STATE );
            result.WriteLine( Constants.DISPENSE_SOLD_OUT_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
        }

        [TestMethod]
        public void GumballMachineInSoldStateTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachine.GumbalMachineWithState.GumballMachine( 0, stringWriter );

            gumballMachine.SetSoldState();
            gumballMachine.InsertQuarter();
            result.WriteLine( Constants.INSERT_QUARTER_SOLD_STATE );
            gumballMachine.EjectQuarter();
            result.WriteLine( Constants.EJECT_QUARTER_SOLD_STATE );
            gumballMachine.TurnCrank();
            result.WriteLine( Constants.TURN_CRANK_SOLD_STATE );
            result.WriteLine( Constants.DISPENSE_SOLD_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
        }
    }
}
