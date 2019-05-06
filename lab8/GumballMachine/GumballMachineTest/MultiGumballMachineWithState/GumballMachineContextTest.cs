using GumballMachine.MultiGumballMachine;
using GumballMachine.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace GumballMachineTest.MultiGumballMachineWithState
{
    [TestClass]
    public class GumballMachineContextTest
    {
        [TestMethod]
        public void GetBallsCountTest()
        {
            var stringWriter = new StringWriter();
            var gumballMachine = new GumballMachineContext( 2, stringWriter );

            Assert.AreEqual( ( uint ) 2, gumballMachine.GetBallsCount() );
        }

        [TestMethod]
        public void ReleaseBallTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 1 } gumball{ ( 1 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 2, stringWriter );

            gumballMachine.ReleaseBall();
            result.WriteLine( BaseConstants.RELEASE_BALL );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void InitializeMultiGumballMachineWithSomeBallsTest()
        {
            var stringWriter = new StringWriter();
            var result = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 2, stringWriter );

            Assert.AreEqual( result, gumballMachine.ToString() );
        }

        [TestMethod]
        public void InitializeMultiGumballMachineWithZeroBallsTest()
        {
            var stringWriter = new StringWriter();
            var result = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_SOLD_OUT_STATE })";
            var gumballMachine = new GumballMachineContext( 0, stringWriter );

            Assert.AreEqual( result, gumballMachine.ToString() );
        }

        [TestMethod]
        public void InsertQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
               $" { 1 } quarter{ ( 1 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_HAS_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 2, stringWriter );

            gumballMachine.InsertQuarter();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void InsertSomeQuartersTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
               $" { 3 } quarter{ ( 3 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_HAS_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 2, stringWriter );

            for ( int i = 0; i < 3; i++ )
            {
                gumballMachine.InsertQuarter();
            }
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 2 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 3 ) );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void InsertOverLimitQuartersTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
               $" { 5 } quarter{ ( 5 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_HAS_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 2, stringWriter );

            for ( int i = 0; i < 6; i++ )
            {
                gumballMachine.InsertQuarter();
            }
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            for ( int i = 0; i < 4; i++ )
            {
                result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( ( uint ) ( i + 2 ) ) );
            }
            result.WriteLine( MultiGumbalMachineConstants.INSERT_QUARTER_MAX_LIMIT_HAS_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void InsertSomeQuartersThenEjectAllQuartersTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
               $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 2, stringWriter );

            for ( int i = 0; i < 3; i++ )
            {
                gumballMachine.InsertQuarter();
            }
            gumballMachine.EjectQuarter();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 2 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 3 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetEjectQuarterHasQuarterStateConst( 3 ) );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void InsertQuarterWithZeroBallsTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) }" +
               $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_SOLD_OUT_STATE })";
            var gumballMachine = new GumballMachineContext( 0, stringWriter );

            gumballMachine.InsertQuarter();
            result.WriteLine( BaseConstants.INSERT_QUARTER_SOLD_OUT_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void EjectQuarterWithZeroBallsTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) }" +
               $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_SOLD_OUT_STATE })";
            var gumballMachine = new GumballMachineContext( 0, stringWriter );

            gumballMachine.EjectQuarter();
            result.WriteLine( BaseConstants.EJECT_QUARTER_SOLD_OUT_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void EjectQuarterWithSomeBallsAndZeroQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
               $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 2, stringWriter );

            gumballMachine.EjectQuarter();
            result.WriteLine( BaseConstants.EJECT_QUARTER_NO_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void TurnCrankWithSomeBallsAndZeroQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
               $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 2, stringWriter );

            gumballMachine.TurnCrank();
            result.WriteLine( BaseConstants.TURN_CRANK_NO_QUARTER_STATE );
            result.WriteLine( BaseConstants.DISPENSE_NO_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void TurnKrankWithSomeBallsAndSomeQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
               $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 4, stringWriter );

            gumballMachine.InsertQuarter();
            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            gumballMachine.TurnCrank();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 2 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 1 ) );
            result.WriteLine( BaseConstants.RELEASE_BALL );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 0 ) );
            result.WriteLine( BaseConstants.RELEASE_BALL );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void TurnKrankWithQuartersMoreThenBallsTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) }" +
               $" { 2 } quarter{ ( 2 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_SOLD_OUT_STATE })";
            var gumballMachine = new GumballMachineContext( 2, stringWriter );

            for ( int i = 0; i < 4; i++ )
            {
                gumballMachine.InsertQuarter();
            }
            for ( int i = 0; i < 4; i++ )
            {
                gumballMachine.TurnCrank();
            }

            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 2 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 3 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 4 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 3 ) );
            result.WriteLine( BaseConstants.RELEASE_BALL );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 2 ) );
            result.WriteLine( BaseConstants.RELEASE_BALL );
            result.WriteLine( BaseConstants.DISPENSE_SOLD_STATE );
            result.WriteLine( BaseConstants.TURN_CRANK_SOLD_OUT_STATE );
            result.WriteLine( BaseConstants.DISPENSE_SOLD_OUT_STATE );
            result.WriteLine( BaseConstants.TURN_CRANK_SOLD_OUT_STATE );
            result.WriteLine( BaseConstants.DISPENSE_SOLD_OUT_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void TurnKrankAndEjectSomeQuartersTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
               $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 4, stringWriter );

            for ( int i = 0; i < 4; i++ )
            {
                gumballMachine.InsertQuarter();
            }
            gumballMachine.TurnCrank();
            gumballMachine.TurnCrank();
            gumballMachine.EjectQuarter();

            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 2 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 3 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 4 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 3 ) );
            result.WriteLine( BaseConstants.RELEASE_BALL );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 2 ) );
            result.WriteLine( BaseConstants.RELEASE_BALL );
            result.WriteLine( MultiGumbalMachineConstants.GetEjectQuarterHasQuarterStateConst( 2 ) );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void TurnKrankMoreThenInsertQuartersTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
               $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 4, stringWriter );

            gumballMachine.InsertQuarter();
            gumballMachine.InsertQuarter();
            for ( int i = 0; i < 4; i++ )
            {
                gumballMachine.TurnCrank();
            }

            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 2 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 1 ) );
            result.WriteLine( BaseConstants.RELEASE_BALL );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 0 ) );
            result.WriteLine( BaseConstants.RELEASE_BALL );
            result.WriteLine( BaseConstants.TURN_CRANK_NO_QUARTER_STATE );
            result.WriteLine( BaseConstants.DISPENSE_NO_QUARTER_STATE );
            result.WriteLine( BaseConstants.TURN_CRANK_NO_QUARTER_STATE );
            result.WriteLine( BaseConstants.DISPENSE_NO_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void TurnKrankThenBallsOverTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) }" +
               $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_SOLD_OUT_STATE })";
            var gumballMachine = new GumballMachineContext( 2, stringWriter );

            gumballMachine.InsertQuarter();
            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            gumballMachine.TurnCrank();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 2 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 1 ) );
            result.WriteLine( BaseConstants.RELEASE_BALL );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 0 ) );
            result.WriteLine( BaseConstants.RELEASE_BALL );
            result.WriteLine( BaseConstants.DISPENSE_SOLD_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ReFillAfterCreationWithSomeBallsTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
               $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 2, stringWriter );

            gumballMachine.ReFill( 10 );
            result.WriteLine( MultiGumbalMachineConstants.REFILL_NO_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ReFillAfterCreationWithZeroBalls()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 10 } gumball{ ( 10 != 1 ? "s" : "" ) }" +
               $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 0, stringWriter );

            gumballMachine.ReFill( 10 );
            result.WriteLine( MultiGumbalMachineConstants.GetReFillSoldOutStateConst( 10 ) );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ReFillAfterInsertQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
               $" { 1 } quarter{ ( 1 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_HAS_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 2, stringWriter );

            gumballMachine.InsertQuarter();
            gumballMachine.ReFill( 10 );
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( MultiGumbalMachineConstants.REFILL_HAS_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ReFillWithSomeBallsAfterEndingBallsTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 10 } gumball{ ( 10 != 1 ? "s" : "" ) }" +
               $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 1, stringWriter );

            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            gumballMachine.ReFill( 10 );
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 0 ) );
            result.WriteLine( BaseConstants.RELEASE_BALL );
            result.WriteLine( BaseConstants.DISPENSE_SOLD_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetReFillSoldOutStateConst( 10 ) );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ReFillWithZeroBallsAfterEndingBallsTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 0 } gumball{ ( 0 != 1 ? "s" : "" ) }" +
               $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_SOLD_OUT_STATE })";
            var gumballMachine = new GumballMachineContext( 1, stringWriter );

            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            gumballMachine.ReFill( 0 );
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 0 ) );
            result.WriteLine( BaseConstants.RELEASE_BALL );
            result.WriteLine( BaseConstants.DISPENSE_SOLD_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetReFillSoldOutStateConst( 0 ) );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ReFillWithSomeBallsAfterEndingWithSomeQuarters()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 10 } gumball{ ( 10 != 1 ? "s" : "" ) }" +
               $" { 1 } quarter{ ( 1 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_HAS_QUARTER_STATE })";
            var gumballMachine = new GumballMachineContext( 1, stringWriter );

            gumballMachine.InsertQuarter();
            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            gumballMachine.ReFill( 10 );

            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );

            gumballMachine.TurnCrank();
            result.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 2 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 1 ) );
            result.WriteLine( BaseConstants.RELEASE_BALL );
            result.WriteLine( BaseConstants.DISPENSE_SOLD_STATE );
            result.WriteLine( MultiGumbalMachineConstants.GetReFillSoldOutStateConst( 10 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 0 ) );
            result.WriteLine( BaseConstants.RELEASE_BALL );

            gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
               $" { 9 } gumball{ ( 9 != 1 ? "s" : "" ) }" +
               $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
               $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }
    }
}
