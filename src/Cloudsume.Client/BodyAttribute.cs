namespace Cloudsume.Client;

using Refit;

public sealed class BodyAttribute : Refit.BodyAttribute
{
    public BodyAttribute()
        : base(BodySerializationMethod.Serialized)
    {
    }
}
