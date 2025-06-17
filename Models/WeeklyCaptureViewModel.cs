using System.ComponentModel.DataAnnotations;

namespace Poultry_management_System.Models
{
    public class WeeklyCaptureViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Total Feed")]
        public int TotalFeed { get; set; }

        [Display(Name = "Total Chickens")]
        public int TotalChickens { get; set; }

        [Display(Name = "Total Units(Electriciy)")]
        public decimal TotalUnits { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Captured")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCaptured { get; set; } = DateTime.Now;
    }
}
