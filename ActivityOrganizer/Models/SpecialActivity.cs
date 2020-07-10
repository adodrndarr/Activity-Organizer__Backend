using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace ActivityOrganizer.Models
{
    public class SpecialActivity
    {
        public int Id { get; set; }                                                       
        
        [Required, Display(Name = "Activity Name"), StringLength(40, MinimumLength = 5), RegularExpression(@"^[A-Z]+[\D ]+$", ErrorMessage = "Sorry, it must begin with a capital letter and contain no numbers :D")]
        public string   ActivityName { get; set; }

        [DisplayFormat(DataFormatString = @"{0: dd dddd, MM MMMM, yyyy}", ApplyFormatInEditMode = false), 
         Display(Name = "Added on date"), DataType(DataType.Date)]
        public DateTime DateAdded    { get; set; }

        [DisplayFormat(DataFormatString = @"{0: dd dddd, MM MMMM, yyyy}", ApplyFormatInEditMode = false), 
         Display(Name = "Should finish on date"), DataType(DataType.Date)]
        public DateTime DateFinish   { get; set; }

        [Required, Display(Name = "Activity Kind"), StringLength(25, MinimumLength = 5), RegularExpression(@"^[A-Z]+[\D ]+$", ErrorMessage = "Sorry, it must begin with a capital letter and contain no numbers :D")]
        public string TypeOfActivity { get; set; }

        [Required, Display(Name = "Activity Priority"), StringLength(25, MinimumLength = 3), RegularExpression(@"^[A-Z]+[\D ]+$", ErrorMessage = "Sorry, it must begin with a capital letter and contain no numbers :D")]
        public string ActivityPriority { get; set; }
    }
}