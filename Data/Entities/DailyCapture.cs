namespace Poultry_management_System.Data.Entities
{
    public class DailyCapture
    {
        public int Id { get; set; }

        // Eggs
        public int LeftoverEggs { get; set; }
        public int UnsoldEggs { get; set; }
        public int DamagedEggs { get; set; }

        public int SoldSixes { get; set; }
        public int SoldTwelves { get; set; }


        // Trays
        public int TotalTrays => SoldTrays + UnsoldTrays;
        public int SoldTrays { get; set; }
        public int UnsoldTrays { get; set; }

        //Prices
        public decimal TraysPrice { get; set; }
        public decimal TwelvesPrice { get; set; }
        public decimal SixesPrice { get; set; }


        //Sales
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }

        public DateTime DateCaptured { get; set; } = DateTime.UtcNow;
    }

}
