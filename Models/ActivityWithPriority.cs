using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
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
