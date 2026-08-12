namespace Microplataforma.Domain.Entities;

public class Event
{
    public int Id { get; set; }

    public int CandidateId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public DateTimeOffset StartsAt { get; set; }

    public DateTimeOffset? EndsAt { get; set; }

    public Candidate Candidate { get; set; } = null!;
}
