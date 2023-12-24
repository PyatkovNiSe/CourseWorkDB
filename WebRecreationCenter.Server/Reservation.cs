using System;
using System.Collections.Generic;

namespace WebRecreationCenter.Server;

public partial class Reservation
{
    public int Reservationid { get; set; }

    public int? Userid { get; set; }

    public int? Lodgeid { get; set; }

    public DateOnly Checkindate { get; set; }

    public DateOnly Checkoutdate { get; set; }

    public virtual Lodge? Lodge { get; set; }

    public virtual Userdatum? User { get; set; }
}
