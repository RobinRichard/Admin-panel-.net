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
    public class AdminController : Controller
    {
        IN705_201802_arulr1Entities1 entities;

        public AdminController()
        {
            entities = new IN705_201802_arulr1Entities1();
        }

        //Instrument Assert

        public ActionResult Assert()
        {
            return View(entities.InstrumentAsserts.ToList());
        }


        public ActionResult AssertAction(int? id)
        {
            ViewBag.drpInstrument = CommonController.drpInstrument();
            ViewBag.drpInstrumentCondition = CommonController.drpInstrumentCondition();


            if (id != 0)
            {
                InstrumentAssert dataset = entities.InstrumentAsserts.Find(id);
                return PartialView(dataset);

            }

            else
            {
                return PartialView();
            }

        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AssertAction(InstrumentAssert instrumentassert)
        {
            ModelState.Remove("InstrumentAssertID");
            ModelState.Remove("InstrumentCode");

            if (ModelState.IsValid)
            {
                string msg = "";

                if (instrumentassert.InstrumentAssertID > 0)
                {
                    var dataset = entities.InstrumentAsserts.Where(f => f.InstrumentAssertID == instrumentassert.InstrumentAssertID).FirstOrDefault();
                    if (dataset != null)
                    {
                        Instrument instument = entities.Instruments.Where(x => x.InstrumentID == instrumentassert.InstrumentID).FirstOrDefault();
                        String code = "SMMS_" + instument.Name + "_00" + instrumentassert.InstrumentAssertID;
                        dataset.InstrumentCode = code;
                        dataset.InstrumentID = instrumentassert.InstrumentID;
                        dataset.InstrumentConditionID = instrumentassert.InstrumentConditionID;
                        msg = "Instrument Updated Successfully";
                    }
                }
                else
                {
                    Instrument instument = entities.Instruments.Where(x => x.InstrumentID == instrumentassert.InstrumentID).FirstOrDefault();
                    try
                    {
                        var insAssert = entities.InstrumentAsserts.Max(x => x.InstrumentAssertID) + 1;
                        String code = "SMMS_" + instument.Name + "_00" + insAssert;
                        instrumentassert.InstrumentCode = code;
                    }
                    catch
                    {
                        String code = "SMMS_" + instument.Name + "_00" + 1;
                        instrumentassert.InstrumentCode = code;
                    }
                    
                    entities.InstrumentAsserts.Add(instrumentassert);
                    msg = "Instrument Added successfully";
                }
                entities.SaveChanges();
                return new JsonResult
                {
                    Data = new
                    {
                        success = true,
                        action = "Assert",
                        message = msg
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            ViewBag.drpInstrument = CommonController.drpInstrument();
            ViewBag.drpInstrumentCondition = CommonController.drpInstrumentCondition();

            return PartialView(instrumentassert);

        }



        //Enrolment

        public ActionResult Enrolment()
        {
            return View(entities.Enrolments.ToList());
        }


        public ActionResult EnrolmentAction(int? id)
        {
            ViewBag.drpStudent = CommonController.drpStudent();
            ViewBag.drpBatch = CommonController.drpBatch();

            if (id != 0)
            {
                Enrolment dataset = entities.Enrolments.Find(id);
                return PartialView(dataset);
            }

            else
            {
                return PartialView();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EnrolmentAction(Enrolment enrolment)
        {
            ModelState.Remove("EnrolmentID");

            if (ModelState.IsValid)
            {
                string msg = "";

                if (enrolment.EnrolmentID > 0)
                {
                    var dataset = entities.Enrolments.Where(f => f.EnrolmentID == enrolment.EnrolmentID).FirstOrDefault();
                    if (dataset != null)
                    {
                        dataset.Date = enrolment.Date;
                        dataset.StudentID = enrolment.StudentID;
                        dataset.LessonBatchID = enrolment.LessonBatchID;

                        msg = "Enrolment details Updated Successfully";
                    }
                }
                else
                {
                    entities.Enrolments.Add(enrolment);

                    msg = "New Enrollment Added successfully";
                }
                entities.SaveChanges();
                return new JsonResult
                {
                    Data = new
                    {
                        success = true,
                        action = "Enrolment",
                        message = msg
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            ViewBag.drpStudent = CommonController.drpStudent();
            ViewBag.drpBatch = CommonController.drpBatch();

            return PartialView(enrolment);

        }

        //Hire

        public ActionResult Hire()
        {
            return View(entities.InstrumentHires.ToList());
        }


        public ActionResult HireAction(int? id)
        {
            ViewBag.drpAssert = CommonController.drpAssert();
            ViewBag.drpEnrollment = CommonController.drpEnrollment();

            if (id != 0)
            {
                InstrumentHire dataset = entities.InstrumentHires.Find(id);
                return PartialView(dataset);
            }

            else
            {
                return PartialView();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult HireAction(InstrumentHire instrumenthire)
        {
            ModelState.Remove("InstrumentHireId");

            if (ModelState.IsValid)
            {
                string msg = "";

                if (instrumenthire.InstrumentHireId > 0)
                {
                    var dataset = entities.InstrumentHires.Where(f => f.InstrumentHireId == instrumenthire.InstrumentHireId).FirstOrDefault();
                    if (dataset != null)
                    {
                        dataset.Description = instrumenthire.Description;
                        dataset.InstrumentAssertID = instrumenthire.InstrumentAssertID;
                        dataset.EnrolmentID = instrumenthire.EnrolmentID;
                        dataset.InstrumentAssert.InstrumentConditionID = 3;
                        msg = "Hire details Updated Successfully";
                    }
                }
                else
                {
                    entities.InstrumentHires.Add(instrumenthire);
                    InstrumentAssert datasetassert = entities.InstrumentAsserts.Where(f => f.InstrumentAssertID == instrumenthire.InstrumentAssertID).FirstOrDefault();
                    datasetassert.InstrumentConditionID = 3;
                    msg = "New Hire details Added successfully";
                }
                entities.SaveChanges();
                return new JsonResult
                {
                    Data = new
                    {
                        success = true,
                        action = "Hire",
                        message = msg
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            ViewBag.drpAssert = CommonController.drpAssert();
            ViewBag.drpEnrollment = CommonController.drpEnrollment();

            return PartialView(instrumenthire);

        }

        //Hire
        public ActionResult Payment()
        {
            return View(entities.Payments.ToList());
        }

        public ActionResult PaymentAction(int? id)
        {
            ViewBag.drpPaymentStatus = CommonController.drpPaymentStatus();
            ViewBag.drpEnrollment = CommonController.drpEnrollment();

            if (id != 0)
            {
                Payment dataset = entities.Payments.Find(id);
                return PartialView(dataset);
            }

            else
            {
                return PartialView();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PaymentAction(Payment payment)
        {
            ModelState.Remove("PaymentID");

            if (ModelState.IsValid)
            {
                string msg = "";

                if (payment.PaymentID > 0)
                {
                    var dataset = entities.Payments.Where(f => f.PaymentID == payment.PaymentID).FirstOrDefault();
                    if (dataset != null)
                    {
                        dataset.PayableAmount = payment.PayableAmount;
                        dataset.PaidAMount = payment.PaidAMount;
                        dataset.Comments = payment.Comments;
                        dataset.EnrolmentID = payment.EnrolmentID;
                        dataset.PaymentStatus = payment.PaymentStatus;
                        msg = "Payment details Updated Successfully";
                    }
                }
                else
                {
                    entities.Payments.Add(payment);
                    msg = "New Payment Added successfully";
                }
                entities.SaveChanges();
                return new JsonResult
                {
                    Data = new
                    {
                        success = true,
                        action = "Payment",
                        message = msg
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            ViewBag.drpPaymentStatus = CommonController.drpPaymentStatus();
            ViewBag.drpEnrollment = CommonController.drpEnrollment();

            return PartialView(payment);
        }

        //Instrument Assert
        public ActionResult Service()
        {
            return View(entities.InstumentServices.ToList());
        }

        public ActionResult ServiceAction(int? id)
        {
            ViewBag.drpInstrumentHire = CommonController.drpInstrumentHire();
            ViewBag.drpTechnician = CommonController.drpTechnician();


            if (id != 0)
            {
                InstumentService dataset = entities.InstumentServices.Find(id);
                return PartialView(dataset);
            }

            else
            {
                return PartialView();
            }

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ServiceAction(InstumentService service)
        {
            ModelState.Remove("InstumentServiceID");

            if (ModelState.IsValid)
            {
                string msg = "";

                if (service.InstumentServiceID > 0)
                {
                    var dataset = entities.InstumentServices.Where(f => f.InstumentServiceID == service.InstumentServiceID).FirstOrDefault();
                    if (dataset != null)
                    {
                        dataset.Problem = service.Problem;
                        dataset.Date = service.Date;
                        dataset.Comments = service.Comments;
                        dataset.InstrumentHireId = service.InstrumentHireId;
                        dataset.TechnicianID = service.TechnicianID;
                        InstrumentAssert instrumentAssert = entities.InstrumentAsserts.Where(f => f.InstrumentAssertID == service.InstrumentHire.InstrumentAssertID).FirstOrDefault();
                        instrumentAssert.InstrumentConditionID = 2;
                        msg = "Instrument service Updated Successfully";
                    }
                }
                else
                {
                    entities.InstumentServices.Add(service);
                    InstrumentAssert instrumentAssert = entities.InstrumentAsserts.Where(f => f.InstrumentAssertID == service.InstrumentHire.InstrumentAssertID).FirstOrDefault();
                    instrumentAssert.InstrumentConditionID = 2;
                    msg = "Instrument Added successfully";
                }
                entities.SaveChanges();
                return new JsonResult
                {
                    Data = new
                    {
                        success = true,
                        action = "Service",
                        message = msg
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            ViewBag.drpInstrumentHire = CommonController.drpInstrumentHire();
            ViewBag.drpTechnician = CommonController.drpTechnician();

            return PartialView(service);

        }

        //Fee
        public ActionResult Fee()
        {
            return View(entities.FeeStructires.ToList());
        }

        public ActionResult FeeAction(int? id)
        {
            ViewBag.drpInstrument = CommonController.drpInstrument();

            if (id != 0)
            {
                FeeStructire dataset = entities.FeeStructires.Find(id);
                return PartialView(dataset);
            }

            else
            {
                return PartialView();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FeeAction(FeeStructire feestructire)
        {
            ModelState.Remove("FeeID");

            if (ModelState.IsValid)
            {
                string msg = "";

                if (feestructire.FeeID > 0)
                {
                    var dataset = entities.FeeStructires.Where(f => f.FeeID == feestructire.FeeID).FirstOrDefault();
                    if (dataset != null)
                    {
                        dataset.StudentFee = feestructire.StudentFee;
                        dataset.OpenFee = feestructire.OpenFee;
                        dataset.HireFee = feestructire.HireFee;
                        msg = "Fee Structure Updated Successfully";
                    }
                }
                else
                {
                    entities.FeeStructires.Add(feestructire);
                    msg = "New Fee Structure Added successfully";
                }
                entities.SaveChanges();
                return new JsonResult
                {
                    Data = new
                    {
                        success = true,
                        action = "Fee",
                        message = msg
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            ViewBag.drpInstrument = CommonController.drpInstrument();

            return PartialView(feestructire);

        }

        //Payroll
        public ActionResult Payroll()
        {
            bool status = false;
            DateTime dates = Convert.ToDateTime(DateTime.Now);
            if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
            {
                status = true;
                List<Payroll> payroll = entities.Payrolls.ToList();
                if (payroll.Count != 0)
                {
                    for (int i = 0; i < payroll.Count; i++)
                    {
                        if (Convert.ToDateTime(payroll[i].PreparationDate).ToShortDateString() == dates.ToShortDateString())
                            status = false;
                    }
                }
            }
            ViewBag.status = status;
            return View(entities.Payrolls.Where(f => f.PaymentStatus == 2).ToList());
        }

        public ActionResult PayrollAction(int? id)
        {

            if (id != 0)
            {
                CustomPayroll custompayroll = new CustomPayroll();
                Payroll dataset = entities.Payrolls.Find(id);

                custompayroll.UserID = dataset.UserID;
                custompayroll.UserName = dataset.User.FirstName + " " + dataset.User.LastName;
                custompayroll.PayDate = dataset.PayDate;
                custompayroll.GrossPay = dataset.GrossPay;
                custompayroll.Deduction = 0;
                custompayroll.NetPay = dataset.GrossPay;
                custompayroll.PayrollID = dataset.PayrollID;

                return PartialView(custompayroll);
            }

            else
            {
                return PartialView();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PayrollAction(CustomPayroll payroll)
        {

            if (ModelState.IsValid)
            {
                string msg = "";

                if (payroll.PayrollID > 0)
                {
                    var dataset = entities.Payrolls.Where(f => f.PayrollID == payroll.PayrollID).FirstOrDefault();
                    if (dataset != null)
                    {
                        PayList payList = new PayList();
                        payList.Deduction = payroll.Deduction;
                        payList.NetPay = payroll.NetPay;
                        payList.PaymentDate = DateTime.Now;
                        payList.PayrollID = payroll.PayrollID;
                        entities.PayLists.Add(payList);
                        dataset.PaymentStatus = 1;
                        msg = "payroll Updated Successfully";
                    }
                }
                else
                {
                    msg = "New payroll Added successfully";
                }
                entities.SaveChanges();
                return new JsonResult
                {
                    Data = new
                    {
                        success = true,
                        action = "Payroll",
                        message = msg
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }

            return PartialView(payroll);

        }
        public ActionResult GeneratePayroll()
        {
           
            try
            {
                entities.PayrollAutomation();
            
            }
            catch
            {

            }

            return RedirectToAction("Payroll");
        }
    }
}

