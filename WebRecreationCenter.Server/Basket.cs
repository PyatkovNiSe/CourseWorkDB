using System;
using System.Collections.Generic;

namespace WebRecreationCenter.Server;

public partial class Basket
{
    public int Orderid { get; set; }

    public int? Userid { get; set; }

    public int? Serviceid { get; set; }

    public DateOnly Orderdate { get; set; }

    public virtual Service? Service { get; set; }

    public virtual Userdatum? User { get; set; }
}
