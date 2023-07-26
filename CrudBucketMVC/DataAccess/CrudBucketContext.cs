using CrudBucketMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudBucketMVC.DataAccess
{
    public class CrudBucketContext : DbContext
    {
        public DbSet<Contienent> Contienents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public CrudBucketContext(DbContextOptions<CrudBucketContext> options) : base(options)
        {
            
        }
    }
}
