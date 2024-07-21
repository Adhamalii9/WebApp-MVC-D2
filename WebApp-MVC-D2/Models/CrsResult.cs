using Microsoft.EntityFrameworkCore;

namespace WebApp_MVC_D2.Models
{

    [PrimaryKey(nameof(CrsId),nameof(TraineeId))]
    public class CrsResult
    {

        public int Degree { get; set; }

        public int CrsId { get; set; }

        public int TraineeId { get; set; }

        public Course Crs { get; set; }

        public Trainee Trainee { get; set; }
    }
}
