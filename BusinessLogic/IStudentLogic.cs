using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IStudentLogic
    {
        /// <summary>
        /// Метод получения студента по ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Студент</returns>
        List<string> GetStudent(int id);
        /// <summary>
        /// Добавление студента
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="speciality">Специальность</param>
        /// <param name="group">Группа</param>
        void AddStudent(int id, string name, string speciality, string group);
        /// <summary>
        /// Удаление студента
        /// </summary>
        /// <param name="name">Имя</param>
        void RemoveStudent(int id);
        /// <summary>
        /// Обновление параметров студента.
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="newSpeciality">Новая Специальность</param>
        /// <param name="newGroup">Новая Группа</param>
        void UpdateStudent(int id, string newname, string newSpeciality, string newGroup);
        /// <summary>
        /// Метод возвращающий список всех студентов
        /// </summary>
        /// <returns>Список студентов</returns>
        List<List<string>> GetAllStudents();
        /// <summary>
        /// Метод возвращающий словарь на основе специальностей
        /// </summary>
        /// <returns>Словарь string,int</returns>
        Dictionary<string, int> GetSpecialityDistribution();
    }
}
