using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMMS.App_Start;
using SMMS.Models;
namespace SMMS.Controllers
{
    [SessionConfig]
    public class MasterController : Controller
    {
        IN705_201802_arulr1Entities1 entities;

        public MasterController()
        {
            entities = new IN705_201802_arulr1Entities1();
        }
        //Tutor
        public ActionResult Tutors()
        {
            return View(entities.Tutors.ToList());
        }

        public ActionResult TutorAction(int? id)
        {
            ViewBag.drpTutorLevel = CommonController.drpTutorLevel();

            if (id != 0)
            {
                Tutor datasetTutor = entities.Tutors.Find(id);
                User datsetUser = entities.Users.Find(datasetTutor.UserID);
                UserTutor dataset = new UserTutor();
                dataset.UserID = datsetUser.UserID;
                dataset.FirstName = datsetUser.FirstName;
                dataset.LastName = datsetUser.LastName;
                dataset.DOB = datsetUser.DOB;
                dataset.Email = datsetUser.Email;
                dataset.Phone = datsetUser.Phone;
                dataset.Password = datsetUser.Password;
                dataset.Address = datsetUser.Address;
                dataset.TutorID = datasetTutor.TutorID;
                dataset.TutorLevelID = datasetTutor.TutorLevelID;
                return PartialView(dataset);
            }

            else
            {
                return PartialView();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TutorAction(UserTutor usertutor)
        {
            ModelState.Remove("UserID");
            ModelState.Remove("TutorID");

            if (ModelState.IsValid)
            {
                string msg = "";

                if (usertutor.TutorID > 0)
                {
                    var datasetTutor = entities.Tutors.Where(f => f.TutorID == usertutor.TutorID).FirstOrDefault();
                    var datasetUser = entities.Users.Where(f => f.UserID == datasetTutor.UserID).FirstOrDefault();
                    if (datasetTutor != null && datasetUser != null)
                    {
                        datasetTutor.TutorLevelID = usertutor.TutorLevelID;

                        datasetUser.FirstName = usertutor.FirstName;
                        datasetUser.LastName = usertutor.LastName;
                        datasetUser.DOB = usertutor.DOB;
                        datasetUser.Email = usertutor.Email;
                        datasetUser.Phone = usertutor.Phone;
                        datasetUser.Address = usertutor.Address;
                        datasetUser.Password = usertutor.Password;
                        datasetUser.UserRoleID = 3;

                        entities.SaveChanges();
                        msg = "Turor details Updated Successfully";
                    }
                }
                else
                {
                    User datasetUser = new User();
                    datasetUser.FirstName = usertutor.FirstName;
                    datasetUser.LastName = usertutor.LastName;
                    datasetUser.DOB = usertutor.DOB;
                    datasetUser.Email = usertutor.Email;
                    datasetUser.Phone = usertutor.Phone;
                    datasetUser.Address = usertutor.Address;
                    datasetUser.Password = usertutor.Password;
                    datasetUser.UserRoleID = 3;
                    entities.Users.Add(datasetUser);

                    Tutor datasetTutor = new Tutor();
                    int id = usertutor.UserID;
                    datasetTutor.UserID = id;
                    datasetTutor.TutorLevelID = usertutor.TutorLevelID;
                    entities.Tutors.Add(datasetTutor);
                    entities.SaveChanges();
                    msg = "New Tutor Added successfully";
                }

                return new JsonResult
                {
                    Data = new
                    {
                        success = true,
                        action = "Tutors",
                        message = msg
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            ViewBag.drpTutorLevel = CommonController.drpTutorLevel();
            return PartialView(usertutor);

        }


        public ActionResult TutorPaylist(int? id)
        {
           var payroll = entities.Payrolls.Where(f=> f.UserID == id).Select(f=>f.PayrollID).ToList();
           var dataset = entities.PayLists.Where(f => payroll.Contains(f.PayrollID)).ToList();
           return PartialView(dataset);
          
        }

        //Tutor Skill
        public ActionResult TutorSkill(int? id)
        {
            Tutor datasetTutor = entities.Tutors.Find(id);
            var instumentLevel = entities.InstumentLevels.Where(f => f.UserID == datasetTutor.UserID).ToList();
            ViewBag.userid = datasetTutor.UserID.ToString();
            return View(instumentLevel);
        }
        public ActionResult TutorSkillAction(int? id,int? uid)
        {
            ViewBag.drpInstrument = CommonController.drpInstrument();
            ViewBag.drpCourseLevel = CommonController.drpCourseLevel();

            if (id != 0)
            {
                InstumentLevel dataset = entities.InstumentLevels.Find(id);
                return PartialView(dataset);
            }

            else
            {
                InstumentLevel dataset = new InstumentLevel();
                dataset.UserID = (int)uid;
                return PartialView(dataset);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TutorSkillAction(InstumentLevel instumentLevel)
        {
            ModelState.Remove("TutorInstumentID");

            if (ModelState.IsValid)
            {
                string msg = "";
                string uid = "";
                Tutor datasetTutor = entities.Tutors.Where(f => f.UserID == instumentLevel.UserID).FirstOrDefault();
                uid = datasetTutor.TutorID.ToString();
                if (instumentLevel.InstumentLevelID > 0)
                {
                    var dataset = entities.InstumentLevels.Where(f => f.InstumentLevelID == instumentLevel.InstumentLevelID).FirstOrDefault();
                    if (dataset != null)
                    {
                        dataset.InstrumentID = instumentLevel.InstrumentID;
                        dataset.CourseLevelID = instumentLevel.CourseLevelID;
                        dataset.UserID = instumentLevel.UserID;
                        msg = "Instrument skill Updated Successfully";
                    }
                }
                else
                {
                    entities.InstumentLevels.Add(instumentLevel);
                    msg = "New Instrument skill Added successfully";
                }
                entities.SaveChanges();
                return new JsonResult
                {
                    Data = new
                    {
                        success = true,
                        action = "TutorSkill?id="+ uid,
                        message = msg
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            ViewBag.drpCourseLevel = CommonController.drpInstrument();
            ViewBag.drpCourseLevel = CommonController.drpCourseLevel();
            return PartialView(instumentLevel);

        }

        //Student
        public ActionResult Student()
        {
            return View(entities.Students.ToList());
        }

        public ActionResult StudentAction(int? id)
        {
            ViewBag.drpStudentRole = CommonController.drpStudentRole();
            
            if (id != 0)
            {
                Student datasetStudent = entities.Students.Find(id);
                User datsetUser = entities.Users.Find(datasetStudent.UserID);
                UserStudent dataset = new UserStudent();
                dataset.UserID = datsetUser.UserID;
                dataset.FirstName = datsetUser.FirstName;
                dataset.LastName = datsetUser.LastName;
                dataset.DOB = datsetUser.DOB;
                dataset.Email = datsetUser.Email;
                dataset.Phone = datsetUser.Phone;
                dataset.Password = datsetUser.Password;
                dataset.Address = datsetUser.Address;
                dataset.StudentID = datasetStudent.StudentID;
                dataset.ParentName = datasetStudent.ParentName;
                dataset.ParentEmail = datasetStudent.ParentEmail;
                dataset.ParentPhone = datasetStudent.ParentPhone;
                dataset.ParentAddrsss = datasetStudent.ParentAddrsss;
                dataset.UserRoleID = datasetStudent.User.UserRoleID;
                return PartialView(dataset);
            }

            else
            {
                return PartialView();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StudentAction(UserStudent userstudent)
        {
            ModelState.Remove("UserID");
            ModelState.Remove("StudentID");

            if (ModelState.IsValid)
            {
                string msg = "";

                if (userstudent.StudentID > 0)
                {
                    var datasetStudent = entities.Students.Where(f => f.StudentID == userstudent.StudentID).FirstOrDefault();
                    var datasetUser = entities.Users.Where(f => f.UserID == datasetStudent.UserID).FirstOrDefault();
                    if (datasetStudent != null && datasetUser != null)
                    {
                        datasetStudent.ParentName = userstudent.ParentName;
                        datasetStudent.ParentAddrsss = userstudent.ParentAddrsss;
                        datasetStudent.ParentEmail = userstudent.ParentEmail;
                        datasetStudent.ParentPhone = userstudent.ParentPhone;


                        datasetUser.FirstName = userstudent.FirstName;
                        datasetUser.LastName = userstudent.LastName;
                        datasetUser.DOB = userstudent.DOB;
                        datasetUser.Email = userstudent.Email;
                        datasetUser.Phone = userstudent.Phone;
                        datasetUser.Address = userstudent.Address;
                        datasetUser.Password = userstudent.Password;
                        datasetUser.UserRoleID = userstudent.UserRoleID;

                        entities.SaveChanges();
                        msg = "Student details Updated Successfully";
                    }
                }
                else
                {
                    User datasetUser = new User();
                    datasetUser.FirstName = userstudent.FirstName;
                    datasetUser.LastName = userstudent.LastName;
                    datasetUser.DOB = userstudent.DOB;
                    datasetUser.Email = userstudent.Email;
                    datasetUser.Phone = userstudent.Phone;
                    datasetUser.Address = userstudent.Address;
                    datasetUser.Password = userstudent.Password;
                    datasetUser.UserRoleID = userstudent.UserRoleID;
                    entities.Users.Add(datasetUser);

                    Student datasetStudent = new Student();
                    int id = userstudent.UserID;
                    datasetStudent.UserID = id;
                    datasetStudent.ParentName = userstudent.ParentName;
                    datasetStudent.ParentAddrsss = userstudent.ParentAddrsss;
                    datasetStudent.ParentEmail = userstudent.ParentEmail;
                    datasetStudent.ParentPhone = userstudent.ParentPhone;

                    entities.Students.Add(datasetStudent);
                    entities.SaveChanges();
                    msg = "New Student Added successfully";
                }

                return new JsonResult
                {
                    Data = new
                    {
                        success = true,
                        action = "Student",
                        message = msg
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            ViewBag.drpStudentRole = CommonController.drpStudentRole();
            return PartialView(userstudent);

        }

        //Technician
        public ActionResult Technician()
        {
            return View(entities.Technicians.ToList());
        }

        public ActionResult TechnicianAction(int? id)
        {
            if (id != 0)
            {
                Technician datasetTechnician = entities.Technicians.Find(id);
                User datsetUser = entities.Users.Find(datasetTechnician.UserID);
                UserTechnician dataset = new UserTechnician();
                dataset.UserID = datsetUser.UserID;
                dataset.FirstName = datsetUser.FirstName;
                dataset.LastName = datsetUser.LastName;
                dataset.DOB = datsetUser.DOB;
                dataset.Email = datsetUser.Email;
                dataset.Phone = datsetUser.Phone;
                dataset.Password = datsetUser.Password;
                dataset.Address = datsetUser.Address;
                dataset.TechnicianID = datasetTechnician.TechnicianID;
                dataset.Description = datasetTechnician.Description;
                return PartialView(dataset);
            }

            else
            {
                return PartialView();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TechnicianAction(UserTechnician usertechnician)
        {
            ModelState.Remove("UserID");
            ModelState.Remove("TechnicianID");

            if (ModelState.IsValid)
            {
                string msg = "";

                if (usertechnician.TechnicianID > 0)
                {
                    var datasetTechnician = entities.Technicians.Where(f => f.TechnicianID == usertechnician.TechnicianID).FirstOrDefault();
                    var datasetUser = entities.Users.Where(f => f.UserID == datasetTechnician.UserID).FirstOrDefault();
                    if (datasetTechnician != null && datasetUser != null)
                    {
                        datasetTechnician.TechnicianID = usertechnician.TechnicianID;
                        datasetTechnician.Description = usertechnician.Description;

                        datasetUser.FirstName = usertechnician.FirstName;
                        datasetUser.LastName = usertechnician.LastName;
                        datasetUser.DOB = usertechnician.DOB;
                        datasetUser.Email = usertechnician.Email;
                        datasetUser.Phone = usertechnician.Phone;
                        datasetUser.Address = usertechnician.Address;
                        datasetUser.Password = usertechnician.Password;
                        datasetUser.UserRoleID = 2;

                        entities.SaveChanges();
                        msg = "Technician details Updated Successfully";
                    }
                }
                else
                {
                    User datasetUser = new User();
                    datasetUser.FirstName = usertechnician.FirstName;
                    datasetUser.LastName = usertechnician.LastName;
                    datasetUser.DOB = usertechnician.DOB;
                    datasetUser.Email = usertechnician.Email;
                    datasetUser.Phone = usertechnician.Phone;
                    datasetUser.Address = usertechnician.Address;
                    datasetUser.Password = usertechnician.Password;
                    datasetUser.UserRoleID = 4;
                    entities.Users.Add(datasetUser);

                    Technician datasetTechnician = new Technician();
                    int id = usertechnician.TechnicianID;
                    datasetTechnician.UserID = id;
                    datasetTechnician.Description = usertechnician.Description;
                    entities.Technicians.Add(datasetTechnician);
                    entities.SaveChanges();
                    msg = "New Technician Added successfully";
                }

                return new JsonResult
                {
                    Data = new
                    {
                        success = true,
                        action = "Technician",
                        message = msg
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            return PartialView(usertechnician);

        }

        //Ensemble
        public ActionResult Ensemble()
        {
            return View(entities.Ensembles.ToList());
        }
        

    }
}