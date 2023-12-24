using System;
using System.Collections.Generic;

namespace WebRecreationCenter.Server;

public partial class Service
{
    public int Serviceid { get; set; }

    public string Servicename { get; set; } = null!;

    public string? Servicedescription { get; set; }

    public decimal Serviceprice { get; set; }

    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();

    public virtual ICollection<Servicerating> Serviceratings { get; set; } = new List<Servicerating>();
}
