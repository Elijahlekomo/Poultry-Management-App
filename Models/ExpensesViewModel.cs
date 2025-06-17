using System.ComponentModel.DataAnnotations;

namespace Poultry_management_System.Models
{
    public class ExpensesViewModel
    {
        public int Id { get; set; }
        //Feed       
        [Required]
        [Display(Name = "Starter Feed (bags)")]
        public int StarterFeed { get; set; }

        [Required]
        [Display(Name = "Grower Feed (bags)")]
        public int GrowerFeed { get; set; }

        [Required]
        [Display(Name = "Layer Feed (bags)")]
        public int LayerFeed { get; set; }

        [Required]
        [Display(Name = "Total Feeds (bags)")]
        public int TotalFeeds => GrowerFeed + StarterFeed + GrowerFeed;


        //Chickens        
        [Display(Name = "Total Chickens")]
        public int TotalChickens { get; set; }

        [Display(Name = "Total Chicks")]
        public int TotalChicks { get; set; }

        [Display(Name = "Death Report(Total)")]
        public int ChickensDied => StarterDied + LayersDied;

        [Display(Name = "Death Report(Starter)")]
        public int StarterDied { get; set; }

        [Display(Name = "Death Report(Layers)")]
        public int LayersDied { get; set; }

        //Others
        [Display(Name = "Total Units(Electriciy)")]
        public decimal TotalUnits => House1Electricity + House2Electricity;

        [Display(Name = "Daily Usage(Electricity-H1)")]
        [DataType(DataType.Currency)]
        public decimal House1Electricity { get; set; }

        [Required]
        [Display(Name = "Daily Usage(Electricity-H2)")]
        [DataType(DataType.Currency)]
        public decimal House2Electricity { get; set; }

        [Required]
        [Display(Name = "Water Cost")]
        public decimal WaterCost { get; set; }

        [Required]
        [Display(Name = "Sales Transport (Town)")]
        [DataType(DataType.Currency)]

        public decimal TownTransport { get; set; }

        [Display(Name = "Town Lunch")]
        public decimal TownLunch { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Captured")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCaptured { get; set; } = DateTime.Now;
    }
}
