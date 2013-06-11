using ib_dotnet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ib_dotnet.Conrollers
{
    public class TopicController : Controller
    {
        private IbContext db = new IbContext();

        //
        // GET: /Topic/

        public ActionResult Index()
        {
            var topics = db.Topics.Include(t => t.CreatedBy);
            return View(topics.ToList());
        }

        //
        // GET: /Topic/Details/5

        public ActionResult Details(int id = 0)
        {
            Topic topic = db.Topics.Include(t => t.Replies.Select(r => r.CreatedBy)).SingleOrDefault(t => t.TopicId == id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        //
        // GET: /Topic/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Topic/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Topic topic)
        {

            topic.CreatedBy = db.Users.First();

            if (ModelState.IsValid)
            {
                db.Topics.Add(topic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        //
        // GET: /Topic/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedById = new SelectList(db.Users, "UserId", "Name", topic.CreatedById);
            return View(topic);
        }

        //
        // POST: /Topic/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedById = new SelectList(db.Users, "UserId", "Name", topic.CreatedById);
            return View(topic);
        }

        //
        // GET: /Topic/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        //
        // POST: /Topic/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Topic topic = db.Topics.Find(id);
            db.Topics.Remove(topic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}