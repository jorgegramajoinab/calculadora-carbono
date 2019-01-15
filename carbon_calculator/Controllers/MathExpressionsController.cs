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

namespace carbon_calculator.Controllers
{
    public class MathExpressionsController : Controller
    {
        private CarbonCalculatorModel db = new CarbonCalculatorModel();

        // GET: MathExpressions
        public async Task<ActionResult> Index()
        {
            var mathExpressions = db.MathExpressions.Include(m => m.Species);
            return View(await mathExpressions.ToListAsync());
        }

        // GET: MathExpressions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MathExpression mathExpression = await db.MathExpressions.FindAsync(id);
            if (mathExpression == null)
            {
                return HttpNotFound();
            }
            return View(mathExpression);
        }

        // GET: MathExpressions/Create
        public ActionResult Create()
        {
            ViewBag.SpeciesId = new SelectList(db.Species, "Id", "code");
            return View();
        }

        // POST: MathExpressions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,SpeciesId,Name,Expression")] MathExpression mathExpression)
        {
            if (ModelState.IsValid)
            {
                db.MathExpressions.Add(mathExpression);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SpeciesId = new SelectList(db.Species, "Id", "code", mathExpression.SpeciesId);
            return View(mathExpression);
        }

        // GET: MathExpressions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MathExpression mathExpression = await db.MathExpressions.FindAsync(id);
            if (mathExpression == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpeciesId = new SelectList(db.Species, "Id", "code", mathExpression.SpeciesId);
            return View(mathExpression);
        }

        // POST: MathExpressions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,SpeciesId,Name,Expression")] MathExpression mathExpression)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mathExpression).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SpeciesId = new SelectList(db.Species, "Id", "code", mathExpression.SpeciesId);
            return View(mathExpression);
        }

        // GET: MathExpressions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MathExpression mathExpression = await db.MathExpressions.FindAsync(id);
            if (mathExpression == null)
            {
                return HttpNotFound();
            }
            return View(mathExpression);
        }

        // POST: MathExpressions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MathExpression mathExpression = await db.MathExpressions.FindAsync(id);
            db.MathExpressions.Remove(mathExpression);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
