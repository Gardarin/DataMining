using System;
using System.Collections.Generic;
using System.ServiceModel;
using DataMiningModel;
using DataMiningModel.Algorithms;
using DataMiningModel.DataForResearching;

namespace DataMiningService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDataMiningService" in both code and config file together.
    [ServiceContract]
    public interface IDataMiningService
    {

        [OperationContract]
        void Init(Guid sessionId);

        [OperationContract]
        void CreateResearch(Guid sessionId,string name, string description);

        [OperationContract]
        void DeleteResearch(Guid sessionId, int researchId);

        [OperationContract]
        void SetAlgorithm(Guid sessionId, int reserchId, int algorithmId);

        [OperationContract]
        void SetInputData(Guid sessionId, int reserchId, int inputDataId);

        [OperationContract]
        void StartResearch(Guid sessionId, int reserchId);

        [OperationContract]
        void DeleteInputData(Guid sessionId, int reserchId, int inputDataId);

        [OperationContract]
        void UploadInputData(Guid sessionId, string name, byte[] data);

        #region Geters;
        [OperationContract]
        List<Research> GetResearches(Guid sessionId);

        [OperationContract]
        Research GetResearchById(Guid sessionId,int researchId);

        [OperationContract]
        List<Algorithm> GetAlgorithms(Guid sessionId);

        [OperationContract]
        Algorithm GetAlgorithmById(Guid sessionId, int researchId);

        [OperationContract]
        List<InputData> GetInputDatas(Guid sessionId);

        [OperationContract]
        List<OutputData> GetOutputDatas(Guid sessionId);

        [OperationContract]
        InputData GetInputDataById(Guid sessionId, int inputDataId);

        [OperationContract]
        OutputData GetOutputDataById(Guid sessionId, int outputDataId);
        #endregion

    }
}
