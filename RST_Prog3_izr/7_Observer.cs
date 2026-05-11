using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3_izr
{
    #region Osnovni Observer 
    public interface IStockObserver
    {
        void Update(double stockPrice);
    }

    public interface IStockSubject
    {
        void Subscribe(IStockObserver observer);
        void Unsubscribe(IStockObserver observer);
        void NotifyAll();
    }

    /// <summary>
    /// Razred, ki predstavlja subjekt
    /// </summary>
    public class StockMarket : IStockSubject
    {
        private List<IStockObserver> lstObservers = new List<IStockObserver>();

        private double stockPrice;
                
        public void SetStockPrice(double newStockPrice)
        {
            this.stockPrice = newStockPrice;
            // Obvesti vse opazovalce
            NotifyAll();
        }

        public void NotifyAll()
        {
            foreach(var observer in lstObservers)
            {
                observer.Update(this.stockPrice);
            }
        }

        public void Subscribe(IStockObserver observer)
        {
            this.lstObservers.Add(observer);
        }

        public void Unsubscribe(IStockObserver observer)
        {
            this.lstObservers.Remove(observer);
        }
    }

    public class EmailObserver : IStockObserver
    {
        private string email;
        private double notifyBound;

        public EmailObserver(string email, double notifyBound)
        {
            this.email = email;
            this.notifyBound = notifyBound;
        }

        public void Update(double stockPrice)
        {
            if(stockPrice < notifyBound)
            {
                Console.WriteLine($"Pošiljam obvestilo na {this.email}:" +
                    $" cena je padla na {stockPrice}");
            }
        }
    }

    public class DisplayObserver : IStockObserver
    {
        private List<double> lstStockPriceHistory = new();

        public void Update(double stockPrice)
        {
            lstStockPriceHistory.Add(stockPrice);
            Console.WriteLine($"Tečaj {stockPrice} je bil uspešno zabeležen v zgodovino!");
        }

        public void GetStatistics()
        {
            Console.WriteLine($"Skupno število meritev: {lstStockPriceHistory.Count}");
        }
    }
    #endregion

    #region Observer z eventi
    public interface ITemperatureSensor
    {
        event Action<double> OnTemperatureChanged;
    }

    public class TemperatureSensor : ITemperatureSensor
    {
        public event Action<double>? OnTemperatureChanged;

        private double currentTemp;

        public void SetTemperature(double newTemp)
        {
            this.currentTemp = newTemp;
            Console.WriteLine($"Nova meritev: {this.currentTemp}");

            // Obvestimo vse opazovalce
            this.OnTemperatureChanged?.Invoke(this.currentTemp);
        }
    }

    public class ConsoleDisplay
    {
        public void UpdateDisplay(double temp)
        {
            Console.WriteLine($"Trenutna temperatura: {temp}°C");
        }
    }

    public class AlarmSystem
    {
        private const double Threshold = 100;

        public void CheckTemperature(double temp)
        {
            if(temp > Threshold)
            {
                Console.WriteLine($"Pozor - temperatura je {temp}°C!");
            }
        }
    }

    #endregion
}
