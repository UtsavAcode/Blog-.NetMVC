using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        //The method below wil call a repository and through the repository we will call a third party API service which is
        //Cloudinary

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            //call the repository
        }
    }
}
