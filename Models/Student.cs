namespace console8ef.Models;
public class Student
{
    public int ID { get; set; }
    public string? LastName { get; set; }
    public string? FirstMidName { get; set; }
    public DateTime EnrollmentDate { get; set; }

    public override string ToString()
    {
        return $"{ID} {LastName} {FirstMidName} {EnrollmentDate}";
    }

}