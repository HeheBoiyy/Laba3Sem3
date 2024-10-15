using BusinessLogic;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsApp
{
    public partial class DistributionForm : Form
    {
        private readonly IStudentLogic logic;
        private IKernel ninjectkernel;
        /// <summary>
        /// Конструктор для инициализации объекта DistributionForm
        /// </summary>
        /// <param name="logic">Бизнес логика</param>
        /// <param name="specialityCounts">Словарь</param>
        public DistributionForm(IStudentLogic logic, Dictionary<string, int> specialityCounts)
        {
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            logic = ninjectKernel.Get<Logic>();
            InitializeComponent();
            LoadChart(specialityCounts);
        }
        /// <summary>
        /// Создание и загрузка гистаграммы
        /// </summary>
        /// <param name="specialityCounts">Словарь</param>
        private void LoadChart(Dictionary<string, int> specialityCounts)
        {
            chartSpeciality.Series.Clear();

            foreach (var speciality in specialityCounts)
            {
                Series series = chartSpeciality.Series.Add(speciality.Key);
                series.Points.Add(speciality.Value);
            }

            chartSpeciality.ChartAreas[0].AxisX.Title = "Специальность";
            chartSpeciality.ChartAreas[0].AxisY.Title = "Количество студентов";
            chartSpeciality.ChartAreas[0].AxisX.Interval = 1; 
            chartSpeciality.ChartAreas[0].AxisY.Interval = 1;
        }

    }
}
