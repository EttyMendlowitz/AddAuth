namespace _419Homework.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public List<Listing> Listings { get; set; }
    }
}
