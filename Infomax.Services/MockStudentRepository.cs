using Infomax.Models;

namespace Infomax.Services;
public class MockStudentRepository : IStudentRepository
{
    private List<Student> _studentList;

    public MockStudentRepository()
    {
        _studentList = new List<Student>()
            {
                new Student(){Id=1,Name="Bidhan Psycho",Email="bidhan@gmail.com",Contact="9854569875",Gender=Gender.Male},
                new Student(){Id=2,Name="Rabindra Psycho",Email="rabindra@gmail.com",Contact="9875457896",Gender=Gender.Male}
            };
    }
    IEnumerable<Student> IStudentRepository.GetAllStudents()
    {
        return _studentList;
    }
}
