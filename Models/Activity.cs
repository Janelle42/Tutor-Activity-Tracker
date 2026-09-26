using System.ComponentModel.DataAnnotations;

namespace Tutor_Activity_Tracker.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Activity Type is required.")]
        [Display(Name = "Activity Type")]
        public string ActivityType { get; set; } = "";

        [Required(ErrorMessage = "Module is required.")]
        [Display(Name = "Module")]
        public string Module { get; set; } = "";

        [Range(0.5, 24, ErrorMessage = "Time must be between 0.5 and 24 hours.")]
        [Display(Name = "Time (hours)")]
        public double Duration { get; set; }

        [Range(1, 500, ErrorMessage = "Number of Students must be between 1 and 500.")]
        [Display(Name = "Number of Students")]
        public int StudentsReached { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; } = "";
    }
} 