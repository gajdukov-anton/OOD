using WeatherStation.WeatherData;
using WeatherStation.Observer;

namespace WeatherStation
{
    class Program
    {
        static void Main( string [] args )
        {
            CWeatherData wd = new CWeatherData();

            CDisplay display = new CDisplay();
            wd.RegisterObserver( display, 0 );

            CDisplay display1 = new CDisplay();
            wd.RegisterObserver( display1, 10 );
            CDisplay display2 = new CDisplay();
            wd.RegisterObserver( display2, 3 );

            CStatsDisplay statsDisplay = new CStatsDisplay();
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
