using EmployeeMVC.Data;
using EmployeeMVC.Models.Domain;
using EmployeeMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AdminTagsController( ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            //Mappint the Models.Domain.Tag entity to AddTagRequest Model

            var tag = new Tag()
            {

                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,
            };

            _applicationDbContext.Tags.Add(tag);
            return View("Add");
        }
    }
}
