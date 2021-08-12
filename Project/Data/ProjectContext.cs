using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext (DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Project.Models.Feedback> Feedback { get; set; }

        public DbSet<Project.Models.Payments> Payments { get; set; }

        public DbSet<Project.Models.Login> Login { get; set; }
    }
}
