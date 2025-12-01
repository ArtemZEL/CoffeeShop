
namespace WebProject.Service.Flie
{
    public interface IProfileFileService
    {
        void ReplaceToAvatarToDefault(int userId);
        void UploadAvatar(IFormFile file);
    }
}