namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 8: DELETE Remove Review
// JSONPlaceholder API: https://jsonplaceholder.typicode.com/posts/{id}
//
// Your task:
// 1. Send a DELETE request to remove post with ID 1
// 2. Assert status code is 200 OK
//
// Hint: Use await client.DeleteAsync(url)

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

public static class DeleteReview
{
    public static async Task Run(HttpClient client)
    {
        string url = "https://jsonplaceholder.typicode.com/posts/1";
        var response = await client.DeleteAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception($"Expected 200 OK, got {response.StatusCode}");
    }
}
