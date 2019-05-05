namespace GumballMachine.Utils
{
    public static class BaseConstants
    {
        public static readonly string INSERT_QUARTER_HAS_QUARTER_STATE = "You can't insert another quarter";
        public static readonly string EJECT_QUARTER_HAS_QUARTER_STATE = "Quarter returned";
        public static readonly string TURN_CRANK_HAS_QUARTER_STATE = "You turned...";
        public static readonly string DISPENSE_HAS_QUARTER_STATE = "No gumball dispensed";
        public static readonly string TO_STRING_HAS_QUARTER_STATE = "waiting for turn of crank";

        public static readonly string INSERT_QUARTER_NO_QUARTER_STATE = "You inserted a quarter";
        public static readonly string EJECT_QUARTER_NO_QUARTER_STATE = "You haven't inserted a quarter";
        public static readonly string TURN_CRANK_NO_QUARTER_STATE = "You turned but there's no quarter";
        public static readonly string DISPENSE_NO_QUARTER_STATE = "You need to pay first";
        public static readonly string TO_STRING_NO_QUARTER_STATE = "waiting for quarter";

        public static readonly string INSERT_QUARTER_SOLD_OUT_STATE = "You can't insert a quarter, the machine is sold out";
        public static readonly string EJECT_QUARTER_SOLD_OUT_STATE = "You can't eject, you haven't inserted a quarter yet";
        public static readonly string TURN_CRANK_SOLD_OUT_STATE = "You turned but there's no gumballs";
        public static readonly string DISPENSE_SOLD_OUT_STATE = "No gumball dispensed";
        public static readonly string TO_STRING_SOLD_OUT_STATE = "sold out";

        public static readonly string INSERT_QUARTER_SOLD_STATE = "Please wait, we're already giving you a gumball";
        public static readonly string EJECT_QUARTER_SOLD_STATE = "Sorry you already turned the crank";
        public static readonly string TURN_CRANK_SOLD_STATE = "Turning twice doesn't get you another gumball";
        public static readonly string DISPENSE_SOLD_STATE = "Oops, out of gumballs";
        public static readonly string TO_STRING_SOLD_STATE = "delivering a gumball";

        public static readonly string RELEASE_BALL = "A gumball comes rolling out the slot...";
    }
}
