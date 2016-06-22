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
    public class DisciplinasController : Controller
    {
        private BackEndDbContext db = new BackEndDbContext();

        // GET: Disciplinas
        public async Task<ActionResult> Index()
        {
            var disciplinas = db.Disciplinas.Include(d => d.Professor);
            return View(await disciplinas.ToListAsync());
        }

        // GET: Disciplinas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disciplina disciplina = await db.Disciplinas.FindAsync(id);
            if (disciplina == null)
            {
                return HttpNotFound();
            }
            return View(disciplina);
        }

        // GET: Disciplinas/Create
        public ActionResult Create()
        {
            ViewBag.ProfessorId = new SelectList(db.Professores, "ProfessorId", "Nome");
            return View();
        }

        // POST: Disciplinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DisciplinaId,Nome,ProfessorId")] Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                db.Disciplinas.Add(disciplina);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProfessorId = new SelectList(db.Professores, "ProfessorId", "Nome", disciplina.ProfessorId);
            return View(disciplina);
        }

        // GET: Disciplinas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disciplina disciplina = await db.Disciplinas.FindAsync(id);
            if (disciplina == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfessorId = new SelectList(db.Professores, "ProfessorId", "Nome", disciplina.ProfessorId);
            return View(disciplina);
        }

        // POST: Disciplinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DisciplinaId,Nome,ProfessorId")] Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disciplina).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProfessorId = new SelectList(db.Professores, "ProfessorId", "Nome", disciplina.ProfessorId);
            return View(disciplina);
        }

        // GET: Disciplinas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disciplina disciplina = await db.Disciplinas.FindAsync(id);
            if (disciplina == null)
            {
                return HttpNotFound();
            }
            return View(disciplina);
        }

        // POST: Disciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Disciplina disciplina = await db.Disciplinas.FindAsync(id);
            db.Disciplinas.Remove(disciplina);
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
