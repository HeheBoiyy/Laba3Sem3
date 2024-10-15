using BusinessLogic;
using System.Drawing;
using Spectre.Console;
using System.Collections.Generic;
using Ninject;
namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            Logic logic = ninjectKernel.Get<Logic>();
            string command;

            do
            {
                Console.WriteLine("\nВведите команду: 1.Add, 2.Remove, 3.Update, 4.List, 5.Distribution, 6.Exit programm");
                command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "1":
                        AddStudent(logic);
                        break;
                    case "2":
                        RemoveStudent(logic);
                        break;
                    case "3":
                        UpdateStudent(logic);
                        break;
                    case "4":
                        ListStudents(logic);
                        break;
                    case "5":
                        try { var testdata = logic.GetSpecialityDistribution(); }
                        catch
                        {
                            Console.WriteLine("Ошибка!");
                            break;
                        }
                        var data = logic.GetSpecialityDistribution();
                        ShowDistribution(data);
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                }
            } while (command != "exit");
        }
        // все функции изложенные ниже НЕ являются логикой и просто делают код красивее.
        /// <summary>
        /// Функция для добавления студента через КОНСОЛЬ(QoL функция)
        /// </summary>
        /// <param name="logic">Бизнес логика</param>
        static void AddStudent(Logic logic)
        {
            Console.Write("Введите имя студента: ");
            string name = Console.ReadLine();

            Console.Write("Введите специальность студента: ");
            string speciality = Console.ReadLine();

            Console.Write("Введите группу студента: ");
            string group = Console.ReadLine();

            int numberofstudent = logic.GetAllStudents().Count();

            try { logic.AddStudent(numberofstudent, name, speciality, group); }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
            }
            
        }
        /// <summary>
        /// Функция для удаления студента через КОНСОЛЬ(QoL функция)
        /// </summary>
        /// <param name="logic">Бизнес логика</param>
        static void RemoveStudent(Logic logic)
        {
            if (logic.GetAllStudents().Count==0)
            {
                Console.WriteLine("Список студентов пуст!");
                return;
            }
            else
            {
                Console.Write("Введите номер студента для удаления: \n");
                foreach (var student in logic.GetAllStudents())
                {
                    Console.WriteLine($"Номер {student[0]}, Имя:{student[1]} Специальность:{student[2]} Группа:{student[3]}");
                }
                int chosennumber = Convert.ToInt32(Console.ReadLine());

                try { logic.RemoveStudent(chosennumber); }
                catch
                {
                    Console.WriteLine("Ошибка!");
                    return;
                }
                Console.WriteLine("Студент удален.");
            }
        }
        /// <summary>
        /// Функция для обновления студента через КОНСОЛЬ(QoL функция)
        /// </summary>
        /// <param name="logic">Бизнес логика</param>
        static void UpdateStudent(Logic logic)
        {
            if (logic.GetAllStudents().Count == 0)
            {
                Console.WriteLine("Список студентов пуст!");
                return;
            }

            Console.WriteLine("Выберите номер студента для изменения:");
            ListStudents(logic);

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
        /// <summary>
        /// Функция для получения списка студентов через КОНСОЛЬ(QoL функция)
        /// </summary>
        /// <param name="logic">Бизнес логика</param>
        static void ListStudents(Logic logic)
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
        /// <summary>
        /// Функция для вывода гистраграммы через КОНСОЛЬ(не QoL функция)
        /// </summary>
        /// <param name="logic">Бизнес логика</param>
        static void ShowDistribution(Dictionary<string,int> data)
        {
            
            var chart = new BarChart().Width(60).Label("[green bold]Гистограмма[/]");
            foreach (var entry in data)
            {
                chart.AddItem(entry.Key, entry.Value,Spectre.Console.Color.Aqua);
            }

            AnsiConsole.Write(chart);
        }

    }
}
