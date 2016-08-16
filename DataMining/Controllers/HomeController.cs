using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataMiningModel;
using DataMiningModel.Algorithms;
using DataMiningModel.DataForResearching;

namespace DataMining.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataMiningService.IDataMiningService _dataMiningService = new DataMiningService.DataMiningService();

        private readonly AuthorisationService.IAuthorisationService _authorisationService =
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
        public void Init()
        {
            var cookie = Request.Cookies.Get("auth");
            if (cookie != null)
            {
                var guid = new Guid(cookie.Value);
                _dataMiningService.Init(guid);
            }
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
        public void SetAlgorithm(int researchId, int algorithmId)
        {
            var cookie = Request.Cookies.Get("auth");
            if (cookie != null)
            {
                var guid = new Guid(cookie.Value);
                _dataMiningService.SetAlgorithm(guid, researchId, algorithmId);
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

        #region Geters

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
            var jsonResult = new JsonResult()
            {
                Data = researches
            };
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetAlgorithms()
        {
            var cookie = Request.Cookies.Get("auth");
            var algorithms = new List<Algorithm>();

            if (cookie != null)
            {
                var guid = new Guid(cookie.Value);
                algorithms = _dataMiningService.GetAlgorithms(guid);
            }

            var jsonResult = new JsonResult()
            {
                Data = algorithms
            };

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetAlgorithmById(int researchId)
        {
            var cookie = Request.Cookies.Get("auth");
            Algorithm algorithm = null;

            if (cookie != null)
            {
                var guid = new Guid(cookie.Value);
                algorithm = _dataMiningService.GetAlgorithmById(guid, researchId);
            }

            var jsonResult = new JsonResult()
            {
                Data = algorithm
            };

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetInputDatas(int inputDataId)
        {
            var cookie = Request.Cookies.Get("auth");
            var inputData = new InputData();

            if (cookie != null)
            {
                var guid = new Guid(cookie.Value);
                inputData = _dataMiningService.GetInputDataById(guid,inputDataId);
            }

            var jsonResult = new JsonResult()
            {
                Data = inputData
            };

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetInputDatas()
        {
            var cookie = Request.Cookies.Get("auth");
            var inputData = new List<InputData>();

            if (cookie != null)
            {
                var guid = new Guid(cookie.Value);
                inputData = _dataMiningService.GetInputDatas(guid);
            }

            var jsonResult = new JsonResult()
            {
                Data = inputData
            };

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetOutputDatas()
        {
            var cookie = Request.Cookies.Get("auth");
            var outputData = new List<OutputData>();

            if (cookie != null)
            {
                var guid = new Guid(cookie.Value);
                outputData = _dataMiningService.GetOutputDatas(guid);
            }

            var jsonResult = new JsonResult()
            {
                Data = outputData
            };

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetInputDataById(int inputDataId)
        {
            throw new NotImplementedException();
            var cookie = Request.Cookies.Get("auth");
            var inputData = new InputData();

            if (cookie != null)
            {
                var guid = new Guid(cookie.Value);
                inputData = _dataMiningService.GetInputDataById(guid, inputDataId);
            }

            var jsonResult = new JsonResult()
            {
                Data = inputData
            };

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetOutputDataById(int outputDataId)
        {
            var cookie = Request.Cookies.Get("auth");
            var outputData = new OutputData();

            if (cookie != null)
            {
                var guid = new Guid(cookie.Value);
                outputData = _dataMiningService.GetOutputDataById(guid, outputDataId);
            }

            var jsonResult = new JsonResult()
            {
                Data = outputData
            };

            return jsonResult;
        }

        #endregion
    }


    public class ViewUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
