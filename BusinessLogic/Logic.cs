using Model;
using DataAccessLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
namespace BusinessLogic
{
    public class Logic : IStudentLogic
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
        
        public void AddStudent(int id, string name, string speciality, string group)
        {
            if (name == string.Empty || speciality == string.Empty || group == string.Empty) { throw new ArgumentException("Одно из полей студента пустое!"); }
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
            if (repository is DapperStudentRepository dapperRepository)
            {
                dapperRepository.ExecuteSQL(@"
                SELECT setval(pg_get_serial_sequence('students', 'id'), 
                (SELECT COALESCE(MAX(id),0) FROM students), false);");
            }
            else if (repository is EFStudentRepository)
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
                    (SELECT COALESCE(MAX(id),0) FROM students), false);
                    ");
                }
            }
            else
            {
                throw new NotSupportedException("Текущий репозиторий не поддерживает сброс последовательности ID.");
            }
        }
    }
}
