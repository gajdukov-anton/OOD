using WeatherStation.WeatherData;
using System;

namespace WeatherStation
{
    class Program
    {
        static void Main( string [] args )
        {
            WeatherData.WeatherData wd = new WeatherData.WeatherData();
            StatsDisplay statsDisplay = new StatsDisplay();
            Display display = new Display();

            wd.RegisterObserver( display, 5 );
            wd.RegisterObserver( statsDisplay, 4 );
            wd.SetMeasurements( 3, 0.7, 760, 10, 90 );
            wd.SetMeasurements( 4, 0.8, 761, 8, 100 );
        }

    }
}
