using DemoTest.Core.Model;
using DemoTest.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
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
    }
}