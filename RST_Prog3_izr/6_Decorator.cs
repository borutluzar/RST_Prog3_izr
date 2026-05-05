using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3_izr
{
    public abstract class Pizza
    {
        public abstract string Description { get; }

        public abstract double GetPrice();
    }

    public class Margherita : Pizza
    {
        public override string Description => "Margherita";

        public override double GetPrice()
        {
            return 8.0;
        }
    }

    public class Pepperoni : Pizza
    {
        public override string Description => "Pepperoni";

        public override double GetPrice()
        {
            return 9.50;
        }
    }


    // Začnemo s pripravo razredov za vzorec decorator
    public abstract class ToppingDecorator : Pizza
    {
        protected Pizza pizza;

        protected ToppingDecorator(Pizza pizza)
        {
            this.pizza = pizza;
        }
    }

    public class EggOnPizza : ToppingDecorator
    {
        public EggOnPizza(Pizza pizza) : base(pizza) { }

        public override string Description => this.pizza.Description + " z jajcem";

        public override double GetPrice()
        {
            return this.pizza.GetPrice() + 1.50;
        }
    }

    public class HamOnPizza : ToppingDecorator
    {
        public HamOnPizza(Pizza pizza) : base(pizza) { }

        public override string Description => this.pizza.Description + " s šunko";

        public override double GetPrice()
        {
            return this.pizza.GetPrice() + 2.00;
        }
    }
}
