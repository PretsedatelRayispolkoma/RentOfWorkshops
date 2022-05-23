namespace RentOfWorkshopAPI.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
