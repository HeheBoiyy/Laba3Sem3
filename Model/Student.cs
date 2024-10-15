namespace Model
{
    public class Student : IDomainObject
    {
        // Свойства студента
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public string Group { get; set; }

        // Конструктор для инициализации объекта Student
        public Student()
        {

        }
    }
}
