using System;
using System.IO;

namespace DataMiningModel.DataForResearching
{
    public abstract class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] DataBytes { get; set; }

        public virtual object GetData()
        {
            throw new NotImplementedException();
        }

        public virtual void SetData(MemoryStream memoryStream)
        {
            throw new NotImplementedException();
        }
    }
}
