namespace Poultry_management_System.Models
{
    public class DashboardViewModel
    {
        public DateTime Date { get; set; }

        // Monthly Overview
        public decimal TotalMonthlyProfit { get; set; }
        public decimal TotalMonthlyIncome { get; set; }
        public decimal TotalMonthlyExpense { get; set; }

        // Daily Overview
        public decimal TotalDailyProfit { get; set; }
        public decimal TotalDailyIncome { get; set; }
        public decimal TotalDailyExpense { get; set; }

        // Daily Operations Summary
        public int TotalTrays { get; set; }
        public int SoldTrays { get; set; }
        public int LeftoverEggs { get; set; }
        public int DamagedEggs { get; set; }
        public int DeathReport { get; set; }
        public int TotalFeedUsed { get; set; }

        // Stock
        public int TotalChickens { get; set; }
        public int TotalFeedStock { get; set; }
    }

}
