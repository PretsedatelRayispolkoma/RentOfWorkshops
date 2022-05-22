namespace RentOfWorkshopAPI.Models
{
    public class SpaceModel
    {
        public int Id { get; set; }
        public int TypeOfSpaceId { get; set; }
        public int HouseId { get; set; }
        public decimal AmountPerHour { get; set; }
        public int Square { get; set; }
        public int StatusId { get; set; }
        public byte[] Picture { get; set; }
        public string Description { get; set; }
    }
}
