using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int EXPERIENCE = 30;
        private const string BEHAVIOR = "strict";
        public ProfessionalRacer(string username, ICar car) 
            : base(username, BEHAVIOR, EXPERIENCE, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 5;
        }
    }
}
