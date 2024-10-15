using Model;
using DataAccessLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
namespace BusinessLogic
{
    public class Logic
    {
        private readonly IRepository<Student> repository;
        public Logic(IRepository<Student> repository)
        {
            this.repository = repository;
        }
        /// <summary>
        /// Создание DB Context (только для EF Framework)
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private AppDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(connectionString);
            return new AppDbContext(optionsBuilder.Options);
        }
        /// <summary>
        /// Метод получения студента по ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Студент</returns>
        public List<string> GetStudent(int id)
        {
            var student = repository.Get(id);
            if (student == null)
            {
                throw new ArgumentException("Студент с указанным ID не найден");
            }
            return new List<string>
            {
                student.Id.ToString(),
                student.Name,
                student.Speciality,
                student.Group
            };
        }
        /// <summary>
        /// Добавление студента
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="speciality">Специальность</param>
        /// <param name="group">Группа</param>
        public void AddStudent(int id,string name, string speciality, string group)
        {
            if (name == string.Empty|| speciality == string.Empty || group == string.Empty) { throw new ArgumentException("Одно из полей студента пустое!"); }
            else
            {
                Student student = new Student()
                {
                    Name = name,
                    Speciality = speciality,
                    Group = group
                };
                repository.Create(student);
            }
        }
        /// <summary>
        /// Удаление студента
        /// </summary>
        /// <param name="name">Имя</param>
        public void RemoveStudent(int id)
        {
            var student = repository.Get(id);
            if (student == null)
            {
                throw new ArgumentException("Студент с указанным ID не найден");
            }
            repository.Delete(id);
            if (repository.GetAll().Count() == 0)
            {
                ResetStudentIdSequence();
            }
        }
        /// <summary>
        /// Обновление параметров студента.
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="newSpeciality">Новая Специальность</param>
        /// <param name="newGroup">Новая Группа</param>
        public void UpdateStudent(int id, string newname, string newSpeciality, string newGroup)
        {
            var student = repository.Get(id);
            if (student == null)
            {
                throw new ArgumentException("Студент с указанным ID не найден");
            }

            if (!string.IsNullOrEmpty(newname))
            {
                student.Name = newname;
            }
            if (!string.IsNullOrEmpty(newSpeciality))
            {
                student.Speciality = newSpeciality;
            }
            if (!string.IsNullOrEmpty(newGroup))
            {
                student.Group = newGroup;
            }

            repository.Update(student);
        }
        /// <summary>
        /// Метод возвращающий список всех студентов
        /// </summary>
        /// <returns>Список студентов</returns>
        public List<List<string>> GetAllStudents()
        {
            var students = repository.GetAll();
            return students.Select(student => new List<string>
            {
                student.Id.ToString(),
                student.Name,
                student.Speciality,
                student.Group
            }).ToList();
        }
        /// <summary>
        /// Метод возвращающий словарь на основе специальностей
        /// </summary>
        /// <returns>Словарь string,int</returns>
        public Dictionary<string, int> GetSpecialityDistribution()
        {
            var students = repository.GetAll();
            if (!students.Any())
            {
                throw new InvalidOperationException("Нет данных о студентах");
            }

            return students.GroupBy(s => s.Speciality)
                           .ToDictionary(g => g.Key, g => g.Count());
        }
        /// <summary>
        /// Метод сброса порядкового номера ID
        /// </summary>
        public void ResetStudentIdSequence()
        {
            if (repository is DapperRepository<Student> dapperRepository)
            {
                dapperRepository.ExecuteSQL(@"
                SELECT setval(pg_get_serial_sequence('students', 'id'), 
                (SELECT COALESCE(MAX(id),0) FROM students), false);");
            }
            else if (repository is EFRepository<Student>)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");

                using (var context = CreateDbContext(connectionString))
                {
                    context.Database.ExecuteSqlRaw(@"
                    SELECT setval(pg_get_serial_sequence('students', 'id'), 
                    (SELECT COALESCE(MAX(id),0) FROM students), false);");
                }
            }
            else
            {
                throw new NotSupportedException("Текущий репозиторий не поддерживает сброс последовательности ID.");
            }
        }
    }
}
