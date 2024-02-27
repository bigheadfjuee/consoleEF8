

using console8ef.Models;

using (MyContext context = new MyContext())
{
    var aStudent = new Student
    {
        FirstMidName = "John2",
        LastName = "Doe",
        EnrollmentDate = DateTime.Now
    };

    context.Students.Add(aStudent);
    context.SaveChanges();
    Console.WriteLine("新增一筆資料");

    
    var students = context.Students.ToList();
    foreach (var student in students)
    {
        Console.WriteLine(student);
    }
}