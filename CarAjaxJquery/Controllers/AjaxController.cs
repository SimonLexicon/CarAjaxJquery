using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAjaxJquery.Models;

namespace CarAjaxJquery.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            CarMemory carMemory = new CarMemory();
            List<Car> carList = carMemory.Read();
            return PartialView("_CarListPartial", carList);
        }

        [HttpPost]
        public IActionResult FindCarById(int carID)
        {
            CarMemory carMemory = new CarMemory();
            Car targetCar = carMemory.Read(carID);
            List<Car> cars = new List<Car>();
            if(targetCar != null)
            {
                cars.Add(targetCar);
            }
            return PartialView("_CarListPartial", cars);

        }

        [HttpPost]
        public IActionResult DeleteCarById(int carID)
        {
            CarMemory carMemory = new CarMemory();
            Car targetCar = carMemory.Read(carID);
            List<Car> cars = new List<Car>();
            bool success = false;
            if(targetCar != null)
            {
                success = carMemory.Delete(targetCar);
            }
            if (success)
            {
                return StatusCode(200);
            }
            return StatusCode(404);
        }
    }
}
