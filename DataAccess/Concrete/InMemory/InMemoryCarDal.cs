using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
          {
              new Car{CarId= 1, BrandId = 1, ColorId = 1, DailyPrice = 250, ModelYear = 2000, Description = "Otomatik Dizel" },    
              new Car{CarId= 2, BrandId =1, ColorId = 2, DailyPrice = 500, ModelYear = 1999, Description = "Manuel Benzin" },
              new Car{CarId= 2, BrandId = 3, ColorId = 2, DailyPrice = 150, ModelYear = 2004, Description = "Otomatik Dizel" },
             new Car{CarId= 2, BrandId = 3, ColorId = 2, DailyPrice = 250, ModelYear = 2003, Description = "Otomatik Benzin" },
           };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c=>c.CarId==Id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
                carToUpdate.BrandId = car.BrandId;
                carToUpdate.ColorId = car.ColorId;
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.ModelYear = car.ModelYear;
                carToUpdate.Description = car.Description;
        }
    }
}

