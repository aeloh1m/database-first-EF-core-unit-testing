using System;
using System.Collections.Generic;

namespace EFCoreProject.Models;

public partial class Movie
{
    public int IdMovie { get; set; }

    public string MovieName { get; set; } = null!;

    public int? MovieGenre { get; set; }

    public int MovieDuration { get; set; }

    public float? MovieBudget { get; set; }

    public virtual Actor? Actor { get; set; }
}
