using System.Net;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 4: GET List Categories
// TheMealDB API: https://themealdb.com/api/json/v1/1/categories.php
//
// Your task:
// 1. Use the HttpClient to fetch all meal categories
// 2. Assert status code is 200 OK
// 3. Parse the JSON and assert the "categories" array has more than 0 items
//
// Response format: { "categories": [{ "strCategory": "Beef", ... }, ...] }

public static class GetCategories
{
    public static async Task Run(HttpClient client)
    {
        // ? Correct URL
        string url = "https://www.themealdb.com/api/json/v1/1/categories.php";
        var response = await client.GetAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception($"Expected 200 OK, got {response.StatusCode}");

        string json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        var categories = doc.RootElement.GetProperty("categories");

        if (categories.ValueKind != JsonValueKind.Array || categories.GetArrayLength() <= 0)
            throw new Exception("No categories returned");
    }
}
