namespace GumballMachine.Utils
{
    public class QuarterCounter
    {
        private const uint MAXT_QUARTER_AMOUNT = 5;
        public uint QuarterAmount { get; private set; }

        public QuarterCounter()
        {
        }

        public void Inc()
        {
            if (QuarterAmount < MAXT_QUARTER_AMOUNT )
            {
                QuarterAmount++;
            }
        }

        public void Dec()
        {
            if (QuarterAmount > 0 )
            {
                QuarterAmount--;
            }
        }

        public void Zeroize()
        {
            QuarterAmount = 0;
        }

        public bool IsIncAvailable()
        {
            return QuarterAmount < MAXT_QUARTER_AMOUNT;
        }

        public bool IsEmptyCounter()
        {
            return QuarterAmount == 0;
        }
    }
}
