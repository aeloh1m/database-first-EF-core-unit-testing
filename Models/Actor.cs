using System;
using System.Collections.Generic;

namespace EFCoreProject.Models;

public partial class Actor
{
    public int IdActor { get; set; }

    public string ActorName { get; set; } = null!;

    public string? ActorBirthdate { get; set; }

    public string? ActorPicture { get; set; }

    public virtual Movie IdActorNavigation { get; set; } = null!;
}
