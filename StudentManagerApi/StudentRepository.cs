using StudentManagementApi.Models;


namespace StudentManagementApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new()
        {
            new Student { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Major = "Computer Science", EnrollmentDate = new DateTime(2022, 9, 1) },
            new Student { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Major = "Mathematics", EnrollmentDate = new DateTime(2021, 9, 1) }
        };

        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetStudentById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public Student AddStudent(Student student)
        {
            student.Id = _students.Max(s => s.Id) + 1;
            _students.Add(student);
            return student;
        }

        public Student UpdateStudent(Student student)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Email = student.Email;
                existingStudent.Major = student.Major;
                existingStudent.EnrollmentDate = student.EnrollmentDate;
            }
            return existingStudent;
        }

        public void DeleteStudent(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _students.Remove(student);
            }
        }
    }
}