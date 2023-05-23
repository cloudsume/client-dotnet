namespace Cloudsume.Client;

using System.Net.Http.Headers;
using System.Text.Json;

internal static class HttpResponseMessageExtensions
{
    public static async Task<T?> ReadJsonAsync<T>(
        this HttpResponseMessage response,
        JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        // Check if JSON.
        var type = response.GetContentType();

        if (!string.Equals(type.MediaType, "application/json", StringComparison.OrdinalIgnoreCase))
        {
            throw new HttpRequestException("The response is not JSON.");
        }

        // Read JSON.
        var body = await response.Content
            .ReadAsStreamAsync(cancellationToken)
            .ConfigureAwait(false);

        return await JsonSerializer
            .DeserializeAsync<T>(body, options, cancellationToken)
            .ConfigureAwait(false);
    }

    public static MediaTypeHeaderValue GetContentType(this HttpResponseMessage response)
    {
        return response.Content.Headers.ContentType ?? throw new HttpRequestException("No Content-Type is specified in the response.");
    }
}
