using BusinessLogic;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ConsoleUserInterface : IUserInterface,IStudentManagement
    {
        private readonly IStudentLogic logic;

        public ConsoleUserInterface(IStudentLogic logic)
        {
            this.logic = logic;
        }
        /// <summary>
        /// Запускает пользовательский интерфейс и обрабатывает команды.
        /// </summary>
        public void Start()
        {
            string command;

            do
            {
                Console.WriteLine("\nВведите команду: 1.Add, 2.Remove, 3.Update, 4.List, 5.Distribution, 6.Exit programm");
                command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        RemoveStudent();
                        break;
                    case "3":
                        UpdateStudent();
                        break;
                    case "4":
                        ListStudents();
                        break;
                    case "5":
                        ShowDistribution();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                }
            } while (command != "exit");
        }
       
        public void AddStudent()
        {
            Console.Write("Введите имя студента: ");
            string name = Console.ReadLine();

            Console.Write("Введите специальность студента: ");
            string speciality = Console.ReadLine();

            Console.Write("Введите группу студента: ");
            string group = Console.ReadLine();

            int numberofstudent = logic.GetAllStudents().Count;

            try { logic.AddStudent(numberofstudent, name, speciality, group); }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
            }
        }

        public void RemoveStudent()
        {
            if (logic.GetAllStudents().Count == 0)
            {
                Console.WriteLine("Список студентов пуст!");
                return;
            }

            Console.Write("Введите номер студента для удаления: \n");
            ListStudents();

            int chosennumber = Convert.ToInt32(Console.ReadLine());

            try { logic.RemoveStudent(chosennumber); }
            catch
            {
                Console.WriteLine("Ошибка!");
                return;
            }
            Console.WriteLine("Студент удален.");
        }

        public void UpdateStudent()
        {
            if (logic.GetAllStudents().Count == 0)
            {
                Console.WriteLine("Список студентов пуст!");
                return;
            }

            Console.WriteLine("Выберите номер студента для изменения:");
            ListStudents();

            if (!int.TryParse(Console.ReadLine(), out int chosenNumber))
            {
                Console.WriteLine("Ошибка! Введите корректный номер студента.");
                return;
            }

            var students = logic.GetAllStudents();
            if (chosenNumber < 0 || chosenNumber > students.Count)
            {
                Console.WriteLine("Ошибка! Студент с таким номером не существует.");
                return;
            }

            Console.Write("Введите новое имя студента (оставьте пустым, чтобы не менять): ");
            string name = Console.ReadLine();

            Console.Write("Введите новую специальность (оставьте пустым, чтобы не менять): ");
            string speciality = Console.ReadLine();

            Console.Write("Введите новую группу (оставьте пустым, чтобы не менять): ");
            string group = Console.ReadLine();

            var currentStudent = logic.GetStudent(chosenNumber);
            name = string.IsNullOrWhiteSpace(name) ? currentStudent[1] : name;
            speciality = string.IsNullOrWhiteSpace(speciality) ? currentStudent[2] : speciality;
            group = string.IsNullOrWhiteSpace(group) ? currentStudent[3] : group;

            try
            {
                logic.UpdateStudent(chosenNumber, name, speciality, group);
                Console.WriteLine("Данные студента обновлены.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обновлении данных студента: {ex.Message}");
            }
        }

        public void ListStudents()
        {
            Console.WriteLine("Список студентов:");
            if (logic.GetAllStudents().Count > 0)
            {
                foreach (var student in logic.GetAllStudents())
                {
                    Console.WriteLine($"ID : {student[0]} Имя: {student[1]}, Специальность: {student[2]}, Группа: {student[3]}");
                }
            }
            else
            {
                Console.WriteLine("Студентов нет");
            }
        }

        public void ShowDistribution()
        {
            try
            {
                var data = logic.GetSpecialityDistribution();
                var chart = new BarChart().Width(60).Label("[green bold]Гистограмма[/]");
                foreach (var entry in data)
                {
                    chart.AddItem(entry.Key, entry.Value, Spectre.Console.Color.Aqua);
                }
                AnsiConsole.Write(chart);
            }
            catch
            {
                Console.WriteLine("Ошибка!");
            }
        }
    }
}
