using Microsoft.EntityFrameworkCore;

namespace InternshipWebApiCounter.Data
{
    public class InternshipWebApiCounterContext : DbContext
    {
        public InternshipWebApiCounterContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Counter> Counters { get; set; }
    }
}
