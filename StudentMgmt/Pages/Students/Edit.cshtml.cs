using Infomax.Models;
using Infomax.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentMgmt.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;
        public Student Student { get; set; }

        public EditModel(IStudentRepository _studentRepository)
        {
            this._studentRepository = _studentRepository;
        }
        public void OnGet(int id)
        {
            Student = _studentRepository.GetStudent(id);

        }
        public IActionResult OnPost(Student Student)
        {
            Student = _studentRepository.Update(Student);
            return RedirectToPage("/Students/Index");
        }
    }
}
