using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAjaxJquery.Models
{
    public class CarViewModel : CreateCarViewModel
    {
        public List<Car> CarListView { get; set; }
        public string FilterString { get; set; }
        public CarViewModel()
        {
            CarListView = new List<Car>();
        }
    }
}
