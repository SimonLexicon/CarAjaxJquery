using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAjaxJquery.Models
{
    public class CarMemory
    {
        private static List<Car> _carList = new List<Car>();
        private static int _idCounter;
        public void SeedCars()
        {
            CarMemory carMemory = new CarMemory();
            carMemory.Create("Volvo", 25000);
            carMemory.Create("Volvo", 10000);
            carMemory.Create("Volvo", 5000);

            carMemory.Create("Saab", 30000);
            carMemory.Create("Saab", 15000);
            carMemory.Create("Saab", 3000);

            carMemory.Create("Audi", 10000);
            carMemory.Create("Audi", 5000);
            carMemory.Create("Audi", 2000);

        }

        public Car Create(string brand, int milage)
        {
            Car newCar = new Car(_idCounter, brand, milage);
            _carList.Add(newCar);
            _idCounter++;
            return newCar;
        }

        public bool Delete(Car car)
        {
            bool status = _carList.Remove(car);
            return status;
        }

        public List<Car> Read()
        {
            return _carList;
        }

        public Car Read(int id)
        {
            Car targetCar = _carList.Find(c => c.CarId == id);
            return targetCar;
        }
    }
}
