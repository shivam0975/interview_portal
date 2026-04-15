namespace backend.DTOs;

public class DriveDto
{
    public int DriveId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Location { get; set; }

    public DateTime DriveDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }
}