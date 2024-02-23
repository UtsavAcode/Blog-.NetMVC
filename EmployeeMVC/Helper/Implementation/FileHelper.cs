using EmployeeMVC.Helper.Interface;

namespace EmployeeMVC.Helper.Implementation
{
    public class FileHelper : IFileHelper
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string? SaveFileAndReturnName(string path, IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    string uniqueName = Guid.NewGuid().ToString() + file.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, Path.Combine(path, uniqueName));
                    file.CopyTo(new FileStream(serverFolder, FileMode.Create));
                    return uniqueName;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
        }
        public bool Delete(string path, string filename)
        {
            try
            {
                if (filename != null)
                {
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, path);
                    if (File.Exists(Path.Combine(filePath, filename)))
                    {
                        File.Delete(Path.Combine(filePath, filename));
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
        }
    }

}
