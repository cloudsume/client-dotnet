namespace Cloudsume.Models;

using System.Net.Mail;
using NetUlid;

public sealed class Feedback
{
    public Feedback(Ulid id, string detail, MailAddress? contact)
    {
        this.Id = id;
        this.Detail = detail;
        this.Contact = contact;
    }

    public Ulid Id { get; }

    public string Detail { get; }

    public MailAddress? Contact { get; }
}
