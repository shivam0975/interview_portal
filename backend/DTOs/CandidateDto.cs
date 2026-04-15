namespace backend.DTOs;

public class CandidateDto
{
    public int CandidateId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public string? College { get; set; }

    public int? DriveId { get; set; }
}