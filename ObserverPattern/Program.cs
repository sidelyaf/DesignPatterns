using System;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            WeatherStationData weatherStationData = new WeatherStationData();
            CurrentConditionsDisplay currentConditionsDisplay = new CurrentConditionsDisplay(weatherStationData);
            HeatIndexDisplay heatIndexDisplay = new HeatIndexDisplay(weatherStationData);

            weatherStationData.Temperature = 15f;
            weatherStationData.Humidity = 25f;
            weatherStationData.Pressure = 5f;

            weatherStationData.Temperature = 20f;
            weatherStationData.Humidity = 30f;
            weatherStationData.Pressure = 10f;

            Console.ReadLine();
        }

        public class CurrentConditionsDisplay : IObserver, IDisplayElement
        {
            private float temperature;
            private float humidity;
            private ISubject weatherData;

            public CurrentConditionsDisplay(ISubject subject)
            {
                /* The constructor is passed the weatherData object (the Subject)
                    and we use it to register the display as an observer.*/
                this.weatherData = subject;
                weatherData.RegisterObserver(this);
            }
            public void Display()
            {
                Console.WriteLine( $"Current conditions: {temperature} F degrees and {humidity} + % humidity");
            }

            public void Update(ISubject subject)
            {
                if (subject is WeatherStationData weatherStationData)
                {
                    temperature = weatherStationData.Temperature;
                    humidity = weatherStationData.Humidity;
                    Display();
                }
            }
        }

        public class HeatIndexDisplay : IObserver, IDisplayElement
        {

            private float temperature;
            private float humidity;
            private double heatIndex;
            private ISubject weatherData;
            private WeatherStationData weatherStationData;

            public HeatIndexDisplay(ISubject subject)
            {
                this.weatherData = subject;
                weatherData.RegisterObserver(this);
            }

            public void Display()
            {
                Console.WriteLine( $"Heat index is: {heatIndex}.");
            }

            public void Update(ISubject subject)
            {
                if (subject is WeatherStationData weatherStationData)
                {
                    temperature = weatherStationData.Temperature;
                    humidity = weatherStationData.Humidity;
                    heatIndex = 16.923 + 1.85212 * 10 - 1 * temperature + 5.37941 * humidity - 1.00254 * 10 - 1 * temperature
    * humidity + 9.41695 * 10 - 3 * Math.Pow(temperature, 2) + 7.28898 * 10 - 3 * Math.Pow(humidity, 2) + 3.45372 * 10 - 4
    * Math.Pow(temperature, 2) * humidity - 8.14971 * 10 - 4 * temperature * Math.Pow(humidity, 2) + 1.02102 * 10 - 5 * Math.Pow(temperature, 2) * Math.Pow(humidity, 2) -
    3.8646 * 10 - 5 * Math.Pow(temperature, 3) + 2.91583 * 10 - 5 * Math.Pow(humidity, 3) + 1.42721 * 10 - 6 * Math.Pow(temperature, 3) * humidity
    + 1.97483 * 10 - 7 * temperature * Math.Pow(humidity, 3) - 2.18429 * 10 - 8 * Math.Pow(temperature, 3) * Math.Pow(humidity, 2) + 8.43296 *
    10 - 10 * Math.Pow(temperature, 2) * Math.Pow(humidity, 3) - 4.81975 * 10 - 11 * Math.Pow(temperature, 3) * Math.Pow(humidity, 3);

                    Display();
                }
            }
        }
    }
}
