using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WebApplication1.Areas.Admin.Data;
using WebApplication1.Areas.Admin.Models;

namespace WebApplication1.Areas.Admin.Models
{
    public class products
    {
        [Key]
        public int PCode { get; set; }
        [Required]
        public string PTitle { get; set; }
        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public string Photo { get; set; }
        public int CatagoryId { get; set; }
        [ForeignKey("CatagoryId")]
        public  Catagory Catagory { get; set; }
    }

    public interface IProduct
    {
        public void InsertProduct(products products);
        public void UpdateProduct(products product);
        public void DeleteProduct(products products);
        public products GetProduct(int  Pcode);
        public IQueryable<products> GetProducts();
         
    }

    public class products_Mang : IProduct
    {
        private readonly DBContext bContext;

        public products_Mang(DBContext bContext)
        {
            this.bContext = bContext;
        }
        public void DeleteProduct(products products)
        {  
            bContext.TblPoducts.Remove(products);
            bContext.SaveChanges();
        }
        public products GetProduct(int  Pcode)
        {
            products product = bContext.TblPoducts.FirstOrDefault(x => x.PCode == Pcode);
            return product;
        }
        public IQueryable<products> GetProducts()
        {
            //IQueryable<products> products = bContext.TblPoducts;
            IQueryable<products> products = bContext.TblPoducts.Include(x=>x.Catagory).AsQueryable();
            return products;
        }
        public void InsertProduct(products products)
        {
            bContext.TblPoducts.Add(products);
            bContext.SaveChanges();
        }
        public void UpdateProduct(products product)
        {
           
            bContext.TblPoducts.Update(product);
            bContext.SaveChanges();
        }
    }
}
