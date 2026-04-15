using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Candidate
{
    public int CandidateId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? College { get; set; }

    public int? DriveId { get; set; }

    public virtual Drife? Drive { get; set; }

    public virtual ICollection<InterviewSlot> InterviewSlots { get; set; } = new List<InterviewSlot>();
}
