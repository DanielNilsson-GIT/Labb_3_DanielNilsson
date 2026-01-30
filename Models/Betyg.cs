using System;
using System.Collections.Generic;

namespace Labb_3_DanielNilsson.Models;

public partial class Betyg
{
    public int Id { get; set; }

    public int? LärarId { get; set; }

    public DateTime? Datum { get; set; }

    public int? StudentId { get; set; }

    public string? Ämne { get; set; }

    public string? Betyg1 { get; set; }

    public virtual Personal? Lärar { get; set; }

    public virtual Studenter? Student { get; set; }
}
