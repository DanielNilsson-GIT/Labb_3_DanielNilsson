using System;
using System.Collections.Generic;

namespace Labb_3_DanielNilsson.Models;

public partial class Klasser
{
    public int Id { get; set; }

    public int? MentorId { get; set; }

    public string? Namn { get; set; }

    public virtual Personal? Mentor { get; set; }

    public virtual ICollection<Studenter> Studenters { get; set; } = new List<Studenter>();
}
