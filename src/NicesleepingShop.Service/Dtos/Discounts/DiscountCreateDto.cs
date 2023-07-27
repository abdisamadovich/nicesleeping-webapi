namespace NicesleepingShop.Service.Dtos.Discounts
{
    public class DiscountCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public short Percentage { get; set; } 
        public  DateTime StartAt { get; set; }
        public  DateTime EndAt { get; set; }
    }
}
