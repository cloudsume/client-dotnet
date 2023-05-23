namespace Cloudsume.Client;

using System.Text.Json;
using Cloudsume.Models;
using NetUlid;

public interface IFeedbackClient
{
    /// <summary>
    /// Get feedbacks by score.
    /// </summary>
    /// <param name="score">
    /// The score of feedbacks to get.
    /// </param>
    /// <param name="skipTill">
    /// Identifier of the last feedback to skip.
    /// </param>
    /// <param name="cancellationToken">
    /// The token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// List of feedbacks ordered by newest to oldest.
    /// </returns>
    /// <exception cref="HttpRequestException">
    /// HTTP connection failed.
    /// </exception>
    /// <exception cref="JsonException">
    /// The response is not valid.
    /// </exception>
    Task<IEnumerable<Feedback>> ListAsync(int? score, Ulid? skipTill = null, CancellationToken cancellationToken = default);
}
