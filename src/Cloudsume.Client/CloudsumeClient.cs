namespace Cloudsume.Client;

using UriBuilder = Ultima.Extensions.Primitives.UriBuilder;

public abstract class CloudsumeClient : IDisposable
{
    private readonly HttpClient http;
    private readonly string basePath;

    protected CloudsumeClient(HttpClient http, string basePath)
    {
        if (http.BaseAddress is null)
        {
            throw new ArgumentException($"No {nameof(http.BaseAddress)} is specified.", nameof(http));
        }

        this.http = http;
        this.basePath = basePath;
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            this.http.Dispose();
        }
    }

    protected UriBuilder CreateUriBuilder() => UriBuilder
        .For(this.http.BaseAddress ?? throw new InvalidOperationException())
        .AppendPath(this.basePath);

    protected Task<HttpResponseMessage> GetAsync(UriBuilder uri, CancellationToken cancellationToken = default)
    {
        return this.http.GetAsync(uri.BuildUri(), HttpCompletionOption.ResponseHeadersRead, cancellationToken);
    }
}
