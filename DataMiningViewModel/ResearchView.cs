using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMiningViewModel
{
    class ResearchView
    {
        public int ResearchId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CurentState { get; set; }
        public int AlgorithmId { get; set; }
        public int InputId { get; set; }
        public int OutputId { get; set; }
    }
}
