using Infomax.Models;
using Infomax.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentMgmt.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentRepository studentRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        public IEnumerable<Student> Students { get; set; }

        [BindProperty]
        public Student ToDeleteStudent { get; set; }

        [TempData]
        public string Message { get; set; }
        //Constructor Dependency Injection
        public IndexModel(IStudentRepository studentRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.studentRepository = studentRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public int DeleteId { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                this.DeleteId = id.Value;
                ToDeleteStudent = studentRepository.GetStudent(id.Value);
                if (ToDeleteStudent == null)
                {
                    return RedirectToPage("/404");
                }
            }
            Students = studentRepository.GetAllStudents();
            return Page();
        }
        public IActionResult OnPost()
        {
            Student DeletedStudent = studentRepository.Delete(ToDeleteStudent.Id);
            string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", DeletedStudent.PhotoPath);
            System.IO.File.Delete(filePath);
            return RedirectToPage("/Students/Index", new
            {
                id = (int?)null,
            });
        }

    }
}
