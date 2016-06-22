using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BackEndTest01.Models;

namespace BackEndTest01.Controllers
{
    public class TurmasController : Controller
    {
        private BackEndDbContext db = new BackEndDbContext();

        // GET: Turmas
        public async Task<ActionResult> Index()
        {
            return View(await db.Turmas.ToListAsync());
        }

        // GET: Turmas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turma turma = await db.Turmas.FindAsync(id);
            if (turma == null)
            {
                return HttpNotFound();
            }
            return View(turma);
        }

        // GET: Turmas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Turno,Ano")] Turma turma)
        {
            if (ModelState.IsValid)
            {
                db.Turmas.Add(turma);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(turma);
        }

        // GET: Turmas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turma turma = await db.Turmas.FindAsync(id);
            if (turma == null)
            {
                return HttpNotFound();
            }
            return View(turma);
        }

        // POST: Turmas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Turno,Ano")] Turma turma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turma).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(turma);
        }

        // GET: Turmas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turma turma = await db.Turmas.FindAsync(id);
            if (turma == null)
            {
                return HttpNotFound();
            }
            return View(turma);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Turma turma = await db.Turmas.FindAsync(id);
            db.Turmas.Remove(turma);
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
