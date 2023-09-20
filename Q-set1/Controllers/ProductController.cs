using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Q_set1.Models;
using Microsoft.Data.SqlClient;

namespace Q_set1.Controllers
{

    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //public IActionResult Search(ProductSearchViewModel searchModel)
        //{
        //    // Build the search query dynamically
        //    var query = _context.Products.AsQueryable();

        //    if (!string.IsNullOrEmpty(searchModel.ProductName))
        //    {
        //        query = query.Where(p => p.ProductName.Contains(searchModel.ProductName));
        //    }

        //    if (!string.IsNullOrEmpty(searchModel.Size))
        //    {
        //        query = query.Where(p => p.Size == searchModel.Size);
        //    }

        //    if (searchModel.Price.HasValue)
        //    {
        //        query = query.Where(p => p.Price == searchModel.Price.Value);
        //    }

        //    if (searchModel.MfgDate.HasValue)
        //    {
        //        query = query.Where(p => p.MfgDate == searchModel.MfgDate.Value.Date);
        //    }

        //    if (!string.IsNullOrEmpty(searchModel.Category))
        //    {
        //        query = query.Where(p => p.Category == searchModel.Category);
        //    }

        //    var results = query.ToList();
        //    return View(results);
        //}

        public IActionResult Search(ProductSearchViewModel searchModel)
{
    var results = _context.Products.FromSqlRaw("EXEC SearchProducts @ProductName, @Size, @Price, @MfgDate, @Category",
        new SqlParameter("@ProductName", searchModel.ProductName ?? (object)DBNull.Value),
        new SqlParameter("@Size", searchModel.Size ?? (object)DBNull.Value),
        new SqlParameter("@Price", searchModel.Price ?? (object)DBNull.Value),
        new SqlParameter("@MfgDate", searchModel.MfgDate ?? (object)DBNull.Value),
        new SqlParameter("@Category", searchModel.Category ?? (object)DBNull.Value))
        .ToList();

    return View(results);
}

    }

}
