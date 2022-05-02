namespace Cloudsume.Client;

using Cloudsume.Models;
using Refit;

public interface IConfigurationClient
{
    [Get("/configurations")]
    Task<Configurations> ReadAllAsync(CancellationToken cancellationToken = default);

    [Put("/configurations/slack-uri")]
    Task WriteSlackUriAsync([Body] Uri? uri, CancellationToken cancellationToken = default);
}
