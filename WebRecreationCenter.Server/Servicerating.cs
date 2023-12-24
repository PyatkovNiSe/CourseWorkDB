using System;
using System.Collections.Generic;

namespace WebRecreationCenter.Server;

public partial class Servicerating
{
    public int Ratingid { get; set; }

    public int? Userid { get; set; }

    public int? Serviceid { get; set; }

    public int? Rating { get; set; }

    public string? Comments { get; set; }

    public virtual Service? Service { get; set; }

    public virtual Userdatum? User { get; set; }
}
