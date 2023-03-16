using System;
namespace ConsoleAppProject.App03
{
    /// <summary>
    /// At the moment this class just tests the
    /// Grades enumeration names and descriptions
    /// </summary>
    public class StudentGrades
    {
        public string programDescription = "Student Grades";
        public int[] students;
        public string[] menuOptions = { "Output marks", "Output stats", "Output grade profile", "Quit" };
        public void run()
        {
            int numOfStudents = Convert.ToInt32(Utility.CreateOption("Number of students to record: ", "input", new string[0]));
            students = new int[numOfStudents];

            for (int i = 0; i < numOfStudents; i++)
            {
                Console.Write("Enter Student #" + (i + 1) + " grade: ");
                students[i] = Convert.ToInt32(Console.ReadLine());
            }
            while (true)
            {
                Utility.CleanConsole(5);
                double userOption = Utility.CreateOption("Options: ", "menu", menuOptions);
                switch (userOption)
                {
                    case 0:
                        DisplayStudentStats();
                        break;
                    case 1:
                        Console.WriteLine("Mean mark: " + FindMark("mean"));
                        Console.WriteLine("Minimum mark: " + FindMark("minimum"));
                        Console.WriteLine("Maximum mark: " + FindMark("maximum"));
                        break;
                    case 2:
                        DisplayGradeProfile();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;

                }
                Console.Write("Enter to go back to menu");
                Console.ReadLine();
            }
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

            return Grades.A;
        }
        public void DisplayStudentStats()
        {
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine("Student #" + (i + 1) + " has mark: " + students[i] + " with grade at " + FindGrade(students[i]));
            }
        }
        public void DisplayGradeProfile()
        {
            int studentLength = students.Length;
            double gradeA = 0;
            double gradeB = 0;
            double gradeC = 0;
            double gradeD = 0;
            double gradeF = 0;
            for (int i = 0; i < studentLength; i++)
            {
                switch (FindGrade(students[i]))
                {
                    case Grades.A:
                        gradeA++;
                        break;
                    case Grades.B:
                        gradeB++;
                        break;
                    case Grades.C:
                        gradeC++;
                        break;
                    case Grades.D:
                        gradeD++;
                        break;
                    case Grades.F:
                        gradeF++;
                        break;
                }
            }
            Console.WriteLine("Grade A: " + (gradeA / studentLength) * 100 + " %");
            Console.WriteLine("Grade B: " + (gradeB / studentLength) * 100 + " %");
            Console.WriteLine("Grade C: " + (gradeC / studentLength) * 100 + " %");
            Console.WriteLine("Grade D: " + (gradeD / studentLength) * 100 + " %");
            Console.WriteLine("Grade F: " + (gradeF / studentLength) * 100 + " %");
        }
    }
}
