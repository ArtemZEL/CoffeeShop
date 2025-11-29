namespace WebProject.Models
{
    public class CoffeShopViewModel
    {
        public List<CoffeeProductViewModel> CoffeeProducts { get; set; }
        public List<UserCommentViewModel> UserComments { get; set; }

        public HomeCoffeShopViewModel LayoutModelUser { get; set; }

    }
}
