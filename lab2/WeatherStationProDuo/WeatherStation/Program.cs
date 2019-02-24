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

            Display display = new Display(weatheDataIn, weatheDataOut, 1);
            StatsDisplay statsDisplay = new StatsDisplay( weatheDataIn, weatheDataOut, 2, CreateDefaultFuncForCalcAverWindDir());
            statsDisplay.AddFuncForCalcAverValue( "windDirection", CreateFuncForCalcAverWindDir() );
            statsDisplay.AddFuncForValidStatValue( "windDirection", CreateFuncForValidWindDir() );

            weatheDataOut.SetMeasurements( 3, 0.7, 760, 10, 90 );
            weatheDataIn.SetMeasurements( 10, 0.8, 761 );
        }

        public static Func<double, int, double> CreateDefaultFuncForCalcAverWindDir()
        {
            double accValue = 0;
            double CalculateAverageValue( double value, int countAcc )
            {
                accValue += value;
                return accValue / countAcc;
            }
            return CalculateAverageValue;
        }

        public static Func<double, int, double> CreateFuncForCalcAverWindDir()
        {
            double accXValue = 0;
            double accYValue = 0;
            double CalculateAverageWindDir( double windDirection, int countAcc )
            {
                accYValue += Math.Sin( windDirection * ( Math.PI / 180 ) );
                accXValue += Math.Cos( windDirection * ( Math.PI / 180 ) );
                return Math.Atan2( accYValue / countAcc, accXValue / countAcc ) * ( 180 / Math.PI );
            }
            return CalculateAverageWindDir;
        }

        public static Func<double, double> CreateFuncForValidWindDir()
        {
            double ValidateWindDirection( double windDirection )
            {
                if ( windDirection > 360 )
                {
                    return 360;
                }
                else if ( windDirection < 0 )
                {
                    return 0;
                }
                return windDirection;
            }
            return ValidateWindDirection;
        }
    }
}
