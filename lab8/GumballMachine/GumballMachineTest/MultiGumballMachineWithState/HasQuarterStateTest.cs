using GumballMachine.MultiGumballMachine;
using GumballMachine.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace GumballMachineTest.MultiGumballMachineWithState
{
    [TestClass]
    public class HasQuarterStateTest
    {
        [TestMethod]
        public void InsertSomeQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachineContext( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 2 } quarter{ ( 2 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var hasQuarterState = new HasQuarterState( gumballMachine, stringWriter );

            hasQuarterState.InsertQuarter();
            hasQuarterState.InsertQuarter();

            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 1 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 2 ) );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void InsertMaxQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachineContext( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 5 } quarter{ ( 5 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var hasQuarterState = new HasQuarterState( gumballMachine, stringWriter );

            for ( int i = 0; i < 6; i++ )
            {
                hasQuarterState.InsertQuarter();
            }
            for ( uint i = 0; i < 5; i++ )
            {
                result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( i + 1 ) );
            }
            result.WriteLine( MultiGumbalMachineConstants.INSERT_QUARTER_MAX_LIMIT_HAS_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void EjectQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachineContext( 2, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 2 } gumball{ ( 2 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var hasQuarterState = new HasQuarterState( gumballMachine, stringWriter );

            hasQuarterState.InsertQuarter();
            hasQuarterState.InsertQuarter();
            hasQuarterState.EjectQuarter();

            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 1 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 2 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetEjectQuarterHasQuarterStateConst( 2 ) );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void TurnCrankWithOneQuarterTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachineContext( 3, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 3 } gumball{ ( 3 != 1 ? "s" : "" ) }" +
                $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_SOLD_STATE })";
            var hasQuarterState = new HasQuarterState( gumballMachine, stringWriter );

            hasQuarterState.InsertQuarter();
            hasQuarterState.TurnCrank();

            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 1 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 0 ) );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void TurnCrankWithSomeQurtersTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachineContext( 3, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { 3 } gumball{ ( 3 != 1 ? "s" : "" ) }" +
                $" { 1 } quarter{ ( 1 != 1 ? "s" : "" ) } " +
                $"Machine is { BaseConstants.TO_STRING_SOLD_STATE })";
            var hasQuarterState = new HasQuarterState( gumballMachine, stringWriter );

            hasQuarterState.InsertQuarter();
            hasQuarterState.InsertQuarter();
            hasQuarterState.TurnCrank();

            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 1 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( 2 ) );
            result.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( 1 ) );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void DispenseTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachineContext( 3, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 3 } gumball{ ( 3 != 1 ? "s" : "" ) }" +
              $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
              $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var hasQuarterState = new HasQuarterState( gumballMachine, stringWriter );

            hasQuarterState.Dispense();
            result.WriteLine( BaseConstants.DISPENSE_HAS_QUARTER_STATE );

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ReFillTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachineContext( 3, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 3 } gumball{ ( 3 != 1 ? "s" : "" ) }" +
              $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
              $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var hasQuarterState = new HasQuarterState( gumballMachine, stringWriter );

            hasQuarterState.ReFill(10);
            result.WriteLine( MultiGumbalMachineConstants.REFILL_HAS_QUARTER_STATE);

            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }

        [TestMethod]
        public void ToStringTest()
        {
            var stringWriter = new StringWriter();
            var result = new StringWriter();
            var gumballMachine = new GumballMachineContext( 3, stringWriter );
            var gumballMachineStateString = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
              $" { 3 } gumball{ ( 3 != 1 ? "s" : "" ) }" +
              $" { 0 } quarter{ ( 0 != 1 ? "s" : "" ) } " +
              $"Machine is { BaseConstants.TO_STRING_NO_QUARTER_STATE })";
            var hasQuarterState = new HasQuarterState( gumballMachine, stringWriter );

            Assert.AreEqual(BaseConstants.TO_STRING_HAS_QUARTER_STATE, hasQuarterState.ToString() );
            Assert.AreEqual( gumballMachineStateString, gumballMachine.ToString() );
        }
    }
}
