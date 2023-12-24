using System;
using System.Collections.Generic;

namespace WebRecreationCenter.Server;

public partial class Userdatum
{
    public int Userdataid { get; set; }

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Phonenumber { get; set; } = null!;

    public int? Role { get; set; }

    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual Role? RoleNavigation { get; set; }

    public virtual ICollection<Servicerating> Serviceratings { get; set; } = new List<Servicerating>();
}
