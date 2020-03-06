using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace api_dotnet
{
  class Program
  {

    static async Task Main(string[] args)
    {
      Console.WriteLine("Acessando a Web API do Star Wars, Aguarde um momento...");
      
      var repo = new PersonagemRepository();
      try
      {
        var finalAllTarefas =   await Task.WhenAll(
          repo.GetPersonagemAsync(1),
          repo.GetPersonagemAsync(2),
          repo.GetPersonagemAsync(3),
          repo.GetPersonagemAsync(4),
          repo.GetPersonagemAsync(5),
          repo.GetPersonagemAsync(6),
          repo.GetPersonagemAsync(7),
          repo.GetPersonagemAsync(8),
          repo.GetPersonagemAsync(9),
          repo.GetPersonagemAsync(10)
        );

        if(finalAllTarefas.Length == 10) Console.WriteLine("Task.WhenAll finalizada");


        Console.WriteLine("Final metodo Main");

      }
      catch (System.Exception e)
      {

        Console.WriteLine("Error " + e.Message);
      }

    }


  }
}
