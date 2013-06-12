using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ib_dotnet.Models;

namespace ib_dotnet.Controllers
{
    public class ReplyController : Controller
    {
        private IbContext db = new IbContext();

        //
        // GET: /Reply/

        public ActionResult Index()
        {
            var replies = db.Replies.Include(r => r.CreatedBy);
            return View(replies.ToList());
        }

        //
        // GET: /Reply/Details/5

        public ActionResult Details(int id = 0)
        {
            Reply reply = db.Replies.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        //
        // GET: /Reply/Create

        public ActionResult Create()
        {
            ViewBag.CreatedById = new SelectList(db.Users, "UserId", "Name");            
            return View();
        }

        //
        // POST: /Reply/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reply reply, int topicId)
        {
            reply.Topic = db.Topics.Find(topicId);
            reply.CreatedBy = db.Users.First();
            if (ModelState.IsValid)
            {
                db.Replies.Add(reply);
                db.SaveChanges();
                return RedirectToAction("Details", "Topic", new {id=topicId});
            }
            return View(reply);
        }

        //
        // GET: /Reply/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Reply reply = db.Replies.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedById = new SelectList(db.Users, "UserId", "Name", reply.CreatedById);
            return View(reply);
        }

        //
        // POST: /Reply/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reply reply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedById = new SelectList(db.Users, "UserId", "Name", reply.CreatedById);
            return View(reply);
        }

        //
        // GET: /Reply/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Reply reply = db.Replies.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        //
        // POST: /Reply/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reply reply = db.Replies.Find(id);
            db.Replies.Remove(reply);
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