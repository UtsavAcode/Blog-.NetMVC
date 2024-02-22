using EmployeeMVC.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        //The method below wil call a repository and through the repository we will call a third party API service which is
        //Cloudinary
        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }


        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            //call the repository

            var imageUrl = await imageRepository.UploadAsync(file);

            if(imageUrl == null)
            {
                return Problem("Something is wrong!!", null, (int)HttpStatusCode.InternalServerError);
            }

            return new JsonResult(new { link = imageUrl });
        }
    }
}
