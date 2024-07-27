using Microsoft.AspNetCore.Cors.Infrastructure;

namespace WebApp_MVC_D2.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image{ get; set; }

        public string Address { get; set; }

        public int DeptId { get; set; }
        public virtual Department Dept { get; set; }

        public virtual ICollection<CrsResult> CrsResults { get; set; }



    }
}
