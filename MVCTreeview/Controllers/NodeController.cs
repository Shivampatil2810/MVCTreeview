using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCTreeview.Controllers
{
    public class NodeController : Controller
    {
        // GET: Node
        private MyDatabaseEntities db  = new MyDatabaseEntities();
        // GET: Node
        public ActionResult Index()
        {
            return View(db.NodeDetails.ToList());
        }

        // GET: Node/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NodeDetail node = db.NodeDetails.Find(id);
            if (node == null)
            {
                return HttpNotFound();
            }
            return View(node);
        }

        // GET: Node/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Node/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NodeId,NodeName,IsActive,StartDate,ParentNodeId")] NodeDetail node)
        {
            if (ModelState.IsValid)
            {
                db.NodeDetails.Add(node);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(node);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NodeDetail node = db.NodeDetails.Find(id);
            if (node == null)
            {
                return HttpNotFound();
            }
            
            return View(node);
        }

        // POST: Departments/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NodeId,NodeName,IsActive,StartDate,ParentNodeId")] NodeDetail node)
        {
            if (ModelState.IsValid)
            {
                db.Entry(node).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(node);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NodeDetail node = db.NodeDetails.Find(id);
            if (node == null)
            {
                return HttpNotFound();
            }
            return View(node);
        }
        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NodeDetail node = db.NodeDetails.Find(id);
            db.NodeDetails.Remove(node);
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