using Infomax.Models;

namespace Infomax.Services;
public interface IStudentRepository
{
    IEnumerable<Student> GetAllStudents();

    public Student GetStudent(int id);

    public Student Update(Student student);

    public Student Delete(int id);

    public Student Add(Student student);
}
