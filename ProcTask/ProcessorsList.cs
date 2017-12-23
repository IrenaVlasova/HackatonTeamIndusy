using System.Collections.Generic;

namespace ProcTask
{
    public class ProcessorsList
    {
        private List<Processor> _list = new List<Processor>();

        public void AddProcessor(Processor pr)
        {
            _list.Add(pr);
        }

        public List<Processor> GetProcessors()
        {
            return _list;
        }
    }
}