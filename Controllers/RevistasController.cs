using Amigurumis.Models;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Amigurumis.Controllers
{
    public class RevistasController : Controller
    {
        private AmigurumisContext db = new AmigurumisContext();

        // GET: Revistas
        public ActionResult Index()
        {
            return View(db.REVISTAS.ToList());
        }

        // desserializando a imagem 
        public FileContentResult getImagem(int id)
        {
            byte[] byteArray = db.REVISTAS.Find(id).FotoCapa;
            return byteArray != null
                ? new FileContentResult(byteArray, "image/jpeg")
                : null;
        }


        // GET: Revistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revista revista = db.REVISTAS.Find(id);
            if (revista == null)
            {
                return HttpNotFound();
            }
            return View(revista);
        }

        // GET: Revistas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Revistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tema,NumeroEdicao,FotoCapa")] Revista revista, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
               
                    if (file.FileName != null)
                    {
                        MemoryStream target = new MemoryStream();
                        file.InputStream.CopyTo(target);
                        byte[] data = target.ToArray();
                        revista.FotoCapa = data;
                    }
                    db.REVISTAS.Add(revista);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                
               

            }

            return View(revista);
        }

        // GET: Revistas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revista revista = db.REVISTAS.Find(id);
            if (revista == null)
            {
                return HttpNotFound();
            }
            return View(revista);
        }

        // POST: Revistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tema,NumeroEdicao,FotoCapa")] Revista revista, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.FileName != null)
                {
                    MemoryStream target = new MemoryStream();
                    file.InputStream.CopyTo(target);
                    byte[] data = target.ToArray();
                    revista.FotoCapa = data;
                }
                db.Entry(revista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(revista);
        }

        // GET: Revistas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revista revista = db.REVISTAS.Find(id);
            if (revista == null)
            {
                return HttpNotFound();
            }
            return View(revista);
        }

        // POST: Revistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Revista revista = db.REVISTAS.Find(id);
            db.REVISTAS.Remove(revista);
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
