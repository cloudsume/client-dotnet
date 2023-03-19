namespace Microsoft.Extensions.DependencyInjection;

using Cloudsume.Client;
using Refit;

public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Adds all available Cloudsumé clients.
    /// </summary>
    /// <param name="services">
    /// A service collection to add to.
    /// </param>
    /// <param name="httpClient">
    /// A delegate to provide <see cref="HttpClient"/>. This delegate will get called multiple times per client type. The <see cref="HttpClient.BaseAddress"/>
    /// must be configured before returning from the delegate. Usually the value will be is https://api.cloudsume.com.
    /// </param>
    public static void AddCloudsumeClients(this IServiceCollection services, Func<IServiceProvider, Type, HttpClient> httpClient)
    {
        services.AddSingleton(RefitFactory<IConfigurationClient>);
        services.AddSingleton(RefitFactory<IFeedbackClient>);

        T RefitFactory<T>(IServiceProvider services) => RestService.For<T>(httpClient(services, typeof(T)));
    }
}
