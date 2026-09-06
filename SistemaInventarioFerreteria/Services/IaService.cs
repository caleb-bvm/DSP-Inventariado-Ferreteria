using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text.Json;

namespace SistemaInventarioFerreteria.Services
{
    public class IaService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public IaService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string?> ExplicarAsync(string pregunta, string datos)
        {
            var apiKey = _configuration["OpenAI:ApiKey"];
            var modelo = _configuration["OpenAI:Modelo"];

            if (string.IsNullOrWhiteSpace(apiKey) ||
                string.IsNullOrWhiteSpace(modelo))
            {
                return null;
            }

            var contenido = new
            {
                model = modelo,
                instructions = "Eres un asistente interno de inventario. Responde en español, de forma breve y clara. Usa exclusivamente los datos proporcionados. No inventes cifras ni autorices compras.",
                input = $"Pregunta: {pregunta}\nDatos verificados por el sistema: {datos}",
                reasoning = new
                {
                    effort = "minimal"
                },
                text = new
                {
                    verbosity = "low"
                },
                max_output_tokens = 300,
                store = false
            };

            using var request = new HttpRequestMessage(
                HttpMethod.Post, "https://api.openai.com/v1/responses");
            request.Headers.Authorization = new AuthenticationHeaderValue(
                "Bearer", apiKey);
            request.Content = JsonContent.Create(contenido);

            try
            {
                using var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                using var json = await JsonDocument.ParseAsync(
                    await response.Content.ReadAsStreamAsync());

                if (json.RootElement.TryGetProperty("output_text", out var texto))
                {
                    return texto.GetString();
                }

                // Respaldo para respuestas que entregan el texto dentro de output.
                foreach (var salida in json.RootElement.GetProperty("output").EnumerateArray())
                {
                    if (!salida.TryGetProperty("content", out var contenidos)) continue;

                    foreach (var contenidoRespuesta in contenidos.EnumerateArray())
                    {
                        if (contenidoRespuesta.TryGetProperty("text", out var textoSalida))
                        {
                            return textoSalida.GetString();
                        }
                    }
                }

                return null;
            }
            catch (HttpRequestException)
            {
                return null;
            }
            catch (JsonException)
            {
                return null;
            }
            catch (TaskCanceledException)
            {
                return null;
            }
        }
    }
}
