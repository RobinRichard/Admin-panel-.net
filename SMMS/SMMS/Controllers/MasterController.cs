using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMMS.Models;
namespace SMMS.Controllers
{
    public class MasterController : Controller
    {
        IN705_201802_arulr1Entities1 entities;

        public MasterController()
        {
            entities = new IN705_201802_arulr1Entities1();
        }
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Student()
        {
            ViewBag.Message = "Student page";

            return View();
        }

        public ActionResult Tutors()
        {
            return View(entities.Tutors.ToList());
        }

        public ActionResult TutorsAction()
        {
            return View();
        }

        



    }
}