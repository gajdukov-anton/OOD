using WeatherStation.WeatherData;

namespace WeatherStation
{
    class Program
    {
        static void Main( string [] args )
        {
            CWeatherData weatheDataOut = new CWeatherData( "Out of doors" );
            CWeatherData weatheDataIn = new CWeatherData( "Indoors" );

            CDisplay display = new CDisplay();
            weatheDataOut.RegisterObserver( display, 2 );

            CStatsDisplay statsDisplay = new CStatsDisplay();
            weatheDataOut.RegisterObserver( statsDisplay, 1 );

            weatheDataOut.SetMeasurements( 3, 0.7, 760 );
            //weatheDataOut.SetMeasurements( 4, 0.8, 761 );

            weatheDataIn.RegisterObserver( statsDisplay, 1 );
            weatheDataIn.RegisterObserver( display, 2 );

            weatheDataIn.SetMeasurements( 10, 0.8, 761 );
            //weatheDataIn.SetMeasurements( -10, 0.8, 761 );
        }
    }
}
