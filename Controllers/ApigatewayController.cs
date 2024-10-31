using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Collections.Generic;

namespace ApiReceitas.Controllers
{
    public class ApigatewayController : ControllerBase
    {
        [HttpGet]
        [Route("/apigateway/receitas")]
        public IActionResult BuscarReceitas(string receita)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("https://forkify-api.herokuapp.com")
                };
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); // define o cabeçalho accept para informar ao servidor que o cliente espera a resposta no formato json

                HttpResponseMessage resposta = client.GetAsync($"/api/search?q={receita}").Result; 

                if (resposta.IsSuccessStatusCode)
                {
                    var jsonString = resposta.Content.ReadAsStringAsync().Result; // os dados vem cru em uma string então converto para um json para ficar organizado
                    var jsonDoc = JsonDocument.Parse(jsonString);
                    var receitasJson = jsonDoc.RootElement.GetProperty("recipes");

                    var receitas = new List<Receita>();
                    foreach (var receitaJson in receitasJson.EnumerateArray())
                    {
                        receitas.Add(new Receita
                        {
                            Publisher = receitaJson.GetProperty("publisher").GetString(),
                            Title = receitaJson.GetProperty("title").GetString(),
                            SourceUrl = receitaJson.GetProperty("source_url").GetString(),
                            RecipeId = receitaJson.GetProperty("recipe_id").GetString(),
                            ImageUrl = receitaJson.GetProperty("image_url").GetString(),
                            SocialRank = receitaJson.GetProperty("social_rank").GetDouble()
                        });
                    }

                    return Ok(new { Count = receitas.Count, recipes = receitas });
                }
                else
                {
                    return BadRequest("Houve algum problema com a requisição. Por favor, verifique.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
