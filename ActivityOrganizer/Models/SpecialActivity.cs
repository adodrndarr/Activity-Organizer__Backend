using System.ComponentModel.DataAnnotations;
using System;

namespace ActivityOrganizer.Models
{
    public class SpecialActivity
    {
        const string LETTERS_ONLY_WITH_CAPITAL_REGEX = @"^[A-Z]+[\D ]+$"; // Ex: matches Abc, but not abc or Abc12
        const string FORMAT_DATE_FULL_DAY_MONTH_NAMES = @"{0: dd dddd, MM MMMM, yyyy}"; // Ex: 26 Tuesday, 10 October, 2019
        const string MESSAGE_LETTERS_ONLY_CAPITAL = "Sorry, it must begin with a capital letter and contain no numbers :D";

        public int Id { get; set; }

        [Required,
         Display(Name = "Activity Name"),
         StringLength(40, MinimumLength = 5),
         RegularExpression(LETTERS_ONLY_WITH_CAPITAL_REGEX, ErrorMessage = MESSAGE_LETTERS_ONLY_CAPITAL)
        ]
        public string ActivityName { get; set; }

        [DisplayFormat(DataFormatString = FORMAT_DATE_FULL_DAY_MONTH_NAMES, ApplyFormatInEditMode = false), 
         Display(Name = "Added on date"), DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [DisplayFormat(DataFormatString = FORMAT_DATE_FULL_DAY_MONTH_NAMES, ApplyFormatInEditMode = false), 
         Display(Name = "Should finish on date"), DataType(DataType.Date)]
        public DateTime DateFinish { get; set; }

        [Required, 
         Display(Name = "Activity Kind"), 
         StringLength(25, MinimumLength = 5), 
         RegularExpression(LETTERS_ONLY_WITH_CAPITAL_REGEX, ErrorMessage = MESSAGE_LETTERS_ONLY_CAPITAL)
        ]
        public string TypeOfActivity { get; set; }

        [Required, 
         Display(Name = "Activity Priority"), 
         StringLength(25, MinimumLength = 3), 
         RegularExpression(LETTERS_ONLY_WITH_CAPITAL_REGEX, ErrorMessage = MESSAGE_LETTERS_ONLY_CAPITAL)
        ]
        public string ActivityPriority { get; set; }
    }
}
