namespace ErasmusMate.Models;

public class Course
{
   
    public int Id { get; set; } 

    
    public string? HostCourseName { get; set; } 

    
    public string? HomeCourseName { get; set; } 

    public int Ects { get; set; } 

    public bool IsApproved { get; set; } 
}