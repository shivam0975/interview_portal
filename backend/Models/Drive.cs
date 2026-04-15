using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Drife
{
    public int DriveId { get; set; }

    public string Title { get; set; } = null!;

    public string? Location { get; set; }

    public DateTime DriveDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<InterviewSlot> InterviewSlots { get; set; } = new List<InterviewSlot>();
}
