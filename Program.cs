using System;
using System.Linq;

namespace StudentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entity Framework Code-First Student Database Demo");
            Console.WriteLine("=================================================");

            using (var context = new StudentContext())
            {
                // Ensure database is created
                context.Database.EnsureCreated();
                Console.WriteLine("Database created successfully!");

                // Check if any students exist
                if (!context.Students.Any())
                {
                    // Create a new student
                    var student = new Student
                    {
                        FirstName = "David",
                        LastName = "Smith",
                        Email = "dSmith@email.com",
                        Age = 30,
                        EnrollmentDate = DateTime.Now
                    };

                    // Add student to context
                    context.Students.Add(student);

                    // Save changes to database
                    context.SaveChanges();
                    Console.WriteLine($"Student added: {student.FirstName} {student.LastName}");
                }
                else
                {
                    Console.WriteLine("Students already exist in database.");
                }

                // Display all students
                Console.WriteLine("\nAll Students in Database:");
                Console.WriteLine("------------------------");

                var allStudents = context.Students.ToList();
                foreach (var student in allStudents)
                {
                    Console.WriteLine($"ID: {student.StudentId}");
                    Console.WriteLine($"Name: {student.FirstName} {student.LastName}");
                    Console.WriteLine($"Email: {student.Email}");
                    Console.WriteLine($"Age: {student.Age}");
                    Console.WriteLine($"Enrollment Date: {student.EnrollmentDate:yyyy-MM-dd}");
                    Console.WriteLine("------------------------");
                }

                Console.WriteLine($"\nTotal Students: {allStudents.Count}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}