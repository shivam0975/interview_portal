using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class InterviewSlot
{
    public int SlotId { get; set; }

    public int? DriveId { get; set; }

    public int? CandidateId { get; set; }

    public int? PanelistId { get; set; }

    public DateTime ScheduledTime { get; set; }

    public string? Status { get; set; }

    public string? Feedback { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Candidate? Candidate { get; set; }

    public virtual Drife? Drive { get; set; }

    public virtual User? Panelist { get; set; }
}
