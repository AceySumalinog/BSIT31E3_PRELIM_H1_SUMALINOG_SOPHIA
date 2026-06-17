using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem
{
    class Program
    {
        
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            int choice;

            do
            {
                
                Console.WriteLine("\n===== STUDENT MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Add New Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Calculate Individual Student Average");
                Console.WriteLine("4. Calculate Class Average");
                Console.WriteLine("5. Show Top Student & Highest Grade");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                
                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        ViewAllStudents();
                        break;
                    case 3:
                        GetStudentAverage();
                        break;
                    case 4:
                        GetClassAverage();
                        break;
                    case 5:
                        GetTopStudent();
                        break;
                    case 6:
                        Console.WriteLine("Exiting program... Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please select between 1 and 6.");
                        break;
                }

            } while (choice != 6);
        }

        
        static void AddStudent()
        {
            Console.Write("\nEnter student name: ");
            string name = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty!");
                return;
            }

            Console.Write("Enter number of grades: ");
            if (!int.TryParse(Console.ReadLine(), out int numGrades) || numGrades <= 0)
            {
                Console.WriteLine("Please enter a valid positive number.");
                return;
            }

            List<double> grades = new List<double>();
            for (int i = 0; i < numGrades; i++)
            {
                Console.Write($"Enter grade {i + 1}: ");
                if (double.TryParse(Console.ReadLine(), out double grade) && grade >= 0 && grade <= 100)
                {
                    grades.Add(grade);
                }
                else
                {
                    Console.WriteLine("Invalid grade! Must be between 0 and 100. Try again.");
                    i--; 
                }
            }

            students.Add(new Student { Name = name, Grades = grades });
            Console.WriteLine("Student added successfully!");
        }

        
        static void ViewAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("\nNo student records found.");
                return;
            }

            Console.WriteLine("\n--- All Students ---");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Name: {students[i].Name} | Grades: {string.Join(", ", students[i].Grades)}");
            }
        }

        
        static void GetStudentAverage()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("\nNo students available.");
                return;
            }

            Console.Write("\nEnter student name: ");
            string name = Console.ReadLine().Trim();
            Student student = students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            double average = student.Grades.Average();
            Console.WriteLine($"Average grade for {student.Name}: {average:F2}");
        }

        
        static void GetClassAverage()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("\nNo students available.");
                return;
            }

            double allGradesTotal = 0;
            int gradeCount = 0;

            foreach (var student in students)
            {
                allGradesTotal += student.Grades.Sum();
                gradeCount += student.Grades.Count;
            }

            double classAverage = allGradesTotal / gradeCount;
            Console.WriteLine($"\nClass Average: {classAverage:F2}");
        }

        
        static void GetTopStudent()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("\nNo students available.");
                return;
            }

            Student topStudent = null;
            double highestAverage = 0;

            foreach (var student in students)
            {
                double avg = student.Grades.Average();
                if (avg > highestAverage)
                {
                    highestAverage = avg;
                    topStudent = student;
                }
            }

            Console.WriteLine($"\nTop Student: {topStudent.Name}");
            Console.WriteLine($"Highest Average Grade: {highestAverage:F2}");
            Console.WriteLine($"All Grades: {string.Join(", ", topStudent.Grades)}");
        }
    }

    
    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }
    }
}
