using System;
using System.Collections.Generic;

namespace diplombee.Model;

public partial class Client
{
    public int Idclients { get; set; }

    public string NameClient { get; set; } = null!;

    public string SurnameClient { get; set; } = null!;

    public string PatronomycClient { get; set; } = null!;

    public string? PhoneClient { get; set; }

    public string LoginClient { get; set; } = null!;

    public string PasswordClient { get; set; } = null!;

   // public DateOnly Birthday { get; set; }
}
