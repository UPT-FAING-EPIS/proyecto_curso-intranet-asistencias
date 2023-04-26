using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;


namespace APIRegistroAsistencia.Controllers
{
    public class controladorInscripcion
    {

        private readonly HttpClient _httpClient;

        public controladorInscripcion(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.example.com/"); // URL de la API
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // Acepta JSON como formato de respuesta
        }

        public async Task<bool> EstaInscrito(int idAlumno, int idCurso)
        {
            var response = await _httpClient.GetAsync($"cursos/{idCurso}/alumnos/{idAlumno}"); // Realiza la solicitud GET a la API

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync(); // Lee el contenido de la respuesta como una cadena JSON
                var resultado = JsonSerializer.Deserialize<dynamic>(jsonResponse); // Convierte la cadena JSON en un objeto dinámico
                return resultado.inscrito; // Devuelve la propiedad "inscrito" del objeto dinámico
            }

            return false; // Devuelve falso si la solicitud no fue exitosa
        }



    }
}
