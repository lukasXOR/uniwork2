using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// At the moment this class just tests the
    /// Grades enumeration names and descriptions
    /// </summary>
    public class StudentGrades
    {
        public string programDesc = "Student Grades";
        public int[] students;
        public void run()
        {
            int numOfStudents = Convert.ToInt32(Console.ReadLine());
            students = new int[numOfStudents];
            for (int i = 0; i < numOfStudents; i++)
            {
                Console.Write("Enter Student #" + (i + 1) + " grade: ");
                students[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < numOfStudents; i++)
            {
                Console.WriteLine("Student #" + (i + 1) + " has mark: " + students[i] + " with grade at " + FindGrade(students[i]));

            }
            Console.WriteLine(FindMark("mean"));
            Console.WriteLine(FindMark("minimum"));
            Console.WriteLine(FindMark("maximum"));
        }
        public int FindMark(string type)
        {
            switch (type)
            {
                case "mean":
                    int mean = 0;

                    foreach (int i in students)
                        mean += i;
                    mean /= students.Length;

                    return mean;

                case "minimum":
                    int minimum = 0;

                    foreach (int i in students)
                        if (i < minimum || minimum == 0)
                            minimum = i;

                    return minimum;

                case "maximum":
                    int maximum = 0;

                    foreach (int i in students)
                        if (i > maximum)
                            maximum = i;

                    return maximum;
            }
            return 0;
        }
        public Grades FindGrade(int grade)
        {
            if (grade <= 39) return Grades.F;
            else if (grade >= 40 && grade < 50) return Grades.D;
            else if (grade >= 50 && grade < 60) return Grades.C;
            else if (grade >= 60 && grade < 70) return Grades.B;
            else if (grade >= 75 && grade < 101) return Grades.A;

            return Grades.F;
        }
    }
}
