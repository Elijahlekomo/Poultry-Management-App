namespace Poultry_management_System.Data.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        // Feeds
        public int GrowerFeed { get; set; }
        public int LayerFeed { get; set; }
        public int StarterFeed { get; set; }
        public int TotalFeeds => GrowerFeed + LayerFeed + StarterFeed;

        // Chickens
        public int TotalChickens { get; set; }

        public int TotalChicks { get; set; }
        public int ChickensDied => StarterDied + LayersDied;


        public int StarterDied { get; set; }
        public int LayersDied { get; set; }


        // Other
        public decimal TotalUnits => ElectricityHouse1 + ElectricityHouse2;

        public decimal ElectricityHouse1 { get; set; }
        public decimal ElectricityHouse2 { get; set; }
        public decimal WaterCost { get; set; }

        public decimal TownTransport { get; set; }

        public decimal TownLunch { get; set; }

        public DateTime DateCaptured { get; set; }
    }
}
