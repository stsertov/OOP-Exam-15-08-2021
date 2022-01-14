using System;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double FUEL_AVAILABLE = 65;
        private const double FUEL_CONSUMPTION = 7.5;
        public TunedCar(string make, string model, string VIN, int horsePower) 
            : base(make, model, VIN, horsePower, FUEL_AVAILABLE, FUEL_CONSUMPTION)
        {
        }

        public override void Drive()
        {
            this.FuelAvailable -= FuelConsumptionPerRace;
            int hp = (int)Math.Round(this.HorsePower - (HorsePower * 0.03));
            this.HorsePower = hp; 
        }
    }
}
