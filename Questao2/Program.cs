using Newtonsoft.Json;
using Questao2;
using System.Diagnostics;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoalsAsync(teamName, year).Result;

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals =  getTotalScoredGoalsAsync(teamName, year).Result;

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    /// <summary>
    /// Retorna a quantidade de gols marcados por time em um ano
    /// </summary>
    /// <param name="team">Nome do time</param>
    /// <param name="year">Ano da competição</param>
    /// <returns>Inteiro representando a quantidade de gols marcados no ano</returns>
    public static async Task<int> getTotalScoredGoalsAsync(string team, int year)
    {
        HttpClient _client = new HttpClient();
        JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        int gols = 0;

        try
        {
            var response = await _client.GetAsync($"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}");
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    //Classe Root gerada através da do site https://json2csharp.com/
                    var jsonResponse = await System.Text.Json.JsonSerializer.DeserializeAsync<Root>(responseStream, _serializerOptions);

                    gols = jsonResponse.Data.Sum(selector: g => int.Parse(g.Team1goals)); 
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Erro ao acessar a API " + ex.Message);

        }
                
        return gols;
    }

}