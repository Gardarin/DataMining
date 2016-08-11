using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMiningModel.DataForResearching;

namespace DataMiningModel.Algorithms
{
    public abstract class Algorithm
    {
        public int AlgorithmId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual OutputData ProcessingData(InputData inputData)
        {
            throw new NotImplementedException();
        }
    }
}
