namespace Poultry_management_System.Data.Entities
{
    public class DefaultPrices
    {
        public int Id { get; set; } // always 1
        public decimal TrayPrice { get; set; }
        public decimal TwelvesPrice { get; set; }
        public decimal SixesPrice { get; set; }
    }
}
