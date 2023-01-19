using Infomax.Models;
using Infomax.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentMgmt.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentRepository studentRepository;
        public IEnumerable<Student> Students { get; set; }

        [TempData]
        public string Message { get; set; }
        //Constructor Dependency Injection
        public IndexModel(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public void OnGet()
        {
            Students = studentRepository.GetAllStudents();
        }
    }
}
