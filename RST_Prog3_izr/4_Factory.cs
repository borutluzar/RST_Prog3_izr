using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3_izr
{
    // Factory je lahko tudi statičen
    public static class CreditCardFactory
    {
        public static ICreditCard? CreateCreditCard(CreditCardType type)
        {
            ICreditCard? card;
            switch (type)
            {
                case CreditCardType.Silver:
                    // Kreiramo novo kartico
                    card = new SilverCard(/* lahko kompleksni parametri, katerih vrednosti dobimo iz baze */);
                    break;
                case CreditCardType.Gold:
                    // Kreiramo novo kartico
                    card = new GoldCard();
                    break;
                case CreditCardType.Platinum:
                    // Kreiramo novo kartico
                    card = new PlatinumCard();
                    break;
                case CreditCardType.Student:
                    // Kreiramo novo kartico
                    card = new StudentCard();
                    break;
                default:
                    Console.WriteLine($"Tipa {type} nimamo implementiranega!");
                    card = null;
                    break;
            }
            return card;
        }
    }



    public enum CreditCardType
    {
        Silver = 1,
        Gold = 2,
        Platinum = 3,
        Student = 4
    }

    public interface ICreditCard
    {
        CreditCardType CreditCardType { get; }
        double Limit { get; }
        double AnnualCharge { get; }
    }

    public class SilverCard : ICreditCard
    {
        // Naredimo dostopnost konstruktorja internal - samo znotraj projekta
        internal SilverCard() { }

        public CreditCardType CreditCardType 
        {
            get
            {
                return CreditCardType.Silver;
            }
        }

        // Posebna sintaksa, ki pomeni enako kot zgornji get
        public double Limit => 800;

        public double AnnualCharge => 20;
    }

    public class GoldCard : ICreditCard
    {
        internal GoldCard() { }

        public CreditCardType CreditCardType => CreditCardType.Gold;

        // Posebna sintaksa, ki pomeni enako kot zgornji get
        public double Limit => 2000;

        public double AnnualCharge => 50;
    }

    public class PlatinumCard : ICreditCard
    {
        internal PlatinumCard() { }

        public CreditCardType CreditCardType => CreditCardType.Platinum;

        // Posebna sintaksa, ki pomeni enako kot zgornji get
        public double Limit => 10_000;

        public double AnnualCharge => 100;
    }

    public class StudentCard : ICreditCard
    {
        public StudentCard() { }

        public CreditCardType CreditCardType => CreditCardType.Student;

        // Posebna sintaksa, ki pomeni enako kot zgornji get
        public double Limit => 500;

        public double AnnualCharge => 5;
    }
}
