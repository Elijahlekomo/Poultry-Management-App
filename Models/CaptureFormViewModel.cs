using System.ComponentModel.DataAnnotations;

namespace Poultry_management_System.Models
{
    public class CaptureFormViewModel
    {
        public int Id { get; set; }
        //Eggs
        [Required]
        [Display(Name = "Left Over Eggs")]
        public int LeftOverEggs { get; set; }

        [Required]
        [Display(Name = "Damaged Eggs")]
        public int DamagedEggs { get; set; }

        [Required]
        [Display(Name = "Unsold Eggs")]
        public int UnsoldEggs { get; set; }

        [Required]
        [Display(Name = "Sold 6's")]
        public int SoldSixes { get; set; }

        [Required]
        [Display(Name = "Sold 12's")]
        public int SoldTwelves { get; set; }

        //Trays
        [Required]
        [Display(Name = "Total Trays")]
        public int TotalTrays => SoldTrays + UnsoldTrays;

        [Required]
        [Display(Name = "Sold Trays")]
        public int SoldTrays { get; set; }

        [Required]
        [Display(Name = "Unsold Trays")]
        public int UnsoldTrays { get; set; }

        //Prices
        [Required]
        [Display(Name = "Tray Price")]
        [DataType(DataType.Currency)]
        public decimal TrayPrice { get; set; }

        [Required]
        [Display(Name = "12's Price")]
        [DataType(DataType.Currency)]
        public decimal TwelvesPrice { get; set; }

        [Required]
        [Display(Name = "6's Price")]
        [DataType(DataType.Currency)]
        public decimal SixesPrice { get; set; }

        //Sales
        [Required]
        [Display(Name = "Sales Amount")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Total Amount")]
        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Captured")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCaptured { get; set; } = DateTime.Now;
    }
}