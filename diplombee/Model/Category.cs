using System;
using System.Collections.Generic;

namespace diplombee.Model;

public partial class Category
{
    public int Idcategory { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<PriseList> PriseLists { get; } = new List<PriseList>();
}
