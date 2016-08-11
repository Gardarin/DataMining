using System;
using System.Collections.Generic;

namespace DataMiningModel
{
    public class User
    {
        public  int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Guid SessionId { get; set; }
        public List<Research> Researches { get; set; }
        public List<UsingAlgoritm> UsingAlgoritms { get; set; }
        public List<DataForResearching.InputData> InputDatas { get; set; }
        public List<DataForResearching.OutputData> OutputDatas { get; set; }
    }
}
