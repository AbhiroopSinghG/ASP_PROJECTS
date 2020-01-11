using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Asn3.Models;

namespace Asn3.Controllers
{
    public class QuestionsController : Controller
    {
        private StackContext db = new StackContext();

        // GET: Questions
        public ActionResult GetQuestions()
        {
            return View(db.Questions.ToList());
        }

        public int getAnswerCount(int id)
        {
            return db.Answers.Where(C => C.QuestionId == id).Count()+1;
        }

        // GET: Questions/Details/5
        public Question GetQuestionByQuestionID(int? id)
        {
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return null;
            }
            return question;
        }

        public void AddAnswer(int id, string text)
        {
            Answer answer = new Answer(id, text);
            db.Answers.Add(answer);
            var question = db.Questions.FirstOrDefault(u => u.Qid==id);
            question.Catobjref = getAnswerCount(id).ToString();
            db.SaveChanges();

        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Qid,Qname,Qdatetime,Categoryid,Catobjref")] Question question)
        {
            question.Qdatetime = DateTime.Today.ToString();
            question.Catobjref = "0";
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Questions","Home");
            }

            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Qid,Qname,Qdatetime,Categoryid,Catobjref")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
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
