namespace WebApp_MVC_D2.ViewModels
{
    public class TraineePaginationViewModel
    {
        public List<TraineesWithDeptName> Trainees { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
