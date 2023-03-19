namespace Cloudsume.Client;

using Cloudsume.Models;
using Refit;

public interface IConfigurationClient
{
    [Get("/configurations")]
    Task<Configurations> ReadAllAsync(CancellationToken cancellationToken = default);

    [Put("/configurations/slack-uri")]
    [Obsolete("This endpoint is no longer used.")]
    Task WriteSlackUriAsync([Body] Uri? uri, CancellationToken cancellationToken = default);
}
