namespace Cloudsume.Models;

using System;

public sealed class Configurations
{
    [Obsolete("This configuration no longer used.")]
    public Uri? SlackUri { get; init; }
}
