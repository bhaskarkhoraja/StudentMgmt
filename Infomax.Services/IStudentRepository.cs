using Infomax.Models;

namespace Infomax.Services;
public interface IStudentRepository
{
    IEnumerable<Student> GetAllStudents();

    public Student GetStudent(int id);
}
