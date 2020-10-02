using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ActivityOrganizer.Models
{
    public class ActivityWithPriority
    {
        public List<SpecialActivity> Activities { get; set; }

        public SelectList Priorities { get; set; }

        public string Priority { get; set; }
    }
}
