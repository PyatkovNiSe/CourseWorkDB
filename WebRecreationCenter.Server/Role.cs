using System;
using System.Collections.Generic;

namespace WebRecreationCenter.Server;

public partial class Role
{
    public int Roleid { get; set; }

    public string Rolename { get; set; } = null!;

    public virtual ICollection<Userdatum> Userdata { get; set; } = new List<Userdatum>();
}
