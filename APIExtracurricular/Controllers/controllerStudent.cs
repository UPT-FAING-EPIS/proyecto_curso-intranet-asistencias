using System.Net.Http.Headers;
using System.Text.Json;
namespace APIExtracurricular.Controllers
{
    public class controllerStudent
    {
        private readonly HttpClient _httpClient;
        public controllerStudent(HttpClient httpClient) 
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<bool> validated(int idAlumno) 
        {
            var response = await _httpClient.GetAsync($"");
            if (response.IsSuccessStatusCode) 
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var resultao = JsonSerializer.Deserialize<dynamic>(jsonResponse);
                return resultao.inscrito;

            }
            return false;
        }
    }
}
