using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using model;
using model.Models;
using System.Linq.Expressions;

namespace carbon_calculator.Controllers
{
    public class SpeciesController : Controller
    {
        private CarbonCalculatorModel context = new CarbonCalculatorModel();

        public SpeciesController()
        {

        }

        #region view controller
        public async Task<ActionResult> Index()
        {
            return View(await context.Species.ToListAsync());
        }

        // GET: Species/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Species species = await context.Species.FindAsync(id);
            if (species == null)
            {
                return HttpNotFound();
            }
            return View(species);
        }

        // GET: Species/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Species/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,code,simpleName,commonName,scientificName,shapeCoefficient,limitYear,dryMaterial")] Species species)
        {
            if (ModelState.IsValid)
            {
                context.Species.Add(species);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(species);
        }

        // GET: Species/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Species species = await context.Species.FindAsync(id);
            if (species == null)
            {
                return HttpNotFound();
            }
            return View(species);
        }

        // POST: Species/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,code,simpleName,commonName,scientificName,shapeCoefficient,limitYear,dryMaterial")] Species species)
        {
            if (ModelState.IsValid)
            {
                context.Entry(species).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(species);
        }

        // GET: Species/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Species species = await context.Species.FindAsync(id);
            if (species == null)
            {
                return HttpNotFound();
            }
            return View(species);
        }

        // POST: Species/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Species species = await context.Species.FindAsync(id);
            context.Species.Remove(species);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
