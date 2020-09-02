

namespace ApiSeccureStudent.Models
{
    using System.Data.Entity;
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<ApiSeccureStudent.Models.Student> Students { get; set; }
    }
}