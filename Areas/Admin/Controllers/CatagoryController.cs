using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Areas.Admin.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly ICatagory icata;

        public CatagoryController(ICatagory Icata)
        {
            icata = Icata;
        }
        [Area("Admin")]

        public IActionResult Index()
        {
            List<Catagory> catagories = icata.GETallCATAGORY();
            return View(catagories);
        }
        [Area("Admin")]

        public IActionResult Create()
        {
            return View();
        }
        [Area("Admin")]

        [HttpPost]
        public IActionResult Create(Catagory catagory)
        {
            icata.Insertcatagory(catagory);
            return RedirectToAction("Index");
        }

        [Area("Admin")]
        public IActionResult Delete(int IDCata)
        {
            icata.Deletecatagory(IDCata);
            return RedirectToAction("Index");
        }
        [Area("Admin")]
        [HttpGet]
        public IActionResult Edit(int IDCata)
        {
            Catagory catagory = icata.Getcatagory(IDCata);
            return View(catagory);
        }
        [Area("Admin")]
        [HttpPost]
        public IActionResult Edit(Catagory catagory)
        {
            icata.Editcatagory(catagory.IDCata);
            return RedirectToAction("Index");
        }

    }
}
