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
            //Mapping the Models.Domain.Tag entity to AddTagRequest Model

            var tag = new Tag()
            {

                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,
            };

            _applicationDbContext.Tags.Add(tag);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult List()
        {
            var tag = _applicationDbContext.Tags.ToList();
            return View(tag);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var tag = _applicationDbContext.Tags.FirstOrDefault(x => x.Id == id);

            //Checking if the tag is null or not.
           if(tag != null)
            {
                var editTagRequest = new EditTagRequest()
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName,

                };

                return View(editTagRequest);
            }

            return View(null);
        }

        [HttpPost]
        public IActionResult Edit(EditTagRequest editTagRequest)
        {
            //The EditTagRequest must be changed to the Tag Domain model.
            //this is because of the entity framework only deals with main domain and not the view Model because
            //The MainDomain deals with the database.
            var tag = new Tag()
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName,
            };

            //Finding and storing the required tag into variable the existingTag.
            var existingTag = _applicationDbContext.Tags.Find(tag.Id);

            if (existingTag !=null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                _applicationDbContext.SaveChanges();
                return RedirectToAction("Edit", new { id = editTagRequest.Id });
            }
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

        [HttpPost]
        public IActionResult Delete(EditTagRequest editTagRequest)
        {
            var tag = _applicationDbContext.Tags.Find(editTagRequest.Id);

            if (tag !=null)
            {
                _applicationDbContext.Tags.Remove(tag);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new {id = editTagRequest.Id});
        }
    }
}
