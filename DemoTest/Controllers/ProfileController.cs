using DemoTest.App_Start;
using DemoTest.Core.Model;
using DemoTest.Core.RepositoryInterface;
using DemoTest.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace DemoTest.Controllers
{
    [ErrorFilterAttribute]
    public class ProfileController : Controller
    {
        private readonly IProfile _iProfileRepository;

        public ProfileController(IProfile iProfileRepository)
        {
            _iProfileRepository = iProfileRepository;
        }

        #region Public Method

        public ActionResult Create()
        {
            GetMasterData();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Profile profile)
        {
            var result = _iProfileRepository.Create(profile);
            if (result)
            {
                if (SendEmailToUser(profile.EmailId))
                {
                    return Json("Successfully Registered", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Successfully Registered. Email not sent", JsonRequestBehavior.AllowGet);
                }
            }
            return Json("Successfully Registered", JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Private Method

        private void GetMasterData()
        {
            var result = _iProfileRepository.GetMasterData();
            if (result != null && result.Count > 0)
            {
                ViewBag.GetBusinessSegment = (List<BusinessSegment>)result[0];
                ViewBag.GetBusinessArea = (List<BusinessArea>)result[1];
            }
        }

        private bool SendEmailToUser(string toEmailId)
        {
            try
            {
                string fromEmailId = Convert.ToString(ConfigurationManager.AppSettings["FromEmailAddress"]);
                string SubjectLine = "Registration Successfull!!!";

                Common.SendEmail(fromEmailId, toEmailId, "", SubjectLine, "");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}