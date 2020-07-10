using Microsoft.EntityFrameworkCore;
using ActivityOrganizer.Models;


namespace ActivityOrganizer.Data
{
    public class ActivityContext : DbContext
    {
        public ActivityContext(DbContextOptions<ActivityContext> options)
            : base(options)
        {
        }

        public DbSet<SpecialActivity> SpecialActivity { get; set; }
    }
}
