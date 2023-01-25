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
        [BindProperty]
        public Student Student { get; set; }

        [BindProperty]
        public IFormFile? Photo { get; set; }

        [BindProperty]
        public bool Notify { get; set; }

        [TempData]
        public string Message { get; set; }

        public EditModel(IStudentRepository _studentRepository, IWebHostEnvironment webHostEnvironment)
        {
            this._studentRepository = _studentRepository;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Student = _studentRepository.GetStudent(id.Value);
            }
            else
            {
                Student = new Student();
                // Student.PhotoPath cannot be null because it is required
                // We will check if PhotoPath is null later when using post request
                // and show error message if its still "none"
                Student.PhotoPath = "none";
            }
            if (Student == null)
            {
                return RedirectToPage("/404");
            }
            return Page();
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
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
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
                if (Student.Id > 0)
                {
                    Student = _studentRepository.Update(Student);
                }
                else
                {
                    // Check if Student.PhotoPath is still "none"
                    if (Student.PhotoPath == "none")
                    {
                        ModelState.AddModelError(string.Empty, "Please select your photo");
                        return Page();
                    }
                    Student.PhotoPath = ProcessUploadedFile();
                    Student = _studentRepository.Add(Student);
                }
                return RedirectToPage("/Students/Index");
            }
            return Page();
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
