using Microsoft.EntityFrameworkCore;
using ActivityOrganizer.Models;

namespace ActivityOrganizer.Data
{
    public class ActivityContext : DbContext
    {
        public DbSet<SpecialActivity> SpecialActivity { get; set; }
        public ActivityContext(DbContextOptions<ActivityContext> options) : base(options)
        {
        }
    }
}