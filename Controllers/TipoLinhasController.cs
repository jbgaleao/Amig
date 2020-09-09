using Amigurumis.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Amigurumis.Controllers
{
    public class TipoLinhasController : Controller
    {
        private AmigurumisContext db = new AmigurumisContext();

        // GET: TipoLinhas
        public ActionResult Index()
        {
            return View(db.TIPOSLINHA.ToList());
        }

        // GET: TipoLinhas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLinha tipoLinha = db.TIPOSLINHA.Find(id);
            if (tipoLinha == null)
            {
                return HttpNotFound();
            }
            return View(tipoLinha);
        }

        // GET: TipoLinhas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoLinhas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] TipoLinha tipoLinha)
        {
            if (ModelState.IsValid)
            {
                db.TIPOSLINHA.Add(tipoLinha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoLinha);
        }

        // GET: TipoLinhas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLinha tipoLinha = db.TIPOSLINHA.Find(id);
            if (tipoLinha == null)
            {
                return HttpNotFound();
            }
            return View(tipoLinha);
        }

        // POST: TipoLinhas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] TipoLinha tipoLinha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoLinha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoLinha);
        }

        // GET: TipoLinhas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLinha tipoLinha = db.TIPOSLINHA.Find(id);
            if (tipoLinha == null)
            {
                return HttpNotFound();
            }
            return View(tipoLinha);
        }

        // POST: TipoLinhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoLinha tipoLinha = db.TIPOSLINHA.Find(id);
            db.TIPOSLINHA.Remove(tipoLinha);
            db.SaveChanges();
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
