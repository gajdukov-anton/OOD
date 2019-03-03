using System;
using WeatherStation.WeatherData;

namespace WeatherStation
{
    class Program
    {
        static void Main( string [] args )
        {
            WeatherDataOutside weatheDataOut = new WeatherDataOutside();
            WeatherDataInside weatheDataIn = new WeatherDataInside();
            Display display = new Display( weatheDataIn, weatheDataOut, 1 );
            StatsDisplay statsDisplay = new StatsDisplay( weatheDataIn, weatheDataOut, 0 );

            weatheDataOut.SetMeasurements( 3, 0.7, 760, 10, 90 );
            weatheDataIn.SetMeasurements( 10, 0.4, 661 );
            weatheDataOut.SetMeasurements( 4, 0.8, 761, 8, 100 );
        }
    }
}
