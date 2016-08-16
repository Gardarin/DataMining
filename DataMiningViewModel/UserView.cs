using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMiningViewModel
{
    class UserView
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public List<int> Researches { get; set; }
        public List<int> UsingAlgoritms { get; set; }
        public List<int> InputDatas { get; set; }
        public List<int> OutputDatas { get; set; }
    }
}
