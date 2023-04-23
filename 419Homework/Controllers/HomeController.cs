using _419Homework.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _419Homework.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=RandomDatabase; Integrated Security=true;";
        public IActionResult Index()
        {
            var vm = new ListingViewModel
            {
                IsLoggedIn = User.Identity.IsAuthenticated
            };
            ListingManager lm = new ListingManager();
            vm.Listings = lm.GetListings();
            return View(vm);
        }

        [Authorize]
        public IActionResult AddNew()
        { 
            UserViewModel vm = new UserViewModel();
            UserRepository repo = new UserRepository(_connectionString);
            User u = repo.GetByName(User.Identity.Name);
            vm.UserId = u.Id;
            vm.UserName = User.Identity.Name;
            return View(vm);
        }

        [HttpPost]

        public IActionResult AddNew(int id, Listing l)
        {
            ListingManager lm = new ListingManager();
            l.DateCreated = DateTime.Now;
            lm.AddNewListing(id, l);
            ListingViewModel vm = new ListingViewModel();
           
            return Redirect("/home/index");

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            ListingManager lm = new ListingManager();
            lm.Delete(id);
            return Redirect("/home/index");
        }
    }
}
