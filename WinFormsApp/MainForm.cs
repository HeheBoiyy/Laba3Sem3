using BusinessLogic;
using System.Diagnostics;
using Ninject;
using Microsoft.VisualBasic.Logging;
namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private IKernel ninjectKernel;
        private readonly IStudentLogic logic;
        /// <summary>
        /// Инициализирует новый экземпляр формы MainForm.
        /// </summary>
        public MainForm()
        {
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            logic = ninjectKernel.Get<IStudentLogic>(); // Получаем интерфейс
            InitializeComponent();
            InitializeListView();
            LoadStudents();
        }
        /// <summary>
        /// Инициализирует ListView для отображения данных студентов.
        /// </summary>
        private void InitializeListView()
        {
            listViewStudents.View = View.Details;
            listViewStudents.FullRowSelect = true;
            listViewStudents.GridLines = true;
            listViewStudents.Columns.Clear();
            listViewStudents.Columns.Add("Номер", 100);
            listViewStudents.Columns.Add("ФИО", 100);
            listViewStudents.Columns.Add("Специальность", 100);
            listViewStudents.Columns.Add("Группа", 100);
        }

        /// <summary>
        /// Загружает список студентов в ListView.
        /// </summary>
        private void LoadStudents()
        {
            listViewStudents.Items.Clear();

            foreach (var student in logic.GetAllStudents())
            {
                var item = new ListViewItem(student[0]);
                item.SubItems.Add(student[1]);
                item.SubItems.Add(student[2]);
                item.SubItems.Add(student[3]);
                listViewStudents.Items.Add(item);
            }
        }
        /// <summary>
        /// Обрабатывает нажатие кнопки добавления студента.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            var addForm = new AddStudentForm(logic);
            addForm.ShowDialog();
            RefreshStudentList();
        }
        /// <summary>
        /// Обрабатывает нажатие кнопки удаления студента.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = listViewStudents.SelectedItems[0];
                int studentId = int.Parse(selectedItem.SubItems[0].Text);
                logic.RemoveStudent(studentId);
                RefreshStudentList();
            }
            catch
            {
                MessageBox.Show("Выберите студента для удаления.");
            }

        }
        /// <summary>
        /// Обрабатывает нажатие кнопки обновления данных студента.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = listViewStudents.SelectedItems[0];
                // Предполагаем, что ID студента хранится в первой колонке ListView
                int studentId = int.Parse(selectedItem.SubItems[0].Text);
                var updateForm = new UpdateStudentForm(logic, studentId);
                updateForm.ShowDialog();
                RefreshStudentList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выборе студента: {ex.Message}");
                return;
            }
        }
        /// <summary>
        /// Обрабатывает нажатие кнопки обновления списка студентов.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnListStudents_Click(object sender, EventArgs e)
        {
            RefreshStudentList();
        }
        /// <summary>
        /// Обрабатывает нажатие кнопки отображения распределения по специальностям.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnShowDistribution_Click(object sender, EventArgs e)
        {
            try { logic.GetSpecialityDistribution(); }
            catch
            {
                MessageBox.Show("Ошибка! Невозможно получить распределение.");
                return;
            }
            var distributionForm = new DistributionForm(logic, logic.GetSpecialityDistribution());
            distributionForm.ShowDialog();
        }
        /// <summary>
        /// Обновляет список студентов в ListView.
        /// </summary>
        private void RefreshStudentList()
        {
            listViewStudents.Items.Clear();

            foreach (var student in logic.GetAllStudents())
            {
                var item = new ListViewItem(student[0]);
                item.SubItems.Add(student[1]);
                item.SubItems.Add(student[2]);
                item.SubItems.Add(student[3]);
                listViewStudents.Items.Add(item);
            }
        }
        /// <summary>
        /// Перенаправляет на сайт сфу при нажатии текста на главной форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = @"https://structure.sfu-kras.ru/ikit", UseShellExecute = true });
        }
        /// <summary>
        /// Обновляет список студентов по нажатию кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateListBtn_Click(object sender, EventArgs e)
        {
            RefreshStudentList();
        }
    }
}
