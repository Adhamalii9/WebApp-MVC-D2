namespace WebApp_MVC_D2.ViewModels
{
    public class TraineeWithCourseNameAndDegreeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string CourseName { get; set; }

        public int CourseDegree { get; set; }
        public int CourseMinDegree { get; set; }

        public int TraineeDegree { get; set; }

        public bool SuccOrFail { get; set; }


    }
}
