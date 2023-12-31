﻿using System;
using System.Collections.Generic;

namespace Cashbox.MVVM.Models;

public partial class AutoDreport
{
    public int DailyReportId { get; set; }

    public double Salary { get; set; }

    public double AutoProceeds { get; set; }

    public double Forfeit { get; set; }

    public double Award { get; set; }

    public virtual DailyReport DailyReport { get; set; } = null!;
}
