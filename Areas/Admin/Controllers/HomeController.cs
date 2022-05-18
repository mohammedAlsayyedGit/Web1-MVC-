using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Areas.Admin.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProduct Ipro;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ICatagory Icata;

        public HomeController(IProduct product, IWebHostEnvironment webHostEnvironment, ICatagory Icata)
        {
            this.Ipro = product;
            this.webHostEnvironment = webHostEnvironment;
            this.Icata = Icata;
        }

        [Area("Admin")]
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [Area("Admin")]
        [HttpPost]
        public IActionResult SignIn(SignIN sign)
        {

            if (ModelState.IsValid)
            {
                if (sign.Username.Equals("Mohammed") && sign.Password.Equals("Mohammed"))
                {
                    return RedirectToAction("listOfprodects");
                }
            }

            return View();
        }
        [Area("Admin")]
        [HttpGet]
        public IActionResult listOfprodects()
        {

            List<products> product = Ipro.GetProducts().ToList();


            return View(product);

        }

        [Area("Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryDropDown = Icata.GETallCATAGORY().Select(i => new SelectListItem
            {
                Text = i.catagoryName,
                Value = i.IDCata.ToString()
            });
            ViewBag.CategoryDropDown = CategoryDropDown;

            return View();
        }

        [Area("Admin")]
        [HttpPost]
        public IActionResult Create(products products, IFormFile images)
        {

            //var files = HttpContext.Request.Form.Files;
            if (images != null)
            {
                string webRootPath = webHostEnvironment.WebRootPath;
                string upload = webRootPath + @"\images\products\";
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(images.FileName);
                using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                {
                    images.CopyTo(fileStream);
                }
                products.Photo = fileName + extension;
                Ipro.InsertProduct(products);
                return RedirectToAction("listOfprodects");

            }
            else
            {
                return RedirectToAction("Create");

            }

        }
        
        [Area("Admin")]
        public IActionResult Delete(int PCODE)
        {
            products product = Ipro.GetProduct(PCODE);
            string webRootPath = webHostEnvironment.WebRootPath;
            string oldfile = webRootPath + @"\images\products\" + product.Photo;
            if (System.IO.File.Exists(oldfile))
            {
                System.IO.File.Delete(oldfile);
            }
            Ipro.DeleteProduct(product);
            return RedirectToAction("listOfprodects");
        }


        [Area("Admin")]
        public IActionResult Edit(int PCODE)
        {
            IEnumerable<SelectListItem> CategoryDropDown = Icata.GETallCATAGORY().Select(i => new SelectListItem
            {
                Text = i.catagoryName,
                Value = i.IDCata.ToString()
            });
            ViewBag.CategoryDropDown = CategoryDropDown;
            products DEL = Ipro.GetProduct(PCODE);
           
            return View(DEL);
        }
        [Area("Admin")]
        [HttpPost]
        public IActionResult Edit(products products, IFormFile images)
        {
            products pr = Ipro.GetProduct(products.PCode);
           // var files = HttpContext.Request.Form.Files;
            string webRootPath = webHostEnvironment.WebRootPath;
            string upload = webRootPath + @"\images\products\";
            // اذا حط صورة جديدة يحذف القديمة وياخد الجديدة مكانها 
            if (images!= null)
            {
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(images.FileName);
                using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                {
                    images.CopyTo(fileStream);
                }
                // حذف الملف القديم
                string oldfile = webRootPath + @"\images\products\" + pr.Photo;
                if (System.IO.File.Exists(oldfile))
                {
                    System.IO.File.Delete(oldfile);
                }
                pr.Photo = fileName + extension;
            }
            pr.Price = products.Price;
            pr.PTitle = products.PTitle;
            pr.Description = products.Description;

            pr.CatagoryId = products.CatagoryId;
            Ipro.UpdateProduct(pr);
            return RedirectToAction("listOfprodects");
        }



    }
}
