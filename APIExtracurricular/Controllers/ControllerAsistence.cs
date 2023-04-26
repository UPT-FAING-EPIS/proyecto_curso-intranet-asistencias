using Microsoft.AspNetCore.Mvc;
using APIExtracurricular.Model;
namespace APIExtracurricular.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class ControllerAsistence : ControllerBase
    {
        private readonly controllerStudent validateStudent;
        public ControllerAsistence(controllerStudent _validateStudent)
        {
            validateStudent = _validateStudent;

        }
        [HttpPost]
        public async Task<IActionResult> RegisterEvent(int idAlumno, string nomEvento, bool asistio) 
        {
            if (!await validateStudent.validated(idAlumno))
            {
                return BadRequest("CHECHO NO ESTA");
            }
            var asistencia = new Evento { Nombre = nomEvento, Fecha = DateTime.Now, NombreAlumno = "prueba de alumno", CodAlumno = idAlumno, Asistio = asistio };
            return Ok(asistencia);

        }
    }
}
