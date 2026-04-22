using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3_izr
{
    public abstract class Computer
    {
        public abstract string Processor { get; set; }
        public abstract string RAM { get; set; }
        public abstract string GraphicsCard { get; set; }
        public List<string> Ports { get; set; }

        internal Computer()
        {
            this.Ports = new List<string>();
        }

        public void DisplaySpecs()
        {
            Console.WriteLine($"Processor: {this.Processor}\n" +
                $"RAM: {this.RAM}\n" +
                $"GPU: {this.GraphicsCard}\n" +
                $"Ports: {string.Join(", ", Ports)}");
        }
    }

    public class Laptop : Computer
    {
        public override string Processor { get; set; }
        public override string RAM { get; set; }
        public override string GraphicsCard { get; set; }

        internal Laptop() { }

        internal Laptop(string proc, string ram) 
        {
            this.Processor = proc;
            this.RAM = ram;
        }

        internal Laptop(string proc, string ram, string gpu)
        {
            this.Processor = proc;
            this.RAM = ram;
            this.GraphicsCard = gpu;
        }
    }

    /// <summary>
    /// Vmesnik, ki določa akcije za izgradnjo računalnika
    /// </summary>
    public interface IComputerBuilder
    {
        void SetProcessor(string processor);
        void SetRAM(string ram);
        void SetGraphicsCard(string gpu);
        void AddPort(string port);
        Computer BuildComputer();
    }

    public class LaptopBuilder : IComputerBuilder
    {
        private Laptop builderInstance = new Laptop();

        public void AddPort(string port)
        {
            builderInstance.Ports.Add(port);
        }        

        public void SetGraphicsCard(string gpu)
        {
            builderInstance.GraphicsCard = gpu;
        }

        public void SetProcessor(string processor)
        {
            builderInstance.Processor = processor;
        }

        public void SetRAM(string ram)
        {
            builderInstance.RAM = ram;
        }

        public Computer BuildComputer()
        {
            return builderInstance;
        }
    }

    public enum ComputerType
    {
        GamingLaptop = 1,
        OfficeLaptop = 2,
        GamingPC = 3
    }

    public class ComputerFactory
    {
        public static Computer? CreateComputer(ComputerType type)
        {
            Computer? instance = null;
            switch (type)
            {
                case ComputerType.GamingLaptop:
                    {
                        LaptopBuilder gaming = new LaptopBuilder();
                        gaming.SetProcessor("Intel i9");
                        gaming.SetRAM("32GB");
                        gaming.SetGraphicsCard("NVIDIA RTX 4080");
                        gaming.AddPort("HDMI");
                        gaming.AddPort("USB-C");
                        instance = gaming.BuildComputer();
                    }
                    break;
                case ComputerType.OfficeLaptop:
                    {
                        LaptopBuilder office = new LaptopBuilder();
                        office.SetProcessor("Intel i5");
                        office.SetRAM("8GB");
                        office.SetGraphicsCard("Integrated Graphics");
                        office.AddPort("USB-A");
                        instance = office.BuildComputer();
                    }
                    break;
            }
            return instance;
        }
    }
}
