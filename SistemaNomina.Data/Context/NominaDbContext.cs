using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaNomina.Domain.Entities;

namespace SistemaNomina.Data.Context
{
    public class NominaDbContext : DbContext
    {
        public NominaDbContext(DbContextOptions<NominaDbContext> options) : base(options)
        {
        }

        public DbSet<EmpleadoAsalariado> EmpleadosAsalariados { get; set; }
        public DbSet<EmpleadoPorHoras> EmpleadosPorHoras { get; set; }
        public DbSet<EmpleadoPorComision> EmpleadosPorComision { get; set; }
        public DbSet<EmpleadoAsalariadoPorComision> EmpleadosAsalariadosPorComision { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpleadoAsalariado>().ToTable("EmpleadosAsalariados");
            modelBuilder.Entity<EmpleadoPorHoras>().ToTable("EmpleadosPorHoras");
            modelBuilder.Entity<EmpleadoPorComision>().ToTable("EmpleadosPorComision");
            modelBuilder.Entity<EmpleadoAsalariadoPorComision>().ToTable("EmpleadosAsalariadosPorComision");
        }
    }

}
