using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> models;
        public IReadOnlyCollection<ICar> Models => models;

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Car Repository");
            }
            this.models.Add(model);
        }

        public CarRepository()
        {
            this.models = new List<ICar>();
        }
        public ICar FindBy(string property)
        {
            return models.FirstOrDefault(x => x.VIN == property);
        }

        public bool Remove(ICar model)
        {
            ICar car = this.FindBy(model.VIN);
            if (car == null)
            {
                return false;
            }
            this.models.Remove(car);
            return true;
        }
    }
}
