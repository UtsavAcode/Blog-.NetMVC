using EmployeeMVC.Repository.Interface;

namespace EmployeeMVC.Repository.Implimentation
{
    public class CloudinaryImageRepository : IImageRepository
    {
        public Task<string> UploadAsync(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
