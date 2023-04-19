using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AsistenciasAPI.Controllers
{
    [ApiController]
    [Route("api/asistencia")]
    public class AsistenciasController : ControllerBase
    {
        private static readonly string[] DiasSemana = new[]
        {
            "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo"
        };

        private readonly ILogger<AsistenciasController> _logger;

        public AsistenciasController(ILogger<AsistenciasController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Asistencia> ObtenerAsistencias()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Asistencia
            {
                Fecha = DateTime.Now.AddDays(index),
                DiaSemana = DiasSemana[rng.Next(DiasSemana.Length)],
                NombreEmpleado = $"Empleado {index}",
                Presente = (rng.Next(0, 2) == 0) ? true : false
            })
            .ToArray();
        }
    }

    public class Asistencia
    {
        public DateTime Fecha { get; set; }
        public string DiaSemana { get; set; }
        public string NombreEmpleado { get; set; }
        public bool Presente { get; set; }
    }
}