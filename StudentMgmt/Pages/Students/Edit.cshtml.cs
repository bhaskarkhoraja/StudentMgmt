using Infomax.Models;
using Infomax.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentMgmt.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        public Student Student { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public bool Notify { get; set; }

        [TempData]
        public string Message { get; set; }

        public EditModel(IStudentRepository _studentRepository, IWebHostEnvironment webHostEnvironment)
        {
            this._studentRepository = _studentRepository;
            this.webHostEnvironment = webHostEnvironment;
        }
        public void OnGet(int id)
        {
            Student = _studentRepository.GetStudent(id);

        }
        public IActionResult OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Message = "Thank you for turning on notifications";
            }
            else
            {
                Message = "You have turned off email notifications";
            }

            TempData["message"] = Message;
            return RedirectToPage("/Students/Index");
        }
        public IActionResult OnPost(Student Student)
        {
            if (Photo != null)
            {
                // If a new photo is uploaded, the existing photo must be
                // deleted. So check if there is an existing photo and delete
                if (Student.PhotoPath != null)
                {
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath,
                        "images", Student.PhotoPath);
                    System.IO.File.Delete(filePath);
                }
                // Save the new photo in wwwroot/images folder and update
                // PhotoPath property of the Student object
                Student.PhotoPath = ProcessUploadedFile();
            }
            Student = _studentRepository.Update(Student);
            return RedirectToPage("/Students/Index");
        }
        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                // uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                uniqueFileName = Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
