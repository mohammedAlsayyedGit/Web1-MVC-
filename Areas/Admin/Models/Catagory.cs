using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using WebApplication1.Areas.Admin.Data;

namespace WebApplication1.Areas.Admin.Models
{
    public class Catagory
    {
        [Key]
        public int IDCata { get; set; }
        [Required]
        public string catagoryName { get; set; }
        
    }

    public interface ICatagory
    {
        public void Insertcatagory(Catagory catagory);


        public void Deletecatagory(int idcate);

        public void Editcatagory(int idcate);
        public Catagory Getcatagory(int idcate);

        public List<Catagory> GETallCATAGORY();

    }


    public class catagory_mang : ICatagory
    {
        private readonly DBContext dBContext;

        public catagory_mang(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public List<Catagory> GETallCATAGORY()
        {
            return dBContext.Tblcatagories.ToList();
        }

        public void Insertcatagory(Catagory catagory)
        {
            dBContext.Tblcatagories.Add(catagory);
            dBContext.SaveChanges();
        }

        public void Deletecatagory(int idcate)
        {
            Catagory catagory = dBContext.Tblcatagories.Where(x => x.IDCata == idcate).FirstOrDefault();
            dBContext.Tblcatagories.Remove(catagory);
            dBContext.SaveChanges();
        }

        public void Editcatagory(int idcate)
        {
            Catagory catagory = dBContext.Tblcatagories.Where(x => x.IDCata == idcate).FirstOrDefault();
            dBContext.Tblcatagories.Update(catagory);
            dBContext.SaveChanges();
        }

     



        public Catagory Getcatagory(int idcate)
        {
            Catagory catagory = dBContext.Tblcatagories.FirstOrDefault(x => x.IDCata == idcate);
            return catagory;
        }


    }
}
