using InternshipWebApiCounter.Data;
using System.Linq;

namespace InternshipWebApiCounter.Domain
{
    public class CounterRepository
    {
        private readonly InternshipWebApiCounterContext _context;
        public CounterRepository(InternshipWebApiCounterContext context)
        {
            _context = context;
        }

        public (bool, int) GetCounterValue()
        {
            var counter = _context.Counters.FirstOrDefault();

            if (counter == null)
                return (false, 0);

            var counterNumber = counter.CounterNumber;

            return (true, counterNumber);
        }

        public bool IncreaseCounter()
        {
            var counter = _context.Counters.FirstOrDefault();

            if (counter == null)
                return false;

            counter.CounterNumber++;
            _context.SaveChanges();

            return true;
        }
    }
}
