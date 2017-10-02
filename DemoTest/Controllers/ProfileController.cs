using DemoTest.Core.Model;
using DemoTest.Core.RepositoryInterface;
using DemoTest.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace DemoTest.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfile _iProfileRepository;

        public ProfileController(IProfile iProfileRepository)
        {
            _iProfileRepository = iProfileRepository;
        }

        public ActionResult Create()
        {
            GetMasterData();
            return View();
        }

        private void GetMasterData()
        {
            var result = _iProfileRepository.GetMasterData();
            //test
            if (result != null && result.Count > 0)
            {
                ViewBag.GetBusinessSegment = (List<BusinessSegment>)result[0];
                ViewBag.GetBusinessArea = (List<BusinessArea>)result[1];
            }
        }
        [HttpPost]
        public ActionResult Create(Profile profile)
        {
            try
            {
                var result = _iProfileRepository.Create(profile);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string SendEmailToAgents(string requirementIdList, string emailIdList)
        {
            try
            {
                DateTime dt = DateTime.Now;
                string timeStamp = dt.Day + "_" + dt.Month + "_" + dt.Year + "_" + dt.Second;
                string filePath = Server.MapPath(ConfigurationManager.AppSettings["RequirementFiles"]) + timeStamp + ".xlsx";

                string SubjectLine = "Requirement Details";
                string fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"];
                if (!string.IsNullOrEmpty(fromEmailAddress))
                {
                    Common.SendEmail(fromEmailAddress, emailIdList, filePath, SubjectLine, "");
                }
                return "Requirement Details sent successfully!!!";
            }
            catch (Exception ex)
            {
                Common.LogError("SendEmailToAgents", "", "SendEmailToAgents", "EXCEPTION OCCURED", Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                return "Error occurred while sending mail.";
            }
        }
    }
}