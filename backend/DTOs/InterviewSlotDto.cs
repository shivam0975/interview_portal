namespace backend.DTOs;

public class InterviewSlotDto
{
    public int SlotId { get; set; }

    public int? DriveId { get; set; }

    public int? CandidateId { get; set; }

    public int? PanelistId { get; set; }

    public DateTime ScheduledTime { get; set; }

    public string? Status { get; set; }

    public string? Feedback { get; set; }

    public DateTime? UpdatedAt { get; set; }
}