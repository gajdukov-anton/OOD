using WeatherStation.WeatherData;

namespace WeatherStation
{
    class Program
    {
        static void Main( string [] args )
        {
            var wd = new CWeatherData();
            var display1 = new CDisplay();
            var display2 = new CDisplay();
            var statsDisplay = new CStatsDisplay();

            wd.RegisterObserver( display1, 10 );
            wd.RegisterObserver( display2, 3 );
            wd.RegisterObserver( statsDisplay, 4 );

            wd.SetMeasurements( 3, 0.7, 760 );
            wd.SetMeasurements( 4, 0.8, 761 );

            wd.RemoveObserver( display1 );
            wd.RemoveObserver( display2 );

            wd.SetMeasurements( 10, 0.8, 761 );
            wd.SetMeasurements( -10, 0.8, 761 );
        }
    }
}
