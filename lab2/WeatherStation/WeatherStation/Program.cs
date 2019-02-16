using WeatherStation.WeatherData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class Program
    {
        static void Main( string [] args )
        {
            CWeatherData wd = new CWeatherData();

            CDisplay display = new CDisplay();
            wd.RegisterObserver( display );

            CStatsDisplay statsDisplay = new CStatsDisplay();
            wd.RegisterObserver( statsDisplay );

            wd.SetMeasurements( 3, 0.7, 760 );
            wd.SetMeasurements( 4, 0.8, 761 );

            //wd.RemoveObserver( statsDisplay );

            wd.SetMeasurements( 10, 0.8, 761 );
            wd.SetMeasurements( -10, 0.8, 761 );
        }
    }
}
