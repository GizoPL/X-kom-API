using Microsoft.EntityFrameworkCore;
using XkomAPI.Model;

namespace XkomAPI.Reposiotory
{
    public class ApiContex : DbContext
    {
        public ApiContex(DbContextOptions<ApiContex> opt) : base(opt){ }
        public  DbSet<Meeting> Meetings { get; set; }
        public  DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    
    }
}