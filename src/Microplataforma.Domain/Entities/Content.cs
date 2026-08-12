using Microplataforma.Domain.Enums;

namespace Microplataforma.Domain.Entities;

public class Content
{
    public int Id { get; set; }

    public int CandidateId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;

    public string Body { get; set; } = string.Empty;

    public ContentType Type { get; set; }

    public string? ImageUrl { get; set; }

    public DateTimeOffset? PublishedAt { get; set; }

    public bool IsPublished { get; set; }

    public Candidate Candidate { get; set; } = null!;
}
