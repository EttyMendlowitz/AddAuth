namespace _419Homework.Models
{
    public class ListingViewModel
    {
        public List<Listing> Listings { get; set; }
        public List<int> Ids { get; set; }

        public bool IsLoggedIn { get; set; }
    }
}
