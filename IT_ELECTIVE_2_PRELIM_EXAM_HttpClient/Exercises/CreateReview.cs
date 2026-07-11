using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class CreateReview
{
    public static async Task Run(HttpClient client)
    {
        string url = "https://jsonplaceholder.typicode.com/posts";
        string jsonBody = @"{""title"":""Great Pasta"",""body"":""Loved this recipe"",""userId"":1}";
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(url, content);

        if (response.StatusCode != HttpStatusCode.Created)
            throw new Exception($"Expected 201 Created, got {response.StatusCode}");

        string responseJson = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(responseJson);

        if (!doc.RootElement.TryGetProperty("id", out _))
            throw new Exception("Response does not contain 'id' field");
    }
}
