using EmployeeMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Controllers
{
    public class EntryController : DbContext
    {

        public EntryController(ApplicationDbContext) { }
    }
}
