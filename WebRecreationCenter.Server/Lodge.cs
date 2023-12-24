using System;
using System.Collections.Generic;

namespace WebRecreationCenter.Server;

public partial class Lodge
{
    public int Lodgeid { get; set; }

    public int Lodgenumber { get; set; }

    public string Description { get; set; } = null!;

    public decimal Lodgeprice { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
