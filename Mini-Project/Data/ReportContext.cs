using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mini_Project.Model;

    public class ReportContext : DbContext
    {
        public ReportContext (DbContextOptions<ReportContext> options)
            : base(options)
        {
        }

        public DbSet<Mini_Project.Model.Report> Report { get; set; } = default!;
    }
