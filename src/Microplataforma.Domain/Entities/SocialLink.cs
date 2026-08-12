namespace Microplataforma.Domain.Entities;

public class SocialLink
{
    public int Id { get; set; }

    public int CandidateId { get; set; }

    public string Platform { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public Candidate Candidate { get; set; } = null!;
}
