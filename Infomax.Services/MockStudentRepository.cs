using Infomax.Models;

namespace Infomax.Services;
public class MockStudentRepository : IStudentRepository
{
    private List<Student> _studentList;

    public MockStudentRepository()
    {
        _studentList = new List<Student>()
            {
                new Student(){Id=1,Name="Bidhan Psycho",Email="bidhan@gmail.com",Contact="9854569875",Gender=Gender.Male, PhotoPath ="bidhan.jpeg"},
                new Student(){Id=2,Name="Rabindra Psycho",Email="rabindra@gmail.com",Contact="9875457896",Gender=Gender.Other,PhotoPath="rabindra.jpeg"},
                new Student(){Id=2,Name="Rima Psycho",Email="rima@gmail.com",Contact="9875457896",Gender=Gender.Female},

            };
    }
    IEnumerable<Student> IStudentRepository.GetAllStudents()
    {
        return _studentList;
    }
    public Student GetStudent(int id)
    {
        return _studentList.FirstOrDefault(student => student.Id == id);
    }
    public Student Update(Student student)
    {
        Student std = this.GetStudent(student.Id);
        if (std != null)
        {
            std.Name = student.Name;
            std.Email = student.Email;
            std.Gender = student.Gender;
            std.Contact = student.Contact;
            std.PhotoPath = student.PhotoPath;
        }
        return std;
    }
}
