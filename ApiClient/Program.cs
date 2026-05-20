using System.Collections.Concurrent;
using BlogApi;

var httpClient = new HttpClient();
var apiBaseUrl = "http://localhost:5000";

var client = new BlogApiClient(httpClient, apiBaseUrl);

var blogs = await client.GetBlogsAsync();


    Console.WriteLine("Blogs:");
    foreach (var blog in blogs)
    {
        Console.WriteLine($"Title: {blog.Title}");
        Console.WriteLine($"Body: {blog.Body}");
        Console.WriteLine();
    }

    client.BlogsDeleteAsync(1);

    var blog = new Blog
    {
        Title = "New Blog Post",
        Body = "This is the body of the new blog post."
    };

    client.BlogsPostAsync(blog);    

//await new SwaggerClientGenerator().GenerateClient();

//App running at http://localhost:5000
/*
var httpClient = new HttpClient();
var apiBaseUrl = "http://localhost:5000";

var httpResults = await httpClient.GetAsync($"{apiBaseUrl}/blogs");

if (httpResults.StatusCode != System.Net.HttpStatusCode.OK)
{
    Console.WriteLine($"Failed to get blogs. Status code: {httpResults.StatusCode}  Reason: {httpResults.ReasonPhrase}");
    return;
}

var blogsStream = await httpResults.Content.ReadAsStreamAsync();

var options = new System.Text.Json.JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true

};

var blogs = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Blog>>(blogsStream, options);

if(blogs == null)
{
    Console.WriteLine("No blogs found.");
    return;
}else
{
    Console.WriteLine("Blogs:");
    foreach (var blog in blogs)
    {
        Console.WriteLine($"Title: {blog.Title}");
        Console.WriteLine($"Body: {blog.Body}");
        Console.WriteLine();
    }
}
*/

class Blog
{
    public required string Title { get; set; }
    public required string Body { get; set; }
}