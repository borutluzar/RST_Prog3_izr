using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3_izr
{
    // Singleton je sealed, da preprečimo definicije podrazredov
    public sealed class Singleton
    {
        // Privatni konstruktor
        private Singleton() { }


        // Statična spremeljivka, ki edino instanco hrani
        private static Singleton? instance = null;

        // Statična funkcija, ki vrača edino instanco
        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                // Edini klic konstruktorja
                instance = new Singleton();
            }
            return instance;
        }
    }


    public sealed class EventLog
    {
        private EventLog()
        {
            this.LogFile = $"EventLog-{DateTime.Now:yyyy-MM-dd--HH-mm-ss}.txt";
        }

        public void WriteEvent(string message)
        {
            StreamWriter sw = new StreamWriter(this.LogFile, true);
            sw.WriteLine(message);
            sw.Close();
        }

        public string LogFile { get; }

        private static EventLog? instance = null;

        public static EventLog GetInstance()
        {
            if (instance == null)
            {
                instance = new EventLog();
            }
            return (EventLog)instance;
        }
    }

}
