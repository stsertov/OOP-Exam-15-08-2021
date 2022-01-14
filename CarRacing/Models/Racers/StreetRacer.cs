using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int EXPERIENCE = 10;
        private const string BEHAVIOR = "aggressive";
        public StreetRacer(string username, ICar car) 
            : base(username, BEHAVIOR, EXPERIENCE, car)
        {
        }
    }
}
