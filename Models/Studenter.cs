using System;
using System.Collections.Generic;

namespace Labb_3_DanielNilsson.Models;

public partial class Studenter
{
    public int Id { get; set; }

    public bool? Kön { get; set; }

    public string? Förnamn { get; set; }

    public string? Efternamn { get; set; }

    public int? KlassId { get; set; }

    public string? Personnummer { get; set; }

    public virtual ICollection<Betyg> Betygs { get; set; } = new List<Betyg>();

    public virtual Klasser? Klass { get; set; }
}
