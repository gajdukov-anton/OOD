﻿using WeatherStation.WeatherData;
using System;

namespace WeatherStation
{
    class Program
    {
        static void Main( string [] args )
        {
            WeatherData.WeatherData wd = new WeatherData.WeatherData();
            StatsDisplay statsDisplay = new StatsDisplay( CreateDefaultFuncForCalcAverWindDir() );
            Display display = new Display();

            statsDisplay.AddFuncForCalcAverValue( "windDirection", CreateFuncForCalcAverWindDir() );
            statsDisplay.AddFuncForValidStatValue( "windDirection", CreateFuncForValidWindDir() );

            wd.RegisterObserver( display, 5 );
            wd.RegisterObserver( statsDisplay, 4 );
            wd.SetMeasurements( 3, 0.7, 760, 10, 90 );
            wd.SetMeasurements( 4, 0.8, 761, 8, 100 );
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
