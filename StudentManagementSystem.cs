using System;
using System.Collections.Generic;
using System.Linq;
 
class Student
{
    private string Name;
    private int[] Grades;
 
    public Student(string name, int[] grades)
    {
        Name = name;
        Grades = grades;
    }
 
    public double GetAverage()
    {
        return Grades.Average();
    }
 
    public string GetName()
    {
        return Name;
    }
 
    public int[] GetGrades()
    {
        return Grades;
    }
}
 
class Program
{
    private static List<Student> students = new List<Student>();
 
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("===== STUDENT SYSTEM =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Compute Average Grade");
            Console.WriteLine("4. Find Highest Grade");
            Console.WriteLine("5. Exit");
            Console.WriteLine("==========================");
            Console.WriteLine("Choose an option:");
 
            string choice = Console.ReadLine();
 
            if (choice == "1")
            {
                Console.WriteLine("Enter student name:");
                string name = Console.ReadLine();
 
                Console.WriteLine("Enter grade 1:");
                int grade1 = Convert.ToInt32(Console.ReadLine());
 
                Console.WriteLine("Enter grade 2:");
                int grade2 = Convert.ToInt32(Console.ReadLine());
 
                Console.WriteLine("Enter grade 3:");
                int grade3 = Convert.ToInt32(Console.ReadLine());
 
                students.Add(new Student(name, new int[] { grade1, grade2, grade3 }));
                Console.WriteLine("Student added successfully!");
            }
            else if (choice == "2")
            {
                foreach (var s in students)
                {
                    Console.WriteLine("Name: " + s.GetName());
                    int[] g = s.GetGrades();
                    Console.WriteLine("Grades: " + g[0] + ", " + g[1] + ", " + g[2]);
                    Console.WriteLine("Average: " + s.GetAverage().ToString("F2"));
                }
            }
            else if (choice == "3")
            {
                if (students.Count == 0)
                {
                    Console.WriteLine("No students available.");
                    continue;
                }
 
                double total = 0;
                int count = 0;
 
                foreach (var s in students)
                {
                    total += s.GetGrades().Sum();
                    count += s.GetGrades().Length;
                }
 
                Console.WriteLine("===== CLASS AVERAGE =====");
                Console.WriteLine("Overall Average Grade: " + (total / count).ToString("F2"));
            }
            else if (choice == "4")
            {
                if (students.Count == 0)
                {
                    Console.WriteLine("No students available.");
                    continue;
                }
 
                int highestGrade = students[0].GetGrades()[0];
                string topStudent = students[0].GetName();
 
                foreach (var s in students)
                {
                    int[] g = s.GetGrades();
                    for (int j = 0; j < 3; j++)
                    {
                        if (g[j] > highestGrade)
                        {
                            highestGrade = g[j];
                            topStudent = s.GetName();
                        }
                    }
                }
 
                Console.WriteLine("===== HIGHEST GRADE =====");
                Console.WriteLine("Top Student: " + topStudent);
                Console.WriteLine("Highest Grade: " + highestGrade);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Exiting program...\nGoodbye!");
                break;
            }
        }
    }
}
 
