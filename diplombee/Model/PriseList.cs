using System;
using System.Collections.Generic;

namespace diplombee.Model;

public partial class PriseList
{
    public int IdProduct { get; set; }

    public string Article { get; set; } = null!;

    public string NameProduct { get; set; } = null!;

    public int CountInStock { get; set; }

    public decimal? CostForOne { get; set; }

    public int Categoyid { get; set; }

    public string? Image { get; set; }
    public virtual Category Categoy { get; set; } = null!;

    public virtual ICollection<Ordersproduct> Ordersproducts { get; } = new List<Ordersproduct>();
}
