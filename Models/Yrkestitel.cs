using System;
using System.Collections.Generic;

namespace Labb_3_DanielNilsson.Models;

public partial class Yrkestitel
{
    public int Id { get; set; }

    public string? Titel { get; set; }

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();
}
