using Microsoft.AspNetCore.Mvc;
using APIExtracurricular.Model;
namespace APIAlertas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControllerAlert : ControllerBase
    {
        private readonly ControllerCourse validateAlert;
        public ControllerAlert(ControllerCourse validateAlert_)
        {
            validateAlert = validateAlert_;

        }
        [HttpPost]
        public async Task<IActionResult> NewAlert(string NombreA, DateTime Fecha, string MensajeA)
        {
            if (validateAlert == null)
            {
                return BadRequest("No existente");
            }
            else if (validateAlert != null) 
            {
                var alerta = new Alerta { Nombre = NombreA, Fecha = DateTime.Now, Mensaje = "Asistencia correcta"};
                return Ok(alerta);
            }
            else 
            {
                return BadRequest("No asistio");
            }
        }
    }
}
