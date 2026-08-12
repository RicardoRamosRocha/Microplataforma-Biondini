namespace Microplataforma.Domain.Entities;

public class Material
{
    public int Id { get; set; }

    public int CandidateId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string FileUrl { get; set; } = string.Empty;

    public string? ThumbnailUrl { get; set; }

    public Candidate Candidate { get; set; } = null!;
}
