namespace Cloudsume.Client;

using Cloudsume.Models;
using NetUlid;
using Refit;

public interface IFeedbackClient
{
    [Get("/feedbacks")]
    Task<IEnumerable<Feedback>> ListAsync(int? score, [AliasAs("skip_till")] Ulid? skipTill = null, CancellationToken cancellationToken = default);
}
