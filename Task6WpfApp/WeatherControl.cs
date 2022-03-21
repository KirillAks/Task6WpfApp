using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task6WpfApp
{
    enum Precipitation
    {
        Sunny,
        Cloudy,
        Rain,
        Snow
    }
    class WeatherControl:DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        private string windDirection;
        private int windSpeed;
        private Precipitation precipitation;

        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);

            set => SetValue(TemperatureProperty, value);
        }

        public string WindDirection
        {
            get => windDirection;
            set => windDirection = value;
        }

        public int WindSpeed
        {
            get => windSpeed;
            set => windSpeed = value;
        }        

        public WeatherControl(int temperature, string windDirection, int windSpeed, Precipitation precipitation)
        {
            this.Temperature = temperature;
            this.WindDirection = windDirection;
            this.WindSpeed = windSpeed;
            this.precipitation = precipitation;
        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }

        private static bool ValidateTemperature(object value)
        {
            int v = (int) value;
            if (v >= -50 && v <= 50)
            {
                return true;
            }
            else
                return false;
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50)
            {
                return v;
            }
            else
                return 0;
        }

        public string Print()
        {
            return $"{Temperature} {WindDirection} {WindSpeed} {precipitation}";
        }
    }
}
