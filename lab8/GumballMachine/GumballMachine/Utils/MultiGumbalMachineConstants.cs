namespace GumballMachine.Utils
{
    public static class MultiGumbalMachineConstants
    {
        public static readonly string INSERT_QUARTER_MAX_LIMIT_HAS_QUARTER_STATE = "You can't insert another quarter, total quarter amount is max";
        public static readonly string REFILL_HAS_QUARTER_STATE = "You can't refill, because gumball machine has some quarters";

        public static readonly string REFILL_NO_QUARTER_STATE = "You can't refill, because gumball machine has some balls yet";

        public static readonly string REFILL_SOLD_STATE = "You can't refill, because gumball machine is sollding ball";

        public static string GetInsertQuarterHasQuarterStateConst( uint quarterAmount )
        {
            return $"You inserted a quarter, total quarter amount: {quarterAmount}";
        }

        public static string GetEjectQuarterHasQuarterStateConst( uint quarterAmount )
        {
            return $"All quarters({quarterAmount }) returned";
        }

        public static string GetTurnCrankHasQuarterStateConst( uint quarterAmount )
        {
            return $"You turned, current quarter amount: {quarterAmount }";
        }

        public static string GetEjectQuarterSoldOutStateConst( uint quarterAmount )
        {
            return $"All quarters({quarterAmount }) returned";
        }

        public static string GetReFillSoldOutStateConst( uint ballAmount )
        {
            return $"{ballAmount} ball{( ballAmount != 1 ? "s" : "" )} {( ballAmount != 1 ? "was" : "were" )} added";
        }
    }
}
