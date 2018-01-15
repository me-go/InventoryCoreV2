using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryCoreVisualStudio.Models;
using InventoryCoreVisualStudio.Data;
using InventoryCoreVisualStudio.Services;
using InventoryCoreVisualStudio.ViewModels;

namespace InventoryCoreVisualStudio.Controllers
{
    //[Route("administration/[controller]")]
    public class CaliberController : Controller
    {
        private readonly InventoryContext _context;
        private readonly ICaliberData _caliberData;

        public CaliberController(InventoryContext context, ICaliberData caliberData)
        {
            _context = context;
            _caliberData = caliberData;
        }

        //[Route("List")]
        // GET: Caliber
        public async Task<IActionResult> Index()
        {
            //var calList = _context.Caliber;
            //return View(await calList.ToListAsync());
            var model = _caliberData.GetAll();
            return View(model.ToList());
            
        }

        // GET: Caliber/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var caliber = await _context.Caliber
            //    .SingleOrDefaultAsync(m => m.Id == id);
            //if (caliber == null)
            //{
            //    return NotFound();
            //}

            //return View(caliber);

            var model = _caliberData.Get(id);
            if (model == null)
            {
                //return NotFound();
                return RedirectToAction("Index");
            }
            return View(model);
        }

	    public async Task<IActionResult> DetailsByName(string name)
	    {
		    if (name == null)
		    {
			    return NotFound();
		    }
		    var caliber = await _context.Caliber
			    .SingleOrDefaultAsync(c => c.Name == name);
		    if (caliber == null)
		    {
			    return NotFound();
		    }
		    return View("Details",caliber);
	    }

        // GET: Caliber/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Caliber/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DecimalSize,MetricSize")] Caliber caliber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caliber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caliber);
        }

        [HttpPost]
        public IActionResult Create2(CaliberViewModel model)
        {
            var caliber = new Caliber();
            caliber.Name = model.Name;
            caliber.DecimalSize = model.DecimalSize;
            caliber.MetricSize = model.MetricSize;

            _caliberData.Add(caliber);
            return RedirectToAction("Details", new { Id= caliber.Id});
        }
        // GET: Caliber/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caliber = await _context.Caliber.SingleOrDefaultAsync(m => m.Id == id);
            if (caliber == null)
            {
                return NotFound();
            }
            return View(caliber);
        }

        // POST: Caliber/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DecimalSize,MetricSize")] CaliberViewModel caliber)
        {
            if (id != caliber.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caliber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaliberExists(caliber.Id))
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
            return View(caliber);
        }

        // GET: Caliber/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caliber = await _context.Caliber
                .SingleOrDefaultAsync(m => m.Id == id);
            if (caliber == null)
            {
                return NotFound();
            }

            return View(caliber);
        }

        // POST: Caliber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caliber = await _context.Caliber.SingleOrDefaultAsync(m => m.Id == id);
            _context.Caliber.Remove(caliber);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaliberExists(int id)
        {
            return _context.Caliber.Any(e => e.Id == id);
        }
    }
}
