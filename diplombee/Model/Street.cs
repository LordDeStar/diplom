using System;
using System.Collections.Generic;

namespace diplombee.Model;

public partial class Street
{
    public int Idstreet { get; set; }

    public int IdArea { get; set; }

    public string? NameStreet { get; set; }

    public virtual Area IdAreaNavigation { get; set; } = null!;
}
