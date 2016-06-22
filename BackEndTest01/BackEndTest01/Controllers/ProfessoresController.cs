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
    public class ProfessoresController : Controller
    {
        private BackEndDbContext db = new BackEndDbContext();

        // GET: Professores
        public async Task<ActionResult> Index()
        {
            return View(await db.Professores.ToListAsync());
        }

        // GET: Professores/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = await db.Professores.FindAsync(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // GET: Professores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProfessorId,Nome")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Professores.Add(professor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(professor);
        }

        // GET: Professores/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = await db.Professores.FindAsync(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Professores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProfessorId,Nome")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(professor);
        }

        // GET: Professores/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = await db.Professores.FindAsync(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Professores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Professor professor = await db.Professores.FindAsync(id);
            db.Professores.Remove(professor);
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
