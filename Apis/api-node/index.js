const axios = require("axios");
const readline = require("readline");
const baseApiSW = "https://swapi.co/api";

let pessoa = {};
let count = 0;
// const leitor = readline.createInterface({
//   input: process.stdin,
//   output: process.stdout
// });
const promisses = [
  buscarPessoas(1),
  buscarPessoas(2),
  buscarPessoas(3),
  buscarPessoas(4),
  buscarPessoas(5),
  buscarPessoas(6),
  buscarPessoas(7),
  buscarPessoas(8),
  buscarPessoas(9),
  buscarPessoas(10)
];

 function main() {
  console.log("Acessando a Web API do Star Wars, Aguarde um Momento...");

  Promise.all(promisses)
    .catch(error => console.log("Deu ruim " + error))
    .finally(() => console.log("Finalizado todas a promisses"));

  console.log("Final linha main");
}

async function buscarPessoas(id) {
  let timeRequest = `Tempo de Requisição id ${id}`;
  console.time(timeRequest);
  try {
    const {data} = await axios.get(`${baseApiSW}/people/${id}`)
    
    pessoa = {
      id,
      nome: data.name,
      peso: data.mass
    };
    console.log(`Promise finalizada de id ${id} - Personagem`, pessoa);
    console.timeEnd(timeRequest);
    console.log('----------------------------------------------------------------------------------------------------');
    return pessoa
    
  } catch (error) {
    console.log('Deu ruim', error.data);
    return;
  }

}

main();
