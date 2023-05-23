namespace Cloudsume.Client;

using System.Globalization;
using System.Text.Json;
using Cloudsume.Models;
using NetUlid;

public sealed class FeedbackClient : CloudsumeClient, IFeedbackClient
{
    private readonly JsonSerializerOptions json;

    public FeedbackClient(HttpClient http, JsonSerializerOptions json)
        : base(http, new("feedbacks"))
    {
        this.json = json;
    }

    public async Task<IEnumerable<Feedback>> ListAsync(int? score, Ulid? skipTill = null, CancellationToken cancellationToken = default)
    {
        // Build request URL.
        var uri = this.CreateUriBuilder();

        if (score.HasValue)
        {
            uri.AppendQuery("score", score.Value.ToString(CultureInfo.InvariantCulture));
        }

        if (skipTill.HasValue)
        {
            uri.AppendQuery("skip_till", skipTill.Value.ToString());
        }

        // Send the request.
        using var response = await this.GetAsync(uri, cancellationToken).ConfigureAwait(false);

        return await response
            .EnsureSuccessStatusCode()
            .ReadJsonAsync<IEnumerable<Feedback>>(this.json, cancellationToken)
            .ConfigureAwait(false) ?? throw new JsonException("Invalid root value.");
    }
}
