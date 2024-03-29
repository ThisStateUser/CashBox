﻿using System;
using System.Collections.Generic;

namespace Cashbox.MVVM.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Pin { get; set; }

    public virtual ICollection<AuthHistory> AuthHistories { get; set; } = new List<AuthHistory>();

    public virtual ICollection<DailyReport> DailyReports { get; set; } = new List<DailyReport>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual UserInfo? UserInfo { get; set; }
}
