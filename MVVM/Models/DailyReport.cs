﻿using System;
using System.Collections.Generic;

namespace Cashbox.MVVM.Models;

public partial class DailyReport
{
    public int Id { get; set; }

    public DateOnly Data { get; set; }

    public TimeOnly OpenTime { get; set; }

    public TimeOnly CloseTime { get; set; }

    public int UserId { get; set; }

    public double Proceeds { get; set; }

    public virtual AutoDreport? AutoDreport { get; set; }

    public virtual User User { get; set; } = null!;
}
