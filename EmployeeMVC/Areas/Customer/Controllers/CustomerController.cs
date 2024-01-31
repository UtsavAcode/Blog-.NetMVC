using EmployeeMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CustomerController : Controller
    {
        public JsonResult Customer()
        {
            Models.Customer customer = new Models.Customer()
            {

                Id = 1,
                Name = "Test",
                Age = 28,
            };

            /* var Json = JsonConvert.SerializeObject(customer);
             return Json("", JsonRequestBehavior.AllowGet);*/

            var jsonResult = Json(customer);
            return Json(jsonResult);
           
        }

       
    }
}
