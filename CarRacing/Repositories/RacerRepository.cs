using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private readonly List<IRacer> models;
        public IReadOnlyCollection<IRacer> Models => models;

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Racer Repository");
            }
            this.models.Add(model);
        }

        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }
        public IRacer FindBy(string property)
        {
            return models.FirstOrDefault(x => x.Username == property);
        }

        public bool Remove(IRacer model)
        {
            IRacer racer = this.FindBy(model.Username);
            if (racer == null)
            {
                return false;
            }
            this.models.Remove(racer);
            return true;
        }
    }
}
