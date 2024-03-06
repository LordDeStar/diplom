using System;
using System.Collections.Generic;

namespace diplombee.Model;

public partial class Ordersproduct
{
    public int IdOrdersProducts { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? Count { get; set; }

    public virtual Order? Order { get; set; }

    public virtual PriseList? Product { get; set; }
}
