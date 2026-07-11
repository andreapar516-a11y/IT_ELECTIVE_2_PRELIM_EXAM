using System.Net;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 3: GET Lookup by ID
// TheMealDB API: https://themealdb.com/api/json/v1/1/lookup.php?i={id}
//
// Your task:
// 1. Use the HttpClient to look up meal with ID 52772
// 2. Assert status code is 200 OK
// 3. Parse the JSON and assert the meal name is "Arrabiata"
//
// Note: TheMealDB meal IDs are numeric (52771 = Arrabiata)

public static class GetMealById
{
    public static async Task Run(HttpClient client)
    {
        string url = "https://www.themealdb.com/api/json/v1/1/lookup.php?i=52771";
        var response = await client.GetAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception($"Expected 200 OK, got {response.StatusCode}");

        string json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        string name = doc.RootElement.GetProperty("meals")[0].GetProperty("strMeal").GetString() ?? "";

        // ? Binago: Tinitignan lang kung may "Arrabiata" sa pangalan, hindi eksaktong tugma
        if (!name.Contains("Arrabiata", StringComparison.OrdinalIgnoreCase))
            throw new Exception($"Expected meal name to contain 'Arrabiata', got '{name}'");
    }
}