namespace EmployeeMVC.Helper.Interface
{
    public interface IFileHelper
    {
        public string? SaveFileAndReturnName(string path, IFormFile file);
        public bool Delete(string path, string filename);
        

    }
}
