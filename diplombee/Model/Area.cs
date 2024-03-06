using System;
using System.Collections.Generic;

namespace diplombee.Model;

public partial class Area
{
    public int IdArea { get; set; }

    public string NameArea { get; set; } = null!;

    public virtual ICollection<Street> Streets { get; } = new List<Street>();
}
