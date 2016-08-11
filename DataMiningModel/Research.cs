using System;

namespace DataMiningModel
{
    public class Research
    {
        public int ResearchId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public State CurentState { get; set; }
        public enum State 
        {
            Created,
            Prepared,
            Processing,
            Completed,
            Crashed
        }
        public Algorithms.Algorithm Algorithm { get; set; }
        public DataForResearching.InputData InputData { get; set; }
        public DataForResearching.OutputData OutputData { get; set; }

        public void Processing()
        {
            if (Algorithm != null)
            {
                throw new NullReferenceException();
            }
            if (InputData != null)
            {
                throw new NullReferenceException();
            }
            CurentState = State.Processing;
            OutputData = Algorithm.ProcessingData(InputData);
            if (OutputData != null)
            {
                CurentState = State.Completed;
                return;
            }
            CurentState = State.Crashed;

            throw new NotImplementedException();
        }

    }
}
