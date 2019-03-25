using SMMS.App_Start;
using SMMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SMMS.Controllers
{
    public class HomeController : Controller
    {
        IN705_201802_arulr1Entities1 entities;

        public HomeController()
        {
            entities = new IN705_201802_arulr1Entities1();
        }
        [SessionConfig]
        public ActionResult Index()
        {
            ViewBag.student = entities.Students.ToList().Count();
            ViewBag.turors = entities.Tutors.ToList().Count();
            ViewBag.technician = entities.Technicians.ToList().Count();
            ViewBag.instrumentAssert = entities.InstrumentAsserts.ToList().Count();
            ViewBag.instrument = entities.Instruments.ToList().Count();
            ViewBag.course = entities.Lessons.ToList().Count();
            ViewBag.performance = entities.Performances.ToList().Count();
            return View();
        }

        public ActionResult schedule()
        {

            return View();
        }

        public ActionResult ServiceList()
        {
            int uid = Convert.ToInt32(Session["UserID"].ToString());
            return View(entities.InstumentServices.Where(f=>f.Technician.UserID== uid).ToList());
        }
        

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult bindCalender()
        {
            int uid = Convert.ToInt32(Session["UserID"].ToString());
            int roleid = Convert.ToInt32(Session["UserTypeID"].ToString());
            string calenderdata = "";
            List<calendar> calendarList = new List<calendar>();
            if (roleid == 4)
            {
                Student datset = entities.Students.Where(f => f.UserID == uid).FirstOrDefault();
                List<Enrolment> enrolmentlist = entities.Enrolments.Where(f => f.StudentID == datset.StudentID).ToList();
                for (int i = 0; i < enrolmentlist.Count; i++)
                {
                    calendar calendar = new calendar();
                    calendar.BatchID = enrolmentlist[i].Lessonbatch.LessonBatchID;
                    calendar.UserName = datset.User.FirstName + " " + datset.User.LastName;
                    calendar.Day = enrolmentlist[i].Lessonbatch.BatchDate.Day.ToString();
                    calendar.Month = enrolmentlist[i].Lessonbatch.BatchDate.Month.ToString();
                    calendar.Year = enrolmentlist[i].Lessonbatch.BatchDate.Year.ToString();
                    calendar.StartTimeHour = enrolmentlist[i].Lessonbatch.StartTime.Hours.ToString();
                    calendar.StartTimeMin = enrolmentlist[i].Lessonbatch.StartTime.Minutes.ToString();
                    calendar.Event = enrolmentlist[i].Lessonbatch.Name.ToString();
                    calendarList.Add(calendar);
                }
            }
            if (roleid == 3)
            {
                Tutor datset = entities.Tutors.Where(f => f.UserID == uid).FirstOrDefault();
                List<Lessonbatch> lessonbatchlist = entities.Lessonbatches.Where(f => f.TutorID == datset.TutorID).ToList();
                for (int i = 0; i < lessonbatchlist.Count; i++)
                {
                    calendar calendar = new calendar();
                    calendar.BatchID = lessonbatchlist[i].LessonBatchID;
                    calendar.UserName = datset.User.FirstName + " " + datset.User.LastName;
                    calendar.Day = lessonbatchlist[i].BatchDate.Day.ToString();
                    calendar.Month = lessonbatchlist[i].BatchDate.Month.ToString();
                    calendar.Year = lessonbatchlist[i].BatchDate.Year.ToString();
                    calendar.StartTimeHour = lessonbatchlist[i].StartTime.Hours.ToString();
                    calendar.StartTimeMin = lessonbatchlist[i].StartTime.Minutes.ToString();
                    calendar.Event = lessonbatchlist[i].Name.ToString();
                    calendarList.Add(calendar);
                }
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            calenderdata = serializer.Serialize(calendarList);

            return new JsonResult
            {
                Data = new
                {
                    success = true,
                    data = calenderdata
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }



        public ActionResult LoginAction(string username, string password)
        {
            var u = entities.Users.Where(a => a.Email.Equals(username) && a.Password.Equals(password)).FirstOrDefault();

            if (u != null)
            {

                if (u.UserRoleID == 3)
                {
                    string ttype = "";
                    Tutor tutor = entities.Tutors.Where(f => f.UserID == u.UserID).FirstOrDefault();
                    if (tutor.TutorLevelID == 1)
                    {
                        ttype = "head";

                    }
                        Session["UserID"] = u.UserID.ToString();
                        var role = entities.UserRoles.Where(a => a.UserRoleID == u.UserRoleID).FirstOrDefault();
                        Session["UserType"] = tutor.TutorLevel.LevelName.ToString();
                        Session["TutorType"] = tutor.TutorLevel.TutorLevelID.ToString();
                        Session["UserTypeID"] = role.UserRoleID.ToString();
                        Session["UserName"] = u.FirstName.ToString() + " " + u.LastName.ToString();

                        return new JsonResult
                        {
                            Data = new
                            {
                                success = true,
                                type = ttype
                            },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                }
                else
                {
                    Session["UserID"] = u.UserID.ToString();
                    var role = entities.UserRoles.Where(a => a.UserRoleID == u.UserRoleID).FirstOrDefault();
                    Session["UserType"] = role.Role.ToString();
                    Session["TutorType"] = "0";
                    Session["UserTypeID"] = role.UserRoleID.ToString();
                    Session["UserName"] = u.FirstName.ToString() + " " + u.LastName.ToString();

                    return new JsonResult
                    {
                        Data = new
                        {
                            success = true,
                            type = role.UserRoleID.ToString()
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
            }

            return new JsonResult
            {
                Data = new
                {
                    success = false
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}