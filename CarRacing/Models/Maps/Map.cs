using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            double oneMulti = Multiplier(racerOne);
            double twoMulti = Multiplier(racerTwo);

            if(racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return $"Race cannot be completed because both racers are not available!";
            }
            else if(racerOne.IsAvailable() == false && racerTwo.IsAvailable())
            {
               
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            else if(racerOne.IsAvailable() && racerTwo.IsAvailable() == false)
            {
              
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }
            else
            {
                
                double chanceOfWinningFirst = racerOne.DrivingExperience * racerOne.Car.HorsePower * oneMulti;
                double chanceOfWinningTwo = racerTwo.DrivingExperience * racerTwo.Car.HorsePower * twoMulti;
                racerOne.Race();
                racerTwo.Race();
                if (chanceOfWinningFirst > chanceOfWinningTwo)
                {
                    return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!";
                }
                else
                {
                    return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!";
                }
            }
        }

        private double Multiplier(IRacer racer)
        {
            if(racer.RacingBehavior == "strict")
            {
                return 1.2;
            }
            else
            {
                return 1.1;
            }
        }
    }
}
