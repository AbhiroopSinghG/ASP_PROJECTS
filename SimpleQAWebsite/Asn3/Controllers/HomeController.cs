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
    public class HomeController : Controller
    {
        QuestionsController qc = new QuestionsController();

        public ActionResult Index()
        {
            return qc.GetQuestions();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Badflow";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Badflow contact info.";

            return View();
        }

        public ActionResult Questions()
        {   
            return qc.GetQuestions();
        }

        [HttpGet]
        public ActionResult AddAnswer(int? id)
        { 
            Question question = qc.GetQuestionByQuestionID(id);
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAnswer(Question question,string ans)
        {
            qc.AddAnswer(question.Qid , ans);
            return RedirectToAction("Questions");
        }
    }
}