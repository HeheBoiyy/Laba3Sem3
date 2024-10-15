using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp
{
    public partial class AddStudentForm : Form
    {
        private Logic logic;
        /// <summary>
        /// Конструктор для инициализации объекта AddStudentForm
        /// </summary>
        /// <param name="logic">Бизнес логика</param>
        public AddStudentForm(Logic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        /// <summary>
        /// Добавляет студента при нажатии соответсвующей кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Аргументы события</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string speciality = txtSpeciality.Text;
            string group = txtGroup.Text;
            int number = logic.GetAllStudents().Count;
            try { logic.AddStudent(number,name, speciality, group); }
            catch
            {
                MessageBox.Show("Ошибка!Одно из полей пустое");
                return;
            }
            MessageBox.Show("Студент добавлен.");
            this.Close();
        }
    }
}
