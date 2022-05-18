using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Admin.Models;

namespace WebApplication1.Areas.Admin.Data
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<products> TblPoducts { set; get; }
        public DbSet<Catagory> Tblcatagories { get; set; }
    }
}
