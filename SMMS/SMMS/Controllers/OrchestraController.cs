using SMMS.App_Start;
using SMMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMMS.Controllers
{
    [SessionConfig]
    public class OrchestraController : Controller
    {
        IN705_201802_arulr1Entities1 entities;

        public OrchestraController()
        {
            entities = new IN705_201802_arulr1Entities1();
        }

        //Music

        public ActionResult Music()
        {
            return View(entities.Musics.ToList());
        }


        public ActionResult MusicAction(int? id)
        {
            if (id != 0)
            {
                Music dataset = entities.Musics.Find(id);
                return PartialView(dataset);
            }

            else
            {
                return PartialView();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MusicAction(Music music)
        {
            ModelState.Remove("MusicID");

            if (ModelState.IsValid)
            {
                string msg = "";

                if (music.MusicID > 0)
                {
                    var dataset = entities.Musics.Where(f => f.MusicID == music.MusicID).FirstOrDefault();
                    if (dataset != null)
                    {
                        dataset.Name = music.Name;
                        dataset.Description = music.Description;
                        msg = "Music Updated Successfully";
                    }
                }
                else
                {
                    entities.Musics.Add(music);
                    msg = "New Music Added successfully";
                }
                entities.SaveChanges();
                return new JsonResult
                {
                    Data = new
                    {
                        success = true,
                        action = "Music",
                        message = msg
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }

            return PartialView(music);

        }

        //Notes

        public ActionResult Note()
        {
            return View(entities.MusicSheets.ToList());
        }


        public ActionResult NoteAction(int? id)
        {
            ViewBag.drpCourseLevel = CommonController.drpCourseLevel();
            ViewBag.drpInstrument = CommonController.drpInstrument();
            ViewBag.drpMusic = CommonController.drpMusic();

            if (id != 0)
            {
                MusicSheet dataset = entities.MusicSheets.Find(id);
                return PartialView(dataset);
            }

            else
            {
                return PartialView();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult NoteAction(MusicSheet music)
        {
            ModelState.Remove("MusicSheetID");

            if (ModelState.IsValid)
            {
                string msg = "";

                if (music.MusicSheetID > 0)
                {
                    var dataset = entities.MusicSheets.Where(f => f.MusicSheetID == music.MusicSheetID).FirstOrDefault();
                    if (dataset != null)
                    {
                        dataset.Count = music.Count;
                        dataset.Description = music.Description;
                        dataset.MusicID = music.MusicID;
                        dataset.InstrumentID = music.InstrumentID;
                        dataset.CourseLevelID = music.CourseLevelID;

                        msg = "Notes Updated Successfully";
                    }
                }
                else
                {
                    entities.MusicSheets.Add(music);
                    msg = "New Notes Added successfully";
                }
                entities.SaveChanges();
                return new JsonResult
                {
                    Data = new
                    {
                        success = true,
                        action = "Note",
                        message = msg
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }

            return PartialView(music);

        }

        //Program

        public ActionResult Program()
        {
            return View(entities.Performances.ToList());
        }


        public ActionResult ProgramAction(int? id)
        {
            if (id != 0)
            {
                Performance dataset = entities.Performances.Find(id);
                return PartialView(dataset);
            }

            else
            {
                return PartialView();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProgramAction(Performance performance)
        {

            ModelState.Remove("PerformanceID");

            if (ModelState.IsValid)
            {
                string msg = "";

                if (performance.PerformanceID > 0)
                {
                    var dataset = entities.Performances.Where(f => f.PerformanceID == performance.PerformanceID).FirstOrDefault();
                    if (dataset != null)
                    {
                        dataset.Name = performance.Name;
                        dataset.PerformanceDate = performance.PerformanceDate;
                        dataset.Loaction = performance.Loaction;
                        msg = "Program Updated Successfully";
                    }
                }
                else
                {
                    entities.Performances.Add(performance);
                    msg = "New Program Added successfully";
                }
                entities.SaveChanges();
                return new JsonResult
                {
                    Data = new
                    {
                        success = true,
                        action = "Program",
                        message = msg
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }

            return PartialView(performance);

        }


        //Performances

        public ActionResult Performance()
        {
            return View(entities.PerformanceLists.ToList());
        }


        public ActionResult PerformanceAction(int? id)
        {
            ViewBag.drpNote = CommonController.drpNote();
            ViewBag.drpProgram = CommonController.drpProgram();
            if (id != 0)
            {
                PerformanceList dataset = entities.PerformanceLists.Find(id);
                return PartialView(dataset);
            }

            else
            {
                return PartialView();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PerformanceAction(PerformanceList performance)
        {
            ModelState.Remove("PerformanceListID");

            if (ModelState.IsValid)
            {
                string msg = "";

                if (performance.PerformanceListID > 0)
                {
                    var dataset = entities.PerformanceLists.Where(f => f.PerformanceListID == performance.PerformanceListID).FirstOrDefault();
                    if (dataset != null)
                    {
                        dataset.PerformanceTime = performance.PerformanceTime;
                        dataset.MusicSheetID = performance.MusicSheetID;
                        dataset.PerformanceID = performance.PerformanceID;
                        msg = "performance Updated Successfully";
                    }
                }
                else
                {
                    entities.PerformanceLists.Add(performance);
                    msg = "New performance Added successfully";
                }
                entities.SaveChanges();
                return new JsonResult
                {
                    Data = new
                    {
                        success = true,
                        action = "Program",
                        message = msg
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }

            return PartialView(performance);

        }
    }
}