using System.Net;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 10: GET Deserialize Multiple Meals
// TheMealDB API: https://themealdb.com/api/json/v1/1/search.php?f=a
//
// This endpoint returns ALL meals starting with the letter "a".
//
// Your task:
// 1. Use the HttpClient to fetch meals starting with letter "a"
// 2. Assert status code is 200 OK
// 3. Parse the JSON and get the "meals" array
// 4. Assert the array has more than 0 items
// 5. Loop through each meal and print its name (strMeal)
//
// Response format:
// {
//   "meals": [
//     { "idMeal": "52772", "strMeal": "Arrabiata", ... },
//     { "idMeal": "52781", "strMeal": "Ayam Percik", ... },
//     ...
//   ]
// }

public static class DeserializeMeals
{
    public static async Task Run(HttpClient client)
    {
        // ? Correct URL
        string url = "https://www.themealdb.com/api/json/v1/1/search.php?f=a";
        var response = await client.GetAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception($"Expected 200 OK, got {response.StatusCode}");

        string json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        var meals = doc.RootElement.GetProperty("meals");

        if (meals.ValueKind != JsonValueKind.Array || meals.GetArrayLength() <= 0)
            throw new Exception("No meals starting with letter 'a' found");

        foreach (var meal in meals.EnumerateArray())
        {
            Console.WriteLine($"- {meal.GetProperty("strMeal").GetString()}");
        }
    }
}
