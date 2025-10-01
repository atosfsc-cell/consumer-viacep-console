using System.Text.Json;
using ConsumerViaCep.Models;
using static System.Console;

WriteLine("Digite o seu CEP: ");
var cep = ReadLine();

var enderecoUrl = $@"https://viacep.com.br/ws/{cep}/json/";

var client = new HttpClient();

try
{
    HttpResponseMessage? respostaApi = await client.GetAsync(enderecoUrl);
    respostaApi.EnsureSuccessStatusCode();

    string respostaApiJson = await respostaApi.Content.ReadAsStringAsync();
    Endereco? endereco = JsonSerializer.Deserialize<Endereco>(respostaApiJson);
    WriteLine("CEP:\n" + endereco.cep);
    WriteLine("Rua:\n" + endereco.logradouro);
    WriteLine("Bairro:\n" + endereco.bairro);
    WriteLine("Cidade:\n" + endereco.localidade);
}
catch (System.Exception e)
{
    WriteLine("Aconteceu um erro:\n" + e.Message);
    throw;
}