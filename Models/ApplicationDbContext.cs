using Microsoft.EntityFrameworkCore; // Não esqueça este using!
using mvc.Models;
using System.Collections.Generic;

namespace mvc.Models
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}   