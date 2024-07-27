namespace WebApp_MVC_D2.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<Trainee> Trainees { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
