using SMMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMMS.Controllers
{
    public class CommonController
    {
        public static List<SelectListItem> drpCourseLevel()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.CourseLevels
                                 select new SelectListItem
                                 {
                                     Text = item.LevelName.ToString(),
                                     Value = item.CourseLevelID.ToString(),
                                 }).ToList();
                drpData.Insert(0, new SelectListItem { Text = "-- Select Level --", Value = "" });
                return drpData;
            }
        }

        public static List<SelectListItem> drpInstrument()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.Instruments
                                 select new SelectListItem
                                 {
                                     Text = item.Name.ToString(),
                                     Value = item.InstrumentID.ToString(),
                                 }).ToList();
                drpData.Insert(0, new SelectListItem { Text = "-- Select Instrument --", Value = "" });
                return drpData;
            }
        }

        public static List<SelectListItem> drpLessonType()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.LessonTypes
                                 select new SelectListItem
                                 {
                                     Text = item.LessonName.ToString(),
                                     Value = item.LessonTypeID.ToString(),
                                 }).ToList();

                drpData.Insert(0, new SelectListItem { Text = "-- Select Type --", Value = "" });
                return drpData;
            }
        }

        public static List<SelectListItem> drpTutor()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.Tutors
                               select new SelectListItem
                               {
                                   Text = item.User.FirstName.ToString()+" "+ item.User.LastName.ToString(),
                                   Value = item.TutorID.ToString(),
                               }).ToList();
                drpData.Insert(0, new SelectListItem { Text = "-- Select Tutor --", Value = "" });
                return drpData;
            }
        }

        public static List<SelectListItem> drpStaff()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.Users where item.UserRoleID==2 || item.UserRoleID==3
                               select new SelectListItem
                               {
                                   Text = item.FirstName.ToString() + " " + item.LastName.ToString(),
                                   Value = item.UserID.ToString(),
                               }).ToList();
                drpData.Insert(0, new SelectListItem { Text = "-- Select staff --", Value = "" });
                return drpData;
            }
        }

        public static List<SelectListItem> drpLesson()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.Lessons
                               select new SelectListItem
                               {
                                   Text = item.Name.ToString() + " ( " +item.Instrument.Name+" - "+item.CourseLevel.LevelName.ToString()+" )",
                                   Value = item.LessonID.ToString(),
                               }).ToList();
                drpData.Insert(0, new SelectListItem { Text = "-- Select Lesson --", Value = "" });
                return drpData;
            }
        }

        public static List<SelectListItem> drpMusic()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.Musics
                               select new SelectListItem
                               {
                                   Text = item.Name.ToString(),
                                   Value = item.MusicID.ToString(),
                               }).ToList();
                drpData.Insert(0, new SelectListItem { Text = "-- Select Music --", Value = "" });
                return drpData;
            }
        }

        public static List<SelectListItem> drpNote()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.MusicSheets
                               select new SelectListItem
                               {
                                   Text = item.Name.ToString(),
                                   Value = item.MusicSheetID.ToString(),
                               }).ToList();
                drpData.Insert(0, new SelectListItem { Text = "-- Select Music Notes --", Value = "" });
                return drpData;
            }
        }
        public static List<SelectListItem> drpProgram()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.Performances
                               select new SelectListItem
                               {
                                   Text = item.Name.ToString(),
                                   Value = item.PerformanceID.ToString(),
                               }).ToList();

                drpData.Insert(0, new SelectListItem { Text = "-- Select Program --", Value = "" });
                return drpData;
            }
        }
        public static List<SelectListItem> drpTutorLevel()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.TutorLevels
                               select new SelectListItem
                               {
                                   Text = item.LevelName.ToString(),
                                   Value = item.TutorLevelID.ToString(),
                               }).ToList();
                drpData.Insert(0, new SelectListItem { Text = "-- Select Level --", Value = "" });
                return drpData;
            }
        }

        public static List<SelectListItem> drpUserRole()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.UserRoles
                               select new SelectListItem
                               {
                                   Text = item.Role.ToString(),
                                   Value = item.UserRoleID.ToString(),
                               }).ToList();
                drpData.Insert(0, new SelectListItem { Text = "-- Select Role --", Value = "" });
                return drpData;
            }
        }
        public static List<SelectListItem> drpStudentRole()
        {
            var idList = new int[2, 5];
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {

                var drpData = (from item in entity.UserRoles where item.UserRoleID>3
                               select new SelectListItem
                               {
                                   Text = item.Role.ToString(),
                                   Value = item.UserRoleID.ToString(),
                               }).ToList();
                drpData.Insert(0, new SelectListItem { Text = "-- Select Role --", Value = "" });
                return drpData;
            }
        }
        


        public static List<SelectListItem> drpInstrumentCondition()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.InstrumentConditions
                               select new SelectListItem
                               {
                                   Text = item.condition.ToString(),
                                   Value = item.InstrumentConditionID.ToString(),
                               }).ToList();
                drpData.Insert(0, new SelectListItem { Text = "-- Select Condition --", Value = "" });
                return drpData;
            }
        }
        public static List<SelectListItem> drpStudent()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.Students
                               select new SelectListItem
                               {
                                   Text = item.User.FirstName.ToString() + " "+ item.User.LastName.ToString() ,
                                   Value = item.StudentID.ToString(),
                               }).ToList();
                drpData.Insert(0, new SelectListItem { Text = "-- Select Student --", Value = "" });
                return drpData;
            }
        }
        public static List<SelectListItem> drpBatch()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.Lessonbatches
                               select new SelectListItem
                               {
                                   Text = item.Name.ToString() + " ( "+item.Lesson.Instrument.Name.ToString()+" - "+item.Lesson.CourseLevel.LevelName.ToString()+" )",
                                   Value = item.LessonBatchID.ToString(),
                               }).ToList();
                drpData.Insert(0, new SelectListItem { Text = "-- Select Batch --", Value = "" });
                return drpData;
            }
        }
        public static List<SelectListItem> drpAssert()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.InstrumentAsserts
                               select new SelectListItem
                               {

                                   Text = item.Instrument.Name +" ( "+item.InstrumentCode.ToString()+" )",
                                   Value = item.InstrumentAssertID.ToString(),
                               }).ToList();
                drpData.Insert(0, new SelectListItem { Text = "-- Select Instrument Code --", Value = "" });
                return drpData;
            }
        }
        public static List<SelectListItem> drpEnrollment()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.Enrolments
                               select new SelectListItem
                               {
                                   Text = item.Student.User.FirstName.ToString() + " " + item.Student.User.LastName.ToString()+" ( "+item.Lessonbatch.Name+" )",
                                   Value = item.EnrolmentID.ToString(),
                               }).ToList();
                drpData.Insert(0, new SelectListItem { Text = "-- Select Student Enrollment --", Value = "" });
                return drpData;
            }
        }


        public static string RenderPartialView(Controller controller, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = controller.ControllerContext.RouteData.GetRequiredString("action");

            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
        public static List<SelectListItem> drpPaymentStatus()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.PaymentStatus
                               select new SelectListItem
                               {
                                   Text = item.StatusName.ToString(),
                                   Value = item.PaymentStatus.ToString(),
                               }).ToList();
                drpData.Insert(0, new SelectListItem { Text = "-- Select Payment status --", Value = "" });
                return drpData;
            }
        }

        public static List<SelectListItem> drpTechnician()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.Technicians
                               select new SelectListItem
                               {
                                   Text = item.User.FirstName.ToString() + " "+ item.User.LastName.ToString(),
                                   Value = item.TechnicianID.ToString(),
                               }).ToList();
                drpData.Insert(0, new SelectListItem { Text = "-- Select Technician --", Value = "" });
                return drpData;
            }
        }
        public static List<SelectListItem> drpInstrumentHire()
        {
            using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
            {
                var drpData = (from item in entity.InstrumentHires
                               select new SelectListItem
                               {
                                   Text = item.Enrolment.Student.User.FirstName.ToString() + " " + item.Enrolment.Student.User.LastName.ToString()+" ( "+item.Enrolment.Lessonbatch.Name.ToString()+" )",
                                   Value = item.InstrumentHireId.ToString(),
                               }).ToList();
                drpData.Insert(0, new SelectListItem { Text = "-- Select Hire --", Value = "" });
                return drpData;
            }
        }
         
            
            



    }
}
