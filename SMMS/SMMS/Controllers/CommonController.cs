using SMMS.Models;
using System;
using System.Collections.Generic;
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
                                   Text = item.Name.ToString(),
                                   Value = item.LessonID.ToString(),
                               }).ToList();
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
                return drpData;
            }
        }
    }
}