using BusinessLogic;
using Model;
using Ninject;
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
    public partial class UpdateStudentForm : Form
    {
        private readonly IStudentLogic logic;
        private int id;
        /// <summary>
        /// Конструктор для инициализации UpdateStudentForm
        /// </summary>
        /// <param name="logic">Бизнес логика</param>
        /// <param name="name">Имя студента</param>
        public UpdateStudentForm(IStudentLogic logic, int id)
        {
            InitializeComponent();
            this.logic = logic; // Инициализируем логику через интерфейс
            this.id = id;
        }
        /// <summary>
        /// Метод для обновления данных о студенте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string newName = NameTextBox.Text;
            string newSpeciality = txtSpeciality.Text;
            string newGroup = txtGroup.Text;
            try 
            { 
                logic.UpdateStudent(id, newName, newSpeciality, newGroup);
                MessageBox.Show("Данные студента обновлены.");
                this.Close();
            }
            catch(Exception ex)
            {
            MessageBox.Show($"Ошибка при обновлении данных студента: {ex.Message}");
            }
        }
    }
}
