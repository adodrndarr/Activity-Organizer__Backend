using System;
using System.Linq;
using ActivityOrganizer.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ActivityOrganizer.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<ActivityContext>>();
            using var context = new ActivityContext(dbContextOptions);

            context.Database.EnsureCreated();

            // If there are any activities in the DB, the seed initializer returns and no activities are added.
            if (context.SpecialActivity.Any())
                return;

            var activities = GetSpecialActivities();

            context.SpecialActivity.AddRange(activities);
            context.SaveChanges();
        }

        private static List<SpecialActivity> GetSpecialActivities()
        {
            return new List<SpecialActivity>
            {
                 new SpecialActivity
                    {
                        ActivityName = "Web Development",
                        DateAdded = DateTime.Parse("2019-10-15"),
                        DateFinish = DateTime.Parse("2020-10-15"),
                        TypeOfActivity = "Development",
                        ActivityPriority = "High"
                    },
                    new SpecialActivity
                    {
                        ActivityName = "Wing Chun Kung fu",
                        DateAdded = DateTime.Parse("2014-10-10"),
                        DateFinish = DateTime.Parse("2100-01-01"),
                        TypeOfActivity = "Training",
                        ActivityPriority = "Medium++"
                    },
                    new SpecialActivity
                    {
                        ActivityName = "Exponential Business",
                        DateAdded = DateTime.Parse("2019-10-20"),
                        DateFinish = DateTime.Parse("2100-01-01"),
                        TypeOfActivity = "Business",
                        ActivityPriority = "Low"
                    },
                    new SpecialActivity
                    {
                        ActivityName = "Travelling",
                        DateAdded = DateTime.Parse("2020-04-17"),
                        DateFinish = DateTime.Parse("2100-01-01"),
                        TypeOfActivity = "Travel",
                        ActivityPriority = "Low"
                    }
            };
        }
    }
}
