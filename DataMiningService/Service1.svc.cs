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

namespace DataMiningService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DataMiningService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DataMiningService.svc or DataMiningService.svc.cs at the Solution Explorer and start debugging.
    public class DataMiningService : IDataMiningService
    {
        private readonly DataBaseService.IDataBaseService _dataBaseService = new DataBaseService.DataBaseService();

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public void CreateResearch(Guid sessionId, string name, string description)
        {
            _dataBaseService.CreateResearch(sessionId, name, description);
        }

        public void DeleteResearch(Guid sessionId, int researchId)
        {
            _dataBaseService.DeleteResearch(sessionId, researchId);
        }

        public void SetAlgorithm(Guid sessionId, int reserchId, int algorithmId)
        {
            _dataBaseService.SetAlgorithm(sessionId, reserchId, algorithmId);
        }

        public void SetInputData(Guid sessionId, int reserchId, int inputDataId)
        {
            _dataBaseService.SetInputData(sessionId, reserchId, inputDataId);
        }

        public void StartResearch(Guid sessionId, int reserchId)
        {
            var research = _dataBaseService.GetResearchById(sessionId, reserchId);

            research.Processing();
        }

        public void DeleteInputData(Guid sessionId, int reserchId, int inputDataId)
        {
            _dataBaseService.DeleteInputData(sessionId, reserchId, inputDataId);
        }

        public void UploadInputData(Guid sessionId, string name, byte[] data)
        {
            _dataBaseService.UploadInputData(sessionId, name, data);
        }

        #region Geters;

        public List<Research> GetResearches(Guid sessionId)
        {
            return _dataBaseService.GetResearches(sessionId);
        }

        public Research GetResearchById(Guid sessionId, int researchId)
        {
            return _dataBaseService.GetResearchById(sessionId, researchId);
        }

        public List<Algorithm> GetAlgorithms(Guid sessionId)
        {
            return _dataBaseService.GetAlgorithms(sessionId);
        }

        public Algorithm GetAlgorithmById(Guid sessionId, int algorithmId)
        {
            return _dataBaseService.GetAlgorithmById(sessionId, algorithmId);
        }

        public InputData GetInputDataById(Guid sessionId, int inputDataId)
        {
            return _dataBaseService.GetInputDataById(sessionId, inputDataId);
        }

        public OutputData GetOutputDataById(Guid sessionId, int outputDataId)
        {
            return _dataBaseService.GetOutputDataById(sessionId, outputDataId);
        }

        #endregion
    }
}
