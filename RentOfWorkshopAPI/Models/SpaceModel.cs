namespace RentOfWorkshopAPI.Models
{
    public class SpaceModel
    {
        public int Id { get; set; }
        public string TypeOfSpaceName { get; set; }
        public string Address { get; set; }
        public decimal AmountPerHour { get; set; }
        public int Square { get; set; }
        public string StatusId { get; set; }
        public string Description { get; set; }
    }
}
