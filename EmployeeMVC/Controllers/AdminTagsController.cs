using AspNetCoreHero.ToastNotification.Abstractions;
using EmployeeMVC.Data;
using EmployeeMVC.Models.Domain;
using EmployeeMVC.Models.ViewModels;
using EmployeeMVC.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminTagsController : Controller
    {
        private readonly ITagRepository tagRepository;
        private readonly INotyfService notfy;

        public AdminTagsController(ITagRepository tagRepository, INotyfService notfy)
        {
            this.tagRepository = tagRepository;
            this.notfy = notfy;
        }

        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            ValidateAddTagRequest(addTagRequest);
            //Mapping the Models.Domain.Tag entity to AddTagRequest Model
            if (!ModelState.IsValid)
            {
                return View();
            }
            var tag = new Tag()
            {

                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,
            };

            await tagRepository.AddAsync(tag);
            notfy.Success("Tag Added Successfully", 3);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var tag = await tagRepository.GetAllAsync();
            return View(tag);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tag = await tagRepository.GetAsync(id);

            //Checking if the tag is null or not.
            if (tag != null)
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
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
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
            var updatedTag = await tagRepository.UpdateAsync(tag);
            if(updatedTag != null)
            {
                notfy.Success("Update Successful", 3);   
            }

            else
            {
                notfy.Error("Update Failed", 3);
            }
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
            var deletedTag = await tagRepository.DeleteAsync(editTagRequest.Id);

            if(deletedTag != null)
            {
                //success notification
                return RedirectToAction("List");
            }
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

        private void ValidateAddTagRequest(AddTagRequest request)
        {
            if(request.Name !=null && request.DisplayName!=null)
            {
                if(request.Name == request.DisplayName)
                {
                    ModelState.AddModelError("DisplayName", "Name cannot be the same as DisplayName");
                }
            }
        }
    }
}
