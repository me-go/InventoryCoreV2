using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InventoryCoreVisualStudio.Models;
using Microsoft.EntityFrameworkCore;
using InventoryCoreVisualStudio.Data;
using InventoryCoreVisualStudio.ViewModels;

namespace InventoryCoreVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        private readonly InventoryContext _context;

        public HomeController(InventoryContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Summary()
        {
            //IQueryable<ItemSummaryViewModel> data = from Item in _context.Items
            //                                        group Item by Item.PurchaseDate into dateGroup
            //                                        select new ItemSummaryViewModel()
            //                                        {
            //                                            PurchaseYear = dateGroup.Key,
            //                                            ItemCount = dateGroup.Count()
            //                                        };

            IQueryable<ItemSummaryViewModel> summaryData = _context.Items
                .GroupBy(i => new
                {
                    Year = i.PurchaseDate.Value.Year
                }).Select(global => new ItemSummaryViewModel
                {
                    PurchaseYear = global.Key.Year,
                    ItemCount = global.Count()
                }).OrderByDescending(i => i.PurchaseYear);

            return View(await summaryData.AsNoTracking().ToListAsync());
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
