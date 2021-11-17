using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAjaxJquery.Models
{
    public class Car
    {
        private readonly int _carId;
        public int CarId { get { return _carId; } }
        public string Brand { get; set; }
        public int Milage { get; set; }

        public Car(int id, string brand, int milage)
        {
            this._carId = id;
            Brand = brand;
            Milage = milage;
        }
    }
}
