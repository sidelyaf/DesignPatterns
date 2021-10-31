using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    public class WeatherStationData : ISubject
    {
        private List<IObserver> _observers;
        private float _temperature;
        private float _humidity;
        private float _pressure;
        public float Temperature { get { return _temperature; } set { _temperature = value; NotifyObserver(); } }
        public float Humidity { get { return _humidity; } set { _humidity = value; NotifyObserver(); } }
        public float Pressure { get { return _pressure; } set { _pressure = value; NotifyObserver(); } }

        public WeatherStationData()
        {
            _observers = new List<IObserver>();
        }
        public void NotifyObserver()
        {
            _observers.ForEach(o =>
                { o.Update(this); }
            );
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObserver();
    }

    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public interface IDisplayElement
    {
        void Display();
    }
}
