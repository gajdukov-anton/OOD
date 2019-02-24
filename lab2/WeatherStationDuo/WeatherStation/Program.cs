using WeatherStation.WeatherData;

namespace WeatherStation
{
    class Program
    {
        static void Main( string [] args )
        {
            WeatherData.WeatherData weatheDataOut = new WeatherData.WeatherData( Observer.LocationKind.Outside );
            WeatherData.WeatherData weatheDataIn = new WeatherData.WeatherData( Observer.LocationKind.Inside );

            Display display = new Display(weatheDataIn, weatheDataOut, 1);
            StatsDisplay statsDisplay = new StatsDisplay( weatheDataIn, weatheDataOut, 2);

            weatheDataOut.SetMeasurements( 3, 0.7, 760 );
            weatheDataIn.SetMeasurements( 10, 0.8, 761 );
        }
    }
}
