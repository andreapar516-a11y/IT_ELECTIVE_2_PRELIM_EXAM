using System.Net;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 5: GET Filter by Ingredient
// TheMealDB API: https://themealdb.com/api/json/v1/1/filter.php?i={ingredient}
//
// Your task:
// 1. Use the HttpClient to filter meals by ingredient "chicken_breast"
// 2. Assert status code is 200 OK
// 3. Parse the JSON and assert the "meals" array has at least 1 item
//
// Response format: { "meals": [{ "strMeal": "...", "strMealThumb": "...", "idMeal": "..." }, ...] }

public static class FilterByIngredient
{
    public static async Task Run(HttpClient client)
    {
        // ? Correct URL
        string url = "https://www.themealdb.com/api/json/v1/1/filter.php?i=chicken_breast";
        var response = await client.GetAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception($"Expected 200 OK, got {response.StatusCode}");

        string json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        var meals = doc.RootElement.GetProperty("meals");

        if (meals.ValueKind != JsonValueKind.Array || meals.GetArrayLength() < 1)
            throw new Exception("No meals found for chicken breast");
    }
}