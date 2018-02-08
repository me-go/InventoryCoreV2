﻿using System;
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

//	    public async Task<IActionResult> GetAll()
//	    {
//		    var itemsList = _context.Items.FromSql(@"SELECT [Id],[ActionId],[CaliberId],[CategoryId],[Color],[FiringActionId],[ListPrice],[LocationId],[ManufacturerId]
//			    ,[Model],[Name],[PartNumber],[PlatformId],[PurchaseDate],[PurchaseFrom],[PurchasePrice],[RetailerId],[SerialNumber]
//			    ,[SoldDate],[SoldPrice],[SoldTo],[Weight],[WeightUnitOfMeasure]
//		    FROM[dbo].[Item]").OrderByDescending(i => i.Name);
//
//
//		    return View("Index", await itemsList.ToListAsync());
//	    }
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

        public ViewResult Create2(ItemViewModel model)
        {
            var item = new Item();
            item.Model = model.Model;
            item.Caliber = model.Caliber;


            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.SingleOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["CaliberId"] = new SelectList(_context.Caliber, "Id", "Id", item.CaliberId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", item.CategoryId);
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "Id", item.LocationId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Id", item.ManufacturerId);
            ViewData["PlatformId"] = new SelectList(_context.Platform, "Id", "Id", item.PlatformId);
            ViewData["RetailerId"] = new SelectList(_context.Retailer, "Id", "Id", item.RetailerId);
            ViewData["FiringActionId"] = new SelectList(_context.FiringAction, "Id", "Name", item.FiringActionId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ManufacturerId,Model,PartNumber,CaliberId,CategoryId,FiringActionId,PlatformId,Color,PurchaseDate,PurchasePrice,PurchaseFrom,RetailerId,ListPrice,LocationId,SerialNumber,Weight,WeightUnitOfMeasure,SoldDate,SoldTo,SoldPrice")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            ViewData["CaliberId"] = new SelectList(_context.Caliber, "Id", "Id", item.CaliberId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", item.CategoryId);
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "Id", item.LocationId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Id", item.ManufacturerId);
            ViewData["PlatformId"] = new SelectList(_context.Platform, "Id", "Id", item.PlatformId);
            ViewData["RetailerId"] = new SelectList(_context.Retailer, "Id", "Id", item.RetailerId);
            ViewData["FiringActionId"] = new SelectList(_context.FiringAction, "Id", "Name", item.FiringActionId);
            return View(item);
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
