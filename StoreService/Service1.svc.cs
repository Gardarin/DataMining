using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataMiningModel;
using DataMiningModel.Algorithms;
using DataMiningModel.DataForResearching;
using StoreService.DbModel;

namespace DataBaseService
{
    public class DataBaseService : IDataBaseService
    {
        private readonly DataMiningContext _dataMiningContext = new DataMiningContext();

        public void Init(Guid sessionId)
        {
            var alg = new DataMiningModel.Algorithms.AprioriAlgorithm()
            {
                Name = "Apriori",
                Description = "tet description"
            };
            _dataMiningContext.Algorithms.Add(alg);
            UsingAlgoritm ua = new UsingAlgoritm()
            {
                CurentAlgoritm = _dataMiningContext.Algorithms.FirstOrDefault(x => x.Name == "Apriori")
            };
            var user = _dataMiningContext.Users.Include("Researches").Include("UsingAlgoritms.CurentAlgoritm").FirstOrDefault(x => x.SessionId == sessionId);
            if (user == null)
            {
                return;
            }
            if (user.UsingAlgoritms == null)
            {
                user.UsingAlgoritms = new List<UsingAlgoritm>();
            }
            user.UsingAlgoritms.Add(ua);
            _dataMiningContext.SaveChanges();
        }

        public void CreateResearch(Guid sessionId, string name, string description)
        {
            if (IsEmpty(sessionId))
            {
                return;
            }
            var research = new Research()
            {
                Algorithm = null,
                Name = name,
                Description = description,
                InputData = null,
                OutputData = null,
                CurentState = Research.State.Created,
            };

            var user = _dataMiningContext.Users.Include("Researches").FirstOrDefault(x => x.SessionId == sessionId);
            if (user == null)
            {
                return;
            }
            if (user.Researches == null)
            {
                user.Researches = new List<Research>(5);
            }
            user.Researches.Add(research);
            _dataMiningContext.SaveChanges();
        }

        public void DeleteResearch(Guid sessionId, int researchId)
        {
            if (IsEmpty(sessionId))
            {
                return;
            }
            var user = _dataMiningContext.Users.Include("Researches").FirstOrDefault(x => x.SessionId == sessionId);
            if (user == null)
            {
                return;
            }
            if (user.Researches == null)
            {
                return;
            }
            var research = user.Researches.FirstOrDefault(x => x.ResearchId == researchId);
            user.Researches.Remove(research);
            _dataMiningContext.SaveChanges();
        }

        public void SetAlgorithm(Guid sessionId, int reserchId, int algorithmId)
        {
            if (IsEmpty(sessionId))
            {
                return;
            }
            var user = _dataMiningContext.Users.Include("Researches").Include("UsingAlgoritms.CurentAlgoritm").FirstOrDefault(x => x.SessionId == sessionId);
            if (user == null || user.Researches == null || user.UsingAlgoritms == null)
            {
                return;
            }
            var research = user.Researches.FirstOrDefault(x => x.ResearchId == reserchId);
            if (research == null)
            {
                return;
            }
            var algorithm = user.UsingAlgoritms.FirstOrDefault(x => x.CurentAlgoritm.AlgorithmId == algorithmId);
            if (algorithm == null)
            {
                return;
            }
            research.Algorithm = algorithm.CurentAlgoritm;
            _dataMiningContext.SaveChanges();
        }

        public void SetInputData(Guid sessionId, int reserchId, int inputDataId)
        {
            if (IsEmpty(sessionId))
            {
                return;
            }
            var user = _dataMiningContext.Users.Include("Researches").FirstOrDefault(x => x.SessionId == sessionId);
            if (user == null || user.Researches == null)
            {
                return;
            }
            var research = user.Researches.FirstOrDefault(x => x.ResearchId == reserchId);
            if (research == null)
            {
                return;
            }
            var inputData = user.InputDatas.FirstOrDefault(x => x.Id == inputDataId);
            if (inputData == null)
            {
                return;
            }
            research.InputData = inputData;
            _dataMiningContext.SaveChanges();
        }

        public void StartResearch(Guid sessionId, int reserchId)
        {
            throw new NotImplementedException();
        }

        public void DeleteInputData(Guid sessionId, int reserchId, int inputDataId)
        {
            if (IsEmpty(sessionId))
            {
                return;
            }
            var user = _dataMiningContext.Users.Include("Researches").FirstOrDefault(x => x.SessionId == sessionId);
            if (user == null || user.Researches == null)
            {
                return;
            }
            var research = user.Researches.FirstOrDefault(x => x.ResearchId == reserchId);
            if (research == null)
            {
                return;
            }
            var inputData = user.InputDatas.FirstOrDefault(x => x.Id == inputDataId);
            if (inputData == null)
            {
                return;
            }
            research.InputData = null;
            user.InputDatas.Remove(inputData);
            _dataMiningContext.SaveChanges();
        }

        public void UploadInputData(Guid sessionId, string name, byte[] data)
        {
            if (IsEmpty(sessionId))
            {
                return;
            }
            var user = _dataMiningContext.Users.Include("InputDatas").FirstOrDefault(x => x.SessionId == sessionId);
            if (user == null)
            {
                return;
            }
            InputData inputData = new InputData()
            {
                Name = name,
                DataBytes = data
            };
            user.InputDatas.Add(inputData);
            _dataMiningContext.SaveChanges();
        }

        #region Geters;

        public List<Research> GetResearches(Guid sessionId)
        {
            if (IsEmpty(sessionId))
            {
                return null;
            }
            var user = _dataMiningContext.Users.Include("Researches").FirstOrDefault(x => x.SessionId == sessionId);
            if (user == null || user.Researches == null)
            {
                return new List<Research>();
            }
            return user.Researches;

        }

        public Research GetResearchById(Guid sessionId, int researchId)
        {
            if (IsEmpty(sessionId))
            {
                return null;
            }
            var user = _dataMiningContext.Users.Include("Researches").FirstOrDefault(x => x.SessionId == sessionId);
            if (user == null || user.Researches == null)
            {
                return null;
            }
            return user.Researches.FirstOrDefault(x => x.ResearchId == researchId);
        }

        public List<Algorithm> GetAlgorithms(Guid sessionId)
        {
            if (IsEmpty(sessionId))
            {
                return null;
            }
            var user = _dataMiningContext.Users.Include("UsingAlgoritms").FirstOrDefault(x => x.SessionId == sessionId);
            if (user == null || user.UsingAlgoritms == null)
            {
                return new List<Algorithm>();
            }
            var algorithms = new List<Algorithm>();
            foreach (var ua in user.UsingAlgoritms)
            {
                algorithms.Add(ua.CurentAlgoritm);
            }
            return algorithms;
        }

        public Algorithm GetAlgorithmById(Guid sessionId, int researchId)
        {
            if (IsEmpty(sessionId))
            {
                return null;
            }
            var user = _dataMiningContext.Users.Include("Researches.Algorithm").FirstOrDefault(x => x.SessionId == sessionId);
            if (user == null || user.Researches == null)
            {
                return null;
            }
            var ua = user.Researches.FirstOrDefault(x => x.ResearchId == researchId);
            if (ua == null)
            {
                return null;
            }
            return ua.Algorithm;
        }

        public List<InputData> GetInputDatas(Guid sessionId)
        {
            if (IsEmpty(sessionId))
            {
                return null;
            }
            var user = _dataMiningContext.Users.Include("InputDatas").FirstOrDefault(x => x.SessionId == sessionId);
            if (user == null || user.InputDatas == null)
            {
                return null;
            }
            return user.InputDatas;
        }

        public List<OutputData> GetOutputDatas(Guid sessionId)
        {
            if (IsEmpty(sessionId))
            {
                return null;
            }
            var user = _dataMiningContext.Users.Include("OutputDatas").FirstOrDefault(x => x.SessionId == sessionId);
            if (user == null || user.OutputDatas == null)
            {
                return null;
            }
            return user.OutputDatas;
        }

        public InputData GetInputDataById(Guid sessionId, int inputDataId)
        {
            if (IsEmpty(sessionId))
            {
                return null;
            }
            var user = _dataMiningContext.Users.Include("InputDatas").FirstOrDefault(x => x.SessionId == sessionId);
            if (user == null || user.InputDatas == null)
            {
                return null;
            }
            return user.InputDatas.FirstOrDefault(x => x.Id == inputDataId);
        }

        public OutputData GetOutputDataById(Guid sessionId, int outputDataId)
        {
            if (IsEmpty(sessionId))
            {
                return null;
            }
            var user = _dataMiningContext.Users.Include("OutputDatas").FirstOrDefault(x => x.SessionId == sessionId);
            if (user == null || user.OutputDatas == null)
            {
                return null;
            }
            return user.OutputDatas.FirstOrDefault(x => x.Id == outputDataId);
        }

        #endregion

        #region AuthService;

        public bool Registration(string name, string password)
        {
            var user = new User()
            {
                Name = name,
                Password = password,
                InputDatas = new List<InputData>(),
                OutputDatas = new List<OutputData>(),
                Researches = new List<Research>(),
                UsingAlgoritms = new List<UsingAlgoritm>()
            };
            _dataMiningContext.Users.Add(user);
            _dataMiningContext.SaveChanges();
            return true;
        }

        public Guid SignIn(string name, string password)
        {
            var user = _dataMiningContext.Users.FirstOrDefault(x => x.Name == name);
            if (user != null && user.Password == password)
            {
                user.SessionId = new Guid("00000000-1111-2222-3333-000000000000");
                _dataMiningContext.SaveChanges();
                return user.SessionId;
            }
            return Guid.Empty;
        }

        public bool SignOn(Guid sessionId)
        {
            var user = _dataMiningContext.Users.FirstOrDefault(x => x.SessionId == sessionId);
            if (user != null)
            {
                user.SessionId = Guid.Empty;
                return true;
            }
            return false;
        }

        #endregion

        private bool IsEmpty(Guid id)
        {
            if (id == Guid.Empty)
            {
                return true;
            }
            return false;
        }
    }
}
