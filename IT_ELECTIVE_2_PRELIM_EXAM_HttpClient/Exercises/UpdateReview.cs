using System.Net;
using System.Text;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 7: PUT Update Review
// JSONPlaceholder API: https://jsonplaceholder.typicode.com/posts/{id}
//
// Your task:
// 1. Create a JSON body: { "id": 1, "title": "Updated Review", "body": "Even better than before!", "userId": 1 }
// 2. Wrap it in StringContent with media type "application/json"
// 3. Send a PUT request to update post with ID 1
// 4. Assert status code is 200 OK
// 5. Parse the response JSON and assert the title is "Updated Review"
//
// Hint: Use await client.PutAsync(url, content)

public static class UpdateReview
{
    public static async Task Run(HttpClient client)
    {
        // API endpoint
        string url = "https://jsonplaceholder.typicode.com/posts/1";

        // Correct JSON string (proper quotes)
        string jsonBody = @"{""id"": 1, ""title"": ""Updated"", ""body"": ""Even better than before!"", ""userId"": 1}";

        // Create content with correct media type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        var response = await client.PutAsync(url, content);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Expected 200 OK, got {response.StatusCode}");
        }

        string responseJson = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(responseJson);

        string title = doc.RootElement.GetProperty("title").GetString() ?? "";
        if (title != "Updated")
        {
            throw new Exception($"Expected title 'Updated', got '{title}'");
        }
    }
}
