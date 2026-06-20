using System;
using System.Collections.Generic;
using System.Linq;
 
List<string> names = new List<string>();
List<int[]> grades = new List<int[]>();
 
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
 
        names.Add(name);
        grades.Add(new int[] { grade1, grade2, grade3 });
 
        Console.WriteLine("Student added successfully!");
    }
    else if (choice == "2")
    {
        for (int i = 0; i < names.Count; i++)
        {
            double average = grades[i].Average();
 
            Console.WriteLine("Name: " + names[i]);
            Console.WriteLine("Grades: " + grades[i][0] + ", " + grades[i][1] + ", " + grades[i][2]);
            Console.WriteLine("Average: " + average.ToString("F2"));
        }
    }
    else if (choice == "3")
    {
        double total = 0;
        int count = 0;
 
        for (int i = 0; i < grades.Count; i++)
        {
            total += grades[i][0] + grades[i][1] + grades[i][2];
            count += 3;
        }
 
        Console.WriteLine("===== CLASS AVERAGE =====");
        Console.WriteLine("Overall Average Grade: " + (total / count).ToString("F2"));
    }
    else if (choice == "4")
    {
        int highestGrade = grades[0][0];
        string topStudent = names[0];
 
        for (int i = 0; i < names.Count; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (grades[i][j] > highestGrade)
                {
                    highestGrade = grades[i][j];
                    topStudent = names[i];
                }
            }
        }
 
        Console.WriteLine("===== HIGHEST GRADE =====");
        Console.WriteLine("Top Student: " + topStudent);
        Console.WriteLine("Highest Grade: " + highestGrade);
    }
    else if (choice == "5")
    {
        Console.WriteLine("Exiting program...");
        Console.WriteLine("Goodbye!");
        break;
    }
}
 
