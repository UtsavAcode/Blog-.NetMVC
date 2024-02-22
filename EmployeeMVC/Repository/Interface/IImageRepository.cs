namespace EmployeeMVC.Repository.Interface
{
    public interface IImageRepository
    {
        //Upload the image
        //We wil get the URL of the cloud URL that where we are hosting our image.
        //We will return this URL to the controller and back to the web page.
        Task<string> UploadAsync(IFormFile file);
    }
}
