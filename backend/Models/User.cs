using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Drife> Drives { get; set; } = new List<Drife>();

    public virtual ICollection<InterviewSlot> InterviewSlots { get; set; } = new List<InterviewSlot>();
}
