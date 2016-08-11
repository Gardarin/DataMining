using System.Data.Entity;
using DataMiningModel;
using DataMiningModel.Algorithms;
using DataMiningModel.DataForResearching;

namespace StoreService.DbModel
{
    public class DataMiningContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Research> Researches { get; set; }
        public DbSet<Algorithm> Algorithms { get; set; }
        public DbSet<UsingAlgoritm> UsingAlgoritms { get; set; }
        public DbSet<InputData> InputDatas { get; set; }
        public DbSet<OutputData> OutputDatas { get; set; }
    }
}