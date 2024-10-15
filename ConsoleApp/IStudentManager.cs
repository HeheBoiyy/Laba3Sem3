using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public interface IStudentManagement
    {
        /// <summary>
        /// Добавляет нового студента на основе введенных данных.
        /// </summary>
        public void AddStudent();
        /// <summary>
        /// Удаляет студента на основе введенного номера.
        /// </summary>
        public void RemoveStudent();
        /// <summary>
        /// Обновляет данные студента на основе введенного номера.
        /// </summary>
        public void UpdateStudent();
        /// <summary>
        /// Отображает список всех студентов.
        /// </summary>
        public void ListStudents();
        /// <summary>
        /// Показывает распределение студентов по специальностям в виде гистограммы.
        /// </summary>
        public void ShowDistribution();
    }
}
