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
    //[Route("admin/[controller]")]
    public class CaliberController : Controller
    {
        //private readonly InventoryContext _context;
        //private readonly ICaliberData _caliberData;
        private ICaliberRepository _caliberRepository;

        //public CaliberController()
        //{
        //    _caliberRepository = new CaliberRepository(new InventoryContext());
        //}

        public CaliberController(ICaliberRepository caliberRepository) => _caliberRepository = caliberRepository;

        //[Route("List")]
        // GET: Caliber
        public async Task<IActionResult> Index()
        {
            //var calList = _context.Caliber;
            //return View(await calList.ToListAsync());
            var model = _caliberRepository.GetCaliber();
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

            var model = _caliberRepository.GetCaliberById(id);
            if (model == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

	    public async Task<IActionResult> DetailsByName(string name)
	    {
		    if (name == null)
		    {
			    return NotFound();
		    }
            var caliber = _caliberRepository.GetCaliber().FirstOrDefault(c => c.Name == name);

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
                _caliberRepository.InsertCaliber(caliber);
                //_context.Add(caliber);
                //await _context.SaveChangesAsync();
                _caliberRepository.Save();
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

            _caliberRepository.InsertCaliber(caliber);
            _caliberRepository.Save();
            //_caliberData.Add(caliber);
            return RedirectToAction("Details", new { Id= caliber.Id});
        }
        // GET: Caliber/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _caliberRepository.GetCaliberById(id);
         
            return View(model);
        }

        // POST: Caliber/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            Caliber model = _caliberRepository.GetCaliberById(id);
            if (model == null)
            {
                //return NotFound();
                return RedirectToAction("Index");
            }

            if (await TryUpdateModelAsync<Caliber>(model,
                "",
                c => c.Name, c => c.MetricSize, c => c.DecimalSize))
            {
                try
                {
                    _caliberRepository.Save();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", @"Unable to save changes. 
                        Try again, and if the problem persists, see your system administrator.");
                }
            }

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _caliberRepository.UpdateCaliber(caliber);
            //        //_context.Update(caliber);
            //        //await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!CaliberExists(caliber.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            return View(model);
        }

        // GET: Caliber/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caliber = _caliberRepository.GetCaliberById(id);
            //var caliber = await _context.Caliber
              //  .SingleOrDefaultAsync(m => m.Id == id);
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
            var caliber = _caliberRepository.GetCaliberById(id);
            //var caliber = await _context.Caliber.SingleOrDefaultAsync(m => m.Id == id);
            //_context.Caliber.Remove(caliber);
            _caliberRepository.DeleteCaliber(id);
            _caliberRepository.Save();
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaliberExists(int id)
        {
            return _caliberRepository.GetCaliber().Any(c => c.Id == id);
            //return _context.Caliber.Any(e => e.Id == id);
        }
    }
}
