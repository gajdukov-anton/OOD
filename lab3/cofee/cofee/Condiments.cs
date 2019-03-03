namespace cofee
{
    public enum IceCubeType
    {
        Dry = 0,    // Сухой лед (для суровых сибирских мужиков)
        Water = 1	// Обычные кубики из воды
    }

    public enum SyrupType
    {
        Chocolate = 0,  // Шоколадный
        Maple = 1,      // Кленовый
    };

    public enum LiquorType
    {
        Walnut = 0,
        Chocolate = 1
    }

    public abstract class CondimentDecorator : IBeverage
    {
        private IBeverage _beverage;

        public string GetDescription()
        {
            return $"{_beverage.GetDescription()}, {GetCondimentDescription()}";
        }

        public double GetCost()
        {
            return _beverage.GetCost() + GetCondimentCost();
        }

        public abstract string GetCondimentDescription();

        public abstract double GetCondimentCost();

        protected CondimentDecorator( IBeverage beverage )
        {
            _beverage = beverage;
        }
    }

    public class Cinnamon : CondimentDecorator
    {
        public Cinnamon( IBeverage beverage )
            : base( beverage )
        {
        }

        public override double GetCondimentCost()
        {
            return 20;
        }

        public override string GetCondimentDescription()
        {
            return "Cinnamon";
        }
    }

    public class Lemon : CondimentDecorator
    {
        private int _quantity;
        public Lemon( IBeverage beverage, int quantity = 1 )
            : base( beverage )
        {
            _quantity = quantity;
        }


        public override double GetCondimentCost()
        {
            return 10 * _quantity;
        }

        public override string GetCondimentDescription()
        {
            return "Lemon x " + _quantity.ToString();
        }
    }

    public class IceCubes : CondimentDecorator
    {
        private int _quantity;
        private IceCubeType _type;
        public IceCubes( IBeverage beverage, int quantity, IceCubeType type = IceCubeType.Water )
            : base( beverage )
        {
            _quantity = quantity;
            _type = type;
        }

        public override double GetCondimentCost()
        {
            return ( _type == IceCubeType.Dry ? 10 : 5 ) * _quantity;
        }

        public override string GetCondimentDescription()
        {
            return $"{( _type == IceCubeType.Dry ? "Dry" : "Water" )} ice cubes x {_quantity}";
        }
    }

    public class Syrup : CondimentDecorator
    {
        private SyrupType _syrupType;

        public Syrup( IBeverage beverage, SyrupType syrupType )
            :base(beverage)
        {
            _syrupType = syrupType;
        }

        public override double GetCondimentCost()
        {
            return 15;
        }

        public override string GetCondimentDescription()
        {
            return $"{( _syrupType == SyrupType.Chocolate ? "Chocolate" : "Maple" )} syrup";
        }
    }

    public class ChocolateCrumbs : CondimentDecorator
    {
        private int _mass;

        public ChocolateCrumbs( IBeverage beverage, int mass )
            :base(beverage)
        {
            _mass = mass;
        }

        public override double GetCondimentCost()
        {
            return 2 * _mass;
        }

        public override string GetCondimentDescription()
        {
            return $"Chocolate crumbs {_mass.ToString()}g";
        }
    }

    public class CoconutFlakes : CondimentDecorator
    {
        private int _mass;

        public CoconutFlakes( IBeverage beverage, int mass )
        : base( beverage )
        {
            _mass = mass;
        }

        public override double GetCondimentCost()
        {
            return _mass;
        }

        public override string GetCondimentDescription()
        {
            return $"Coconut flakes {_mass.ToString()}g";
        }
    }

    public class Cream : CondimentDecorator
    {

        public Cream( IBeverage beverage )
            :base(beverage)
        {

        }

        public override double GetCondimentCost()
        {
            return 25;
        }

        public override string GetCondimentDescription()
        {
            return "Cream";
        }
    }

    public class ChocolateSlice : CondimentDecorator
    {
        private int _amount;

        public ChocolateSlice( IBeverage beverage, int amount)
            :base(beverage)
        {
            _amount = amount > 5 ? 5 : amount;
        }

        public override double GetCondimentCost()
        {
            return _amount * 10;
        }

        public override string GetCondimentDescription()
        {
            return $"Chocolate slice x{_amount}";
        }
    }

    public class Liqour : CondimentDecorator
    {
        private LiquorType _type;

        public Liqour( IBeverage beverage, LiquorType type)
            :base(beverage)
        {
            _type = type;
        }

        public override double GetCondimentCost()
        {
            return 50;
        }

        public override string GetCondimentDescription()
        {
            return $"{_type.ToString()} liqour";
        }
    }
}
