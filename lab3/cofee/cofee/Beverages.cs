
namespace Coffee
{
    public enum CofeePortionSize
    {
        Standart = 0,
        Double = 1
    }

    public enum TeaSort
    {
        White = 0,
        Black = 1,
        Green = 2,
        Red = 3
    }

    public enum MilkshakePortionSize
    {
        Small = 0,
        Medium = 1,
        Big = 2
    }

    public abstract class Beverage : IBeverage
    {
        private string _description;

        public Beverage( string desscription )
        {
            _description = desscription;
        }

        public string GetDescription()
        {
            return _description;
        }

        public abstract double GetCost();
    }

    public class Coffee : Beverage
    {
        protected CofeePortionSize _portionSize;

        public Coffee(CofeePortionSize portionSize = CofeePortionSize.Standart, string description = "Cofee" )
            : base( portionSize.ToString() + description )
        {
            _portionSize = portionSize;
        }

        public override double GetCost()
        {
            return 60;
        }
    }

    public class Capucino : Coffee
    {
        public Capucino( CofeePortionSize portionSize = CofeePortionSize.Standart )
            :base( portionSize, " Capucino" )
        {
        }

        public override double GetCost()
        {
            return _portionSize == CofeePortionSize.Standart ? 80 : 120;
        }
    }

    public class Latte : Coffee
    {
        public Latte( CofeePortionSize portionSize = CofeePortionSize.Standart )
            : base( portionSize, " Late" )
        {
        }

        public override double GetCost()
        {
            return _portionSize == CofeePortionSize.Standart ? 90 : 130;
        }
    }

    public class Tea : Beverage
    {
        public Tea(TeaSort teaSort = TeaSort.Black)
            :base(teaSort.ToString() + " Tea")
        {
        }

        public override double GetCost()
        {
            return 30;
        }
    }

    public class Milkshake : Beverage
    {
        protected MilkshakePortionSize _portionSize;

        public Milkshake(MilkshakePortionSize portionSize)
            :base(portionSize.ToString() + " Milkshake")
        {
            _portionSize = portionSize;
        }

        public override double GetCost()
        {
            switch (_portionSize)
            {
                case MilkshakePortionSize.Small:
                    return 50;
                case MilkshakePortionSize.Medium:
                    return 60;
                case MilkshakePortionSize.Big:
                    return 80;
                default:
                    return 0;
            }
        }
    }
}
