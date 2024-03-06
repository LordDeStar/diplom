using System;
using System.Collections.Generic;

namespace diplombee.Model;

public partial class Manager
{
    public int Idmanagers { get; set; }

    public string LoginManager { get; set; } = null!;

    public string PasswordManager { get; set; } = null!;

    public string NameManager { get; set; } = null!;

    public string? SurnameManager { get; set; }

    public string? PatronomycManager { get; set; }

    public string? PhoneManager { get; set; }

    public DateOnly? BirthdayManager { get; set; }
}
