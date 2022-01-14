using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            switch (type)
            {
                case "SuperCar":
                    this.cars.Add(new SuperCar(make, model, VIN, horsePower));
                    break;
                case "TunedCar":
                    this.cars.Add(new TunedCar(make, model, VIN, horsePower));
                    break;
                default:
                    throw new ArgumentException("Invalid car type!");
            }

            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = this.cars.FindBy(carVIN);
            if(car == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }

            switch (type)
            {
                case "ProfessionalRacer":
                    this.racers.Add(new ProfessionalRacer(username, car));
                    break;
                case "StreetRacer":
                    this.racers.Add(new StreetRacer(username, car));
                    break;
                default:
                    throw new ArgumentException("Invalid racer type!");
            }
            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer first = this.racers.FindBy(racerOneUsername);
            IRacer second = this.racers.FindBy(racerTwoUsername);

            if(first == null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }
            else if(second == null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }
            string result = map.StartRace(first, second);

            return result.Trim();
        }

        public string Report()
        {
            List<IRacer> racerseOrdered = new List<IRacer>(this.racers.Models
                .OrderByDescending(x => x.DrivingExperience)
                .ThenBy(x => x.Username));

            StringBuilder sb = new StringBuilder();

            foreach (var racer in racerseOrdered)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
