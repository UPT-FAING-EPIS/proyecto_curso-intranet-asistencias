using AsistenciaAPIPSQL.Models;
using Microsoft.EntityFrameworkCore;

namespace AsistenciaAPIPSQL.Data
{
    public class UptDB : DbContext
    {
        public UptDB(DbContextOptions<UptDB> options) : base(options) 
        {
        }
        public DbSet<Asistencia> Asistencias => Set<Asistencia>();
        public DbSet<ExtraC> ExtraC => Set<ExtraC>();
    }
}
