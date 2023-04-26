using APIRegistroAsistencia.Model;
using Microsoft.AspNetCore.Mvc;


namespace APIRegistroAsistencia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class controladorRespuesta : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var asistencia = new Asistencia
            {
                fecha = DateTime.Now,
                idAlumno = 1,
                nombreAlumno = "John Doe",
                idCurso = 1,
                nombreCurso = "Intro to Programming",
                asistio = true
            };

            return Ok(asistencia);
        }
    }
}
