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
    public class SpeciesGroundIndexesController : Controller
    {
        private CarbonCalculatorModel context = new CarbonCalculatorModel();

        #region view controllers
        // GET: SpeciesGroundIndexes
        public async Task<ActionResult> Index()
        {
            var speciesGroundIndexes = context.SpeciesGroundIndexes.Include(s => s.GroundIndex).Include(s => s.Species);
            return View(await speciesGroundIndexes.ToListAsync());
        }

        // GET: SpeciesGroundIndexes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpeciesGroundIndex speciesGroundIndex = await context.SpeciesGroundIndexes.FindAsync(id);
            if (speciesGroundIndex == null)
            {
                return HttpNotFound();
            }
            return View(speciesGroundIndex);
        }

        // GET: SpeciesGroundIndexes/Create
        public ActionResult Create()
        {
            ViewBag.groundIndexId = new SelectList(context.GroundIndexes, "Id", "name");
            ViewBag.specieId = new SelectList(context.Species, "Id", "code");
            return View();
        }

        // POST: SpeciesGroundIndexes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,specieId,groundIndexId,value")] SpeciesGroundIndex speciesGroundIndex)
        {
            if (ModelState.IsValid)
            {
                context.SpeciesGroundIndexes.Add(speciesGroundIndex);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.groundIndexId = new SelectList(context.GroundIndexes, "Id", "name", speciesGroundIndex.groundIndexId);
            ViewBag.specieId = new SelectList(context.Species, "Id", "code", speciesGroundIndex.specieId);
            return View(speciesGroundIndex);
        }

        // GET: SpeciesGroundIndexes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpeciesGroundIndex speciesGroundIndex = await context.SpeciesGroundIndexes.FindAsync(id);
            if (speciesGroundIndex == null)
            {
                return HttpNotFound();
            }
            ViewBag.groundIndexId = new SelectList(context.GroundIndexes, "Id", "name", speciesGroundIndex.groundIndexId);
            ViewBag.specieId = new SelectList(context.Species, "Id", "code", speciesGroundIndex.specieId);
            return View(speciesGroundIndex);
        }

        // POST: SpeciesGroundIndexes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,specieId,groundIndexId,value")] SpeciesGroundIndex speciesGroundIndex)
        {
            if (ModelState.IsValid)
            {
                context.Entry(speciesGroundIndex).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.groundIndexId = new SelectList(context.GroundIndexes, "Id", "name", speciesGroundIndex.groundIndexId);
            ViewBag.specieId = new SelectList(context.Species, "Id", "code", speciesGroundIndex.specieId);
            return View(speciesGroundIndex);
        }

        // GET: SpeciesGroundIndexes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpeciesGroundIndex speciesGroundIndex = await context.SpeciesGroundIndexes.FindAsync(id);
            if (speciesGroundIndex == null)
            {
                return HttpNotFound();
            }
            return View(speciesGroundIndex);
        }

        // POST: SpeciesGroundIndexes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SpeciesGroundIndex speciesGroundIndex = await context.SpeciesGroundIndexes.FindAsync(id);
            context.SpeciesGroundIndexes.Remove(speciesGroundIndex);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion


        #region api controllers
        [HttpGet]
        public async Task<ActionResult> bySpecie(int specieId)
        {
            return await by(specieGroundIndex => specieGroundIndex.specieId == specieId);
        }

        protected async Task<ActionResult> by(Expression<Func<SpeciesGroundIndex, bool>> expression)
        {
            this.context.Configuration.LazyLoadingEnabled = false;
            this.context.Configuration.ProxyCreationEnabled = false;

            var specieGroundIndexes =
               await context.SpeciesGroundIndexes
                   .Include(dbSpecieGroundIndex => dbSpecieGroundIndex.GroundIndex)
                   .Include(dbSpecieGroundIndex => dbSpecieGroundIndex.Species)
                   .Where(expression)
                   .ToListAsync();


            if (!specieGroundIndexes.Any())
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Indice de sitio no encontrado.");
            }

            var groundIndex = specieGroundIndexes.First().GroundIndex;

            specieGroundIndexes.ForEach(
                speciesGroundIndex =>
                {
                    this.context.Entry(speciesGroundIndex).State = EntityState.Detached;
                    speciesGroundIndex.GroundIndex = groundIndex;
                }
            );


            return Json(new { Content = specieGroundIndexes }, JsonRequestBehavior.AllowGet);
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
