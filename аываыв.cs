using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Zadanie8_
{
    class Specialty
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        public string StudyForm { get; set; }

        public Specialty() { }

        public Specialty(int key, string name, string faculty, string studyForm)
        {
            Key = key;
            Name = name;
            Faculty = faculty;
            StudyForm = studyForm;
        }
    }

    class Department
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Faculty { get; set; }

        public Department() { }

        public Department(int key, string name, string phone, string faculty)
        {
            Key = key;
            Name = name;
            Phone = phone;
            Faculty = faculty;
        }
    }

    class Discipline
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }
        public int[] Workload { get; set; }

        public Discipline() { }

        public Discipline(int key, string name, int semester, int[] workload)
        {
            Key = key;
            Name = name;
            Semester = semester;
            Workload = workload;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Specialty> specialties = ReadSpecialtiesFromFile("PathToSpecialtyFile.txt");
            List<Department> departments = ReadDepartmentsFromFile("PathToDepartmentFile.txt");
            List<Discipline> disciplines = ReadDisciplinesFromFile("PathToDisciplineFile.txt");

            // Виведення зчитаних даних на консоль
            Console.WriteLine("Спеціальності:");
            foreach (var specialty in specialties)
            {
                Console.WriteLine($"{specialty.Key}: {specialty.Name}, Факультет: {specialty.Faculty}, Форма навчання: {specialty.StudyForm}");
            }

            Console.WriteLine("\nКафедри:");
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.Key}: {department.Name}, Телефон: {department.Phone}, Факультет: {department.Faculty}");
            }

            Console.WriteLine("\nДисципліни:");
            foreach (var discipline in disciplines)
            {
                Console.WriteLine($"{discipline.Key}: {discipline.Name}, Семестр: {discipline.Semester}");
                Console.WriteLine("  Структура годин:");
                for (int i = 0; i < discipline.Workload.Length; i++)
                {
                    Console.WriteLine($"    {discipline.Workload[i]} годин на тиждень (тип {i + 1})");
                }
            }

            // Тут ви можете додати інші запити відповідно до потреб вашого додатка.
        }

        static List<Specialty> ReadSpecialtiesFromFile(string filePath)
        {
            List<Specialty> specialties = new List<Specialty>();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(';');
                        int key = int.Parse(data[0]);
                        string name = data[1];
                        string faculty = data[2];
                        string studyForm = data[3];

                        specialties.Add(new Specialty(key, name, faculty, studyForm));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при зчитуванні файлу {filePath}: {ex.Message}");
            }
            return specialties;
        }

        static List<Department> ReadDepartmentsFromFile(string filePath)
        {
            List<Department> departments = new List<Department>();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(';');
                        int key = int.Parse(data[0]);
                        string name = data[1];
                        string phone = data[2];
                        string faculty = data[3];

                        departments.Add(new Department(key, name, phone, faculty));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при зчитуванні файлу {filePath}: {ex.Message}");
            }
            return departments;
        }

        static List<Discipline> ReadDisciplinesFromFile(string filePath)
        {
            List<Discipline> disciplines = new List<Discipline>();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(';');
                        int key = int.Parse(data[0]);
                        string name = data[1];
                        int semester = int.Parse(data[2]);
                        int[] workload = data.Skip(3).Select(int.Parse).ToArray();

                        disciplines.Add(new Discipline(key, name, semester, workload));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при зчитуванні файлу {filePath}: {ex.Message}");
            }
            return disciplines;
        }
    }
}
