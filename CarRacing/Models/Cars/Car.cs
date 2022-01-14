using CarRacing.Models.Cars.Contracts;
using System;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumtpionPerRace;
        public string Make
        {
            get { return make; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car make cannot be null or empty.");
                }
                else
                {
                    make = value;
                }
            }
        }
        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car model cannot be null or empty.");
                }
                else
                {
                    model = value;
                }
            }
        }

        public string VIN
        {
            get { return vin; }
            private set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException("Car VIN must be exactly 17 characters long.");
                }
                else
                {
                    vin = value;
                }
            }
        }
        public int HorsePower
        {
            get { return horsePower; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Horse power cannot be below 0."); 
                }
                else
                {
                    horsePower = value;
                }
            }
        }
        public double FuelAvailable
        {
            get { return fuelAvailable; }
            protected set
            {
                if(value < 0)
                {
                    fuelAvailable = 0;
                }
                else
                {
                    fuelAvailable = value;
                }
            }
        }
        public double FuelConsumptionPerRace
        {
            get { return fuelConsumtpionPerRace; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be below 0.");
                }
                else
                {
                    fuelConsumtpionPerRace = value;
                }
            }
        }

        protected Car(string make, string model, string VIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            this.VIN = VIN;
            HorsePower = horsePower;
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
        }
        public virtual void Drive()
        {
            this.FuelAvailable -= FuelConsumptionPerRace;
        }
    }
}
