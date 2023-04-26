using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using APIRegistroAsistencia.Model;



namespace APIRegistroAsistencia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class controladorAsistencia : ControllerBase
    {

            private readonly controladorInscripcion validadorDeInscripcion;
            public controladorAsistencia(controladorInscripcion _validadorDeInscripcion)
            {
                validadorDeInscripcion = _validadorDeInscripcion;
            }

            [HttpPost]
            public async Task<IActionResult> RegistrarAsistencia(int idAlumno, int idCurso, bool asistio)
            {
                // Verifica si el alumno está inscrito en el curso
                if (!await validadorDeInscripcion.EstaInscrito(idAlumno, idCurso))
                {
                    return BadRequest("El alumno no está inscrito en el curso especificado."); // Devuelve un error si el alumno no está inscrito
                }

                // Crea una nueva instancia de la clase Asistencia y la llena con los datos correspondientes
                var asistencia = new Asistencia
                {
                    fecha = DateTime.Now,
                    idAlumno = idAlumno,
                    nombreAlumno = "John Doe", // Reemplazar con la lógica real para obtener el nombre del alumno
                    idCurso = idCurso,
                    nombreCurso = "Curso de ejemplo", // Reemplazar con la lógica real para obtener el nombre del curso
                    asistio = asistio
                };

                // Guarda la instancia de Asistencia en la base de datos o realiza otra lógica necesaria
                // ...

                return Ok(asistencia); // Devuelve un objeto JSON con la información de la asistencia
            }

        }
}
