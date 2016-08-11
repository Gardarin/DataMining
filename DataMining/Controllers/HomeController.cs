using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataMiningModel;

namespace DataMining.Controllers
{
    public class HomeController : Controller
    {
        private DataMiningService.IDataMiningService _dataMiningService = new DataMiningService.DataMiningService();

        private AuthorisationService.IAuthorisationService _authorisationService =
            new AuthorisationService.AuthorisationService();

        [HttpGet]
        public ActionResult Index()
        {
            var cookie = Request.Cookies.Get("auth");
            if (cookie == null)
            {
                return RedirectToAction("Registration");
            }
            ViewBag.Title = cookie.Value;
            
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            var cookie = Request.Cookies.Get("auth");
            if (cookie == null)
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Registration(ViewUser viewUser)
        {
            Guid id = _authorisationService.Registration(viewUser.Name, viewUser.Password);
            ViewBag.Title = id;
            Response.Cookies.Add(new HttpCookie("auth",id.ToString()));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public void CreateResearch(string name, string description)
        {
            var cookie = Request.Cookies.Get("auth");
            if (cookie != null)
            {
                var guid = new Guid(cookie.Value);
                _dataMiningService.CreateResearch(guid, name, description);
            }
        }

        [HttpPost]
        public void DeleteResearch( int researchId)
        {
            var cookie = Request.Cookies.Get("auth");
            if (cookie != null)
            {
                var guid = new Guid(cookie.Value);
                _dataMiningService.DeleteResearch(guid, researchId);
            }
        }

        [HttpPost]
        public void SetAlgorithm(int reserchId, int algorithmId)
        {
            var cookie = Request.Cookies.Get("auth");
            if (cookie != null)
            {
                var guid = new Guid(cookie.Value);
                _dataMiningService.SetAlgorithm(guid, reserchId, algorithmId);
            }
        }

        [HttpPost]
        public void SetInputData( int reserchId, int inputDataId)
        {
            var cookie = Request.Cookies.Get("auth");
            if (cookie != null)
            {
                var guid = new Guid(cookie.Value);
                _dataMiningService.SetInputData(guid, reserchId, inputDataId);
            }
        }

        [HttpPost]
        public void StartResearch(int reserchId)
        {
            var cookie = Request.Cookies.Get("auth");
            if (cookie != null)
            {
                var guid = new Guid(cookie.Value);
                _dataMiningService.StartResearch(guid, reserchId);
            }
        }

        [HttpPost]
        public void DeleteInputData(int reserchId, int inputDataId)
        {
            var cookie = Request.Cookies.Get("auth");
            if (cookie != null)
            {
                var guid = new Guid(cookie.Value);
                _dataMiningService.DeleteInputData(guid, reserchId, inputDataId);
            }
        }

        [HttpPost]
        public void UploadInputData(string name, byte[] data)
        {
            var cookie = Request.Cookies.Get("auth");
            if (cookie != null)
            {
                var guid = new Guid(cookie.Value);
                _dataMiningService.UploadInputData(guid, name, data);
            }
        }

        [HttpPost]
        public JsonResult GetResearches()
        {
            var cookie = Request.Cookies.Get("auth");
            var researches = new List<Research>();
            if (cookie != null)
            {
                var guid = new Guid(cookie.Value);
                researches = _dataMiningService.GetResearches(guid);
            }
            var jsonResult = new JsonResult();
            jsonResult.Data = researches;
            return jsonResult;
        }
    }


    public class ViewUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
