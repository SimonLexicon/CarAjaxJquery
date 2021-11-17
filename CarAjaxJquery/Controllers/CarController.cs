using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAjaxJquery.Models;

namespace CarAjaxJquery.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            CarMemory carMemory = new CarMemory();

            CarViewModel CarListViewModel = new CarViewModel() { CarListView = carMemory.Read() };

            if (CarListViewModel.CarListView.Count == 0 || CarListViewModel.CarListView == null)
            {
                carMemory.SeedCars();
            }

            return View(CarListViewModel);
        }

        [HttpPost]
        public IActionResult Index(CarViewModel viewModel)
        {
            CarMemory carMemory = new CarMemory();
            viewModel.CarListView.Clear();

            foreach (Car c in carMemory.Read())
            {
                if (c.Brand.Contains(viewModel.FilterString, StringComparison.OrdinalIgnoreCase))
                {
                    viewModel.CarListView.Add(c);
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateCar(CreateCarViewModel cCarViewModel)
        {
            CarViewModel newViewModel = new CarViewModel();
            CarMemory carMemory = new CarMemory();

            if (ModelState.IsValid)
            {
                newViewModel.Brand = cCarViewModel.Brand;
                newViewModel.Milage = cCarViewModel.Milage;
                newViewModel.CarListView = carMemory.Read();

                carMemory.Create(cCarViewModel.Brand, cCarViewModel.Milage);
                ViewBag.Message = "Successfully added car!";

                return View("Index", newViewModel);
            }
            ViewBag.Message = "Failed to add car" + ModelState.Values;
            return View("Index", newViewModel);
        }

        public IActionResult DeleteCar(int id)
        {
            CarMemory carMemory = new CarMemory();
            Car targetCar = carMemory.Read(id);
            carMemory.Delete(targetCar);

            return RedirectToAction("Index");
        }

        public PartialViewResult CarList()
        {
            return PartialView("_CarListPartial");
        }
    }
}
