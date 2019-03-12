using System;

namespace Coffee
{
    class Program
    {
        static void Main( string [] args )
        {
            { // Наливаем чашечку латте
                var latte = new Latte();
                // добавляем корицы
                var cinnamon = new Cinnamon( latte );
                // добавляем пару долек лимона
                var lemon = new Lemon( cinnamon, 2 );
                // добавляем пару кубиков льда
                var iceCubes = new IceCubes( lemon, 2, IceCubeType.Dry );
                // добавляем 2 грамма шоколадной крошки
                var beverage = new ChocolateCrumbs( iceCubes, 2 );

                // Выписываем счет покупателю
                Console.WriteLine( $"{beverage.GetDescription()} cost {beverage.GetCost()}" );
            }

            {
                var beverage = new ChocolateCrumbs( // Внешний слой: шоколадная крошка
                    new IceCubes( // | под нею - кубики льда
                        new Lemon( // | | еще ниже лимон
                            new Cinnamon( // | | | слоем ниже - корица
                                new Latte() ), // | | |   в самом сердце - Латте
                            2 ), // | | 2 дольки лимона
                        2, IceCubeType.Dry ), // | 2 кубика сухого льда
                    2 ); // 2 грамма шоколадной крошки

                // Выписываем счет покупателю
                Console.WriteLine( $"{beverage.GetDescription()} cost {beverage.GetCost()}" );
            }

            {
                var latte = new Latte(CofeePortionSize.Double);
                // добавляем корицы
                var cinnamon = new Cinnamon( latte );
                // добавляем пару долек лимона
                var lemon = new Lemon( cinnamon, 2 );
                // добавляем пару кубиков льда
                var iceCubes = new IceCubes( lemon, 2, IceCubeType.Dry );
                // добавляем 2 грамма шоколадной крошки
                var beverage = new ChocolateCrumbs( iceCubes, 2 );

                // Выписываем счет покупателю
                Console.WriteLine( $"{beverage.GetDescription()} cost {beverage.GetCost()}" );
            }

            {
                var capucino = new Capucino( CofeePortionSize.Double );
                // добавляем корицы
                var cinnamon = new Cinnamon( capucino );
                // добавляем пару долек лимона
                var lemon = new Lemon( cinnamon, 2 );
                // добавляем пару кубиков льда
                var iceCubes = new IceCubes( lemon, 2, IceCubeType.Dry );
                // добавляем 2 грамма шоколадной крошки
                var chocolateCrumbs = new ChocolateCrumbs( iceCubes, 2 );
                var cream = new Cream( chocolateCrumbs );
                var chocolatSlice = new ChocolateSlice( cream, 3 );
                var beverage = new Liqour( chocolatSlice, LiquorType.Walnut );

                // Выписываем счет покупателю
                Console.WriteLine( $"{beverage.GetDescription()} cost {beverage.GetCost()}" );
            }

            {
                var tea = new Tea( TeaSort.Red );
                // добавляем корицы
                var cinnamon = new Cinnamon( tea );
                // добавляем пару долек лимона
                var lemon = new Lemon( cinnamon, 2 );
                // добавляем пару кубиков льда
                var iceCubes = new IceCubes( lemon, 2, IceCubeType.Dry );
                // добавляем 2 грамма шоколадной крошки
                var beverage = new ChocolateCrumbs( iceCubes, 2 );

                // Выписываем счет покупателю
                Console.WriteLine( $"{beverage.GetDescription()} cost {beverage.GetCost()}" );
            }
        }
    }
}
