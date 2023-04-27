using Microsoft.AspNetCore.Mvc;
using APIExtracurricular.Model;
using System.Net.Http.Headers;
using System.Text.Json;

namespace APIAlertas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControllerCourse
    {
        private readonly HttpClient _httpClient;
        public ControllerCourse(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<bool> validated(string Nombre)
        {
            var response = await _httpClient.GetAsync($"");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var alerta = JsonSerializer.Deserialize<dynamic>(jsonResponse);
                return alerta.asistencia;

            }
            return false;
        }
    }
}
