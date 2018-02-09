using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryCoreVisualStudio.Data;
using InventoryCoreVisualStudio.Models;
using InventoryCoreVisualStudio.ViewModels;

namespace InventoryCoreVisualStudio.Controllers
{
    public class ItemsController : Controller
    {
        private readonly InventoryContext _context;

        public ItemsController(InventoryContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
	        ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["ModelSortParm"] = sortOrder == "Model" ? "model_desc" : "Model";
            
	        if (searchString != null)
	        {
		        page = 1;
	        }
	        else
	        {
		        searchString = currentFilter;
	        }
	        ViewData["CurrentFilter"] = searchString;

			var items = _context.Items
				.Include(i => i.Caliber)
				.Include(i => i.Category)
                    .ThenInclude(sc => sc.Children)
				.Include(i => i.Location)
				.Include(i => i.Manufacturer)
				.Include(i => i.Platform)
				.Include(i => i.Retailer)
                .Include(i => i.FiringAction)
                .AsNoTracking();

            if (!String.IsNullOrEmpty(searchString))
            {
                //Using ToUpper() is used to ensure case insensitive search when running against an IQueryable(database provider implementation
                //ToUpper() is not necessary when running against IEnumerable that would be returned from a repository. 
                //There is performatnce overhead associated with using ToUpper()
                items = items.Where(i => i.Name.ToUpper().Contains(searchString)
                            || i.Model.ToUpper().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    items = items.OrderByDescending(i => i.Name);
                    break;
                case "Model":
                    items = items.OrderBy(i => i.Model);
                    break;
                case "model_desc":
                    items = items.OrderByDescending(i => i.Model);
                    break;
                default:
                    items = items.OrderBy(i => i.Name);
                    break;
            }

			int pageSize = 3;

            return View(await PaginatedList<Item>.CreateAsync(items.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Caliber)
                .Include(i => i.Category)
                    //.ThenInclude(sc => sc.Subcategory)
                .Include(i => i.Location)
                .Include(i => i.Manufacturer)
                .Include(i => i.Platform)
                .Include(i => i.Retailer)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        [HttpGet]
        public IActionResult Create()
        {
            var localCaliber = _context.Caliber;
            ViewData["CaliberId"] = new SelectList(_context.Caliber, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "Name");
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Name");
            ViewData["PlatformId"] = new SelectList(_context.Platform, "Id", "Name");
            ViewData["RetailerId"] = new SelectList(_context.Retailer, "Id", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ManufacturerId,Model,PartNumber,CaliberId,CategoryId,FiringActionId,PlatformId,Color,PurchaseDate,PurchasePrice,PurchaseFrom,RetailerId,ListPrice,LocationId,SerialNumber,Weight,WeightUnitOfMeasure,SoldDate,SoldTo,SoldPrice")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CaliberId"] = new SelectList(_context.Caliber, "Id", "Name", item.CaliberId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", item.CategoryId);
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "Name", item.LocationId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Name", item.ManufacturerId);
            ViewData["PlatformId"] = new SelectList(_context.Platform, "Id", "Name", item.PlatformId);
            ViewData["RetailerId"] = new SelectList(_context.Retailer, "Id", "Name", item.RetailerId);
            ViewData["FiringActionId"] = new SelectList(_context.FiringAction, "Id", "Name", item.FiringActionId);
            return View(item);
        }

        // GET: Items/Edit/5
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var item = _context.Items
                .Include(i => i.Caliber)
                .Include(i => i.Category)
                    .ThenInclude(sc => sc.Children)
                .Include(i => i.Location)
                .Include(i => i.Manufacturer)
                .Include(i => i.Platform)
                .Include(i => i.Retailer)
                .Include(i => i.FiringAction)
                .AsNoTracking()
                .SingleOrDefault(m => m.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            var editItem = new ItemEditViewModel
            {
                Id = item.Id,                
                Model = item.Model,
                PartNumber = item.PartNumber,
                Color = item.Color,
                PurchaseDate = item.PurchaseDate,
                PurchasePrice = item.PurchasePrice,
                PurchaseFrom = item.PurchaseFrom,                
                ListPrice = item.ListPrice,
                SerialNumber = item.SerialNumber,
                Weight = item.Weight,
                WeightUnitOfMeasure = item.WeightUnitOfMeasure,
                SoldDate = item.SoldDate,
                SoldTo = item.SoldTo,
                SoldPrice = item.SoldPrice,
                ManufacturerObj = item.Manufacturer,
                Manufacturer = item.ManufacturerId,
                Manufacturers = new SelectList(_context.Manufacturer, "Id", "Name", item.ManufacturerId),
                Caliber = item.Caliber.Id,
                Calibers = new SelectList(_context.Caliber, "Id", "Name", item.CaliberId),
                Category = item.Category.Id,
                Categories = new SelectList(_context.Category, "Id", "Name", item.CategoryId),
                FiringActions = new SelectList(_context.FiringAction, "Id", "Name", item.FiringActionId),
                Platforms = new SelectList(_context.Platform, "Id", "Name", item.PlatformId),
                Retailers = new SelectList(_context.Retailer, "Id", "Name", item.RetailerId),
                Locations = new SelectList(_context.Location, "Id", "Name", item.LocationId)
            };

            //ViewData["CaliberId"] = new SelectList(_context.Caliber, "Id", "Name", item.CaliberId);
            return View(editItem);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ItemEditViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            var item = _context.Items.Find(id);

            if (ModelState.IsValid)
            {
                try
                {
                    item.ManufacturerId = viewModel.Manufacturer;
                    item.Model = viewModel.Model;
                    item.PartNumber = viewModel.PartNumber;
                    item.CaliberId = viewModel.Caliber;
                    item.CategoryId = viewModel.Category;
                    item.FiringActionId = viewModel.FiringAction;
                    item.PlatformId = viewModel.Platform;
                    item.Color = viewModel.Color;
                    item.PurchaseDate = viewModel.PurchaseDate;
                    item.PurchasePrice = viewModel.PurchasePrice;
                    item.PurchaseFrom = viewModel.PurchaseFrom;
                    item.RetailerId = viewModel.Retailer;
                    item.ListPrice = viewModel.ListPrice;
                    item.LocationId = viewModel.Location;
                    item.SerialNumber = viewModel.SerialNumber;
                    item.Weight = viewModel.Weight;
                    item.WeightUnitOfMeasure = viewModel.WeightUnitOfMeasure;
                    item.SoldDate = viewModel.SoldDate;
                    item.SoldTo = viewModel.SoldTo;
                    item.SoldPrice = viewModel.SoldPrice;                    

                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CaliberId"] = new SelectList(_context.Caliber, "Id", "Name", item.CaliberId);
            return View(viewModel);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Caliber)
                .Include(i => i.Category)
                .Include(i => i.Location)
                .Include(i => i.Manufacturer)
                .Include(i => i.Platform)
                .Include(i => i.Retailer)
                .Include(i => i.FiringAction)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = @"Delete Failed. Try again, and if the problem persists 
                                                see your system administrator";
            }
                return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);

            if(item == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(DbUpdateException ex)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
            
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
