using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace api_dotnet
{
  public class PersonagemRepository
  {
    HttpClient api;

    public PersonagemRepository()
    {
      api = new HttpClient();
      api.BaseAddress = new Uri("https://swapi.co/api/");
      api.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    }
    public async Task<Person> GetPersonagemAsync(int id)
    {
      var time = new Stopwatch();
      time.Start();
      Person person;
      try
      {
        HttpResponseMessage res = await api.GetAsync($"people/{id}");
        if (res.IsSuccessStatusCode)
        {
          var dado = await res.Content.ReadAsStringAsync();
          person = JsonConvert.DeserializeObject<Person>(dado);


          Console.WriteLine($"Personagem id: {id}, {person.ToString()}");
          Console.WriteLine($"Tempo finalizacao da chamada {id}, tempo: {time.Elapsed}");
          Console.WriteLine("-------------------------------------------------------------------------------------");
          time.Stop();
          return person;

        }
        return null;
      }
      catch (System.Exception e)
      {

        throw e;
      }
    }
  }

}