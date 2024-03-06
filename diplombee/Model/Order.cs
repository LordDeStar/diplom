using System;
using System.Collections.Generic;

namespace diplombee.Model;

public partial class Order
{
    public int Idorders { get; set; }

    public int? IdClient { get; set; }

    public DateTime? DataGet { get; set; }

    public int StatusOrder { get; set; }

    public int IdArea { get; set; }

    public int IdStreet { get; set; }

    public int NumberHouse { get; set; }

    public int NumberPodjezd { get; set; }

    public int Etaj { get; set; }

    public int NumberKv { get; set; }

    public int Reasons { get; set; }

    public virtual ICollection<Ordersproduct> Ordersproducts { get; } = new List<Ordersproduct>();
}
