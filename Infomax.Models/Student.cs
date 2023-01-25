namespace Infomax.Models;

using System.ComponentModel.DataAnnotations;

public class Student
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Student's name is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Student's email is required")]
    [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
    public string Email { get; set; }
    [MinLength(10, ErrorMessage = "Contact must contain at least 10 characters"), MaxLength(15, ErrorMessage = "Name must contain at least 10 characters")]
    public string Contact { get; set; }
    public Gender Gender { get; set; }
    public string PhotoPath { get; set; }
}
