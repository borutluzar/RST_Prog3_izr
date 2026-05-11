using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3_izr
{
    public abstract class Employee
    {
        public string FamilyName { get; set; }
        public string GivenName { get; set; }

        public Employee(string familyName, string givenName)
        {
            this.FamilyName = familyName;
            this.GivenName = givenName;
        }

        public void PaySalary(int amount, string bankAccount)
        {
            Console.WriteLine($"Plača {amount} je bila nakazana na račun {bankAccount}");
        }

        // Instanca strategy razreda
        protected IForeignLanguageSpeaker LanguageSpeaker { get; set; }

        public void TrySpeakForeignLanguage(string language)
        {
            //Console.WriteLine($"Govorim: {language}");
            this.LanguageSpeaker.SpeakForeignLanguage(language);
        }

        public void TryReadInForeignLanguage(string language)
        {
            //Console.WriteLine($"Govorim: {language}");
            this.LanguageSpeaker.ReadForeignLanguage(language);
        }

        public virtual void WorkDuties()
        {
            Console.WriteLine($"Obnašam se letom primerno.");
        }
    }

    public class Researcher : Employee
    {
        public Researcher(string familyName, string givenName) : base(familyName, givenName) 
        {
            this.LanguageSpeaker = new SpeakForeignLanguageFluently();
        }

        public override void WorkDuties()
        {
            base.WorkDuties();
            Console.WriteLine("\nRaziskovanje.");
        }
    }

    public class Lecturer : Employee
    {
        public Lecturer(string familyName, string givenName) : base(familyName, givenName) 
        {
            this.LanguageSpeaker = new SpeakForeignLanguageSoso();
        }

        public override void WorkDuties()
        {
            base.WorkDuties();
            Console.WriteLine("\nPredavanja.");
        }
    }

    public class PRPerson : Employee
    {
        public PRPerson(string familyName, string givenName) : base(familyName, givenName) 
        {
            this.LanguageSpeaker = new SpeakForeignLanguageFluently();
        }

        public override void WorkDuties()
        {
            base.WorkDuties();
            Console.WriteLine("\nPR kampanje.");
        }
    }

    public class Janitor : Employee
    {
        public Janitor(string familyName, string givenName) : base(familyName, givenName) 
        {
            this.LanguageSpeaker = new SpeakForeignLanguageNot();
        }

        public override void WorkDuties()
        {
            base.WorkDuties();
            Console.WriteLine("\nPopravila.");
        }
    }


    public interface IForeignLanguageSpeaker
    {
        void SpeakForeignLanguage(string language);
        void ReadForeignLanguage(string language);
    }

    // Razredi za implementacijo različnih strategij
    public class SpeakForeignLanguageFluently : IForeignLanguageSpeaker
    {
        public void SpeakForeignLanguage(string language)
        {
            Console.WriteLine($"Jezik {language} govorim tekoče!");
        }

        public void ReadForeignLanguage(string language)
        {
            Console.WriteLine($"V jeziku {language} berem tekoče!");
        }
    }

    public class SpeakForeignLanguageSoso : IForeignLanguageSpeaker
    {
        public void SpeakForeignLanguage(string language)
        {
            Console.WriteLine($"Jezik {language} govorim lomljeno!");
        }

        public void ReadForeignLanguage(string language)
        {
            Console.WriteLine($"V jeziku {language} berem komaj!");
        }
    }

    public class SpeakForeignLanguageNot : IForeignLanguageSpeaker
    {
        public void SpeakForeignLanguage(string language)
        {
            Console.WriteLine($"Jezika {language} ne govorim!");
        }

        public void ReadForeignLanguage(string language)
        {
            Console.WriteLine($"V jeziku {language} ne berem!");
        }
    }
}
