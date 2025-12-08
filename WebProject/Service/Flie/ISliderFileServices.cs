
namespace WebProject.Service.Flie
{
    public interface ISliderFileServices
    {
        List<string> GetFonGallery();
        void RemoveImageSlider(string fileName);
        void UploudFonCoffeShop(IFormFile file);
    }
}