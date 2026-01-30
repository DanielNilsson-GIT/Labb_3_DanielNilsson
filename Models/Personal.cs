using System;
using System.Collections.Generic;

namespace Labb_3_DanielNilsson.Models;

public partial class Personal
{
    public int Id { get; set; }

    public string? Förnamn { get; set; }

    public string? Efternamn { get; set; }

    public int? YrkesId { get; set; }

    public virtual ICollection<Betyg> Betygs { get; set; } = new List<Betyg>();

    public virtual ICollection<Klasser> Klassers { get; set; } = new List<Klasser>();

    public virtual Yrkestitel? Yrkes { get; set; }
}
