
namespace Microplataforma.Domain.Entities;

public class Candidate
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string Office { get; set; } = string.Empty;

    public string Biography { get; set; } = string.Empty;

    public string ShortBiography { get; set; } = string.Empty;

    public string? PhotoUrl { get; set; }

    public string? HeroImageUrl { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<Content> Contents { get; set; } = new List<Content>();

    public ICollection<Event> Events { get; set; } = new List<Event>();

    public ICollection<SocialLink> SocialLinks { get; set; } = new List<SocialLink>();

    public ICollection<Material> Materials { get; set; } = new List<Material>();
}
