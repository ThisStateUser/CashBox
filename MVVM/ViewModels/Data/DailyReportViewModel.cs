﻿using Cashbox.Core;
using Cashbox.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashbox.MVVM.ViewModels.Data
{
    public class DailyReportViewModel(DailyReport DailyReports) : ViewModelBase
    {
        private readonly DailyReport _dailyReport = DailyReports;

        public static async Task<DailyReportViewModel?> StartShift(DateOnly date, TimeOnly time) => await DailyReport.StartShift(date, time);
        public static async Task<DailyReportViewModel?> EndShift(DateOnly date, TimeOnly? time, double fulltransit, double processed) => await DailyReport.EndShift(date, time, fulltransit, processed);
        public static async Task<List<DailyReportViewModel>> GetPeriodReports(DateOnly startDate, DateOnly endDate) => await DailyReport.GetPeriodReports(startDate, endDate);
        public static DailyReport? CurrentShift => DailyReport.CurrentShift;
        public int Id => _dailyReport.Id;

        public DateOnly? Data 
        {
            get => _dailyReport.Data;
            set
            {
                _dailyReport.Data = value;
                OnPropertyChanged();
            }
        }

        public string? DataString => ((DateOnly)Data!).ToString("dd/MM/yyyy");
        
        public TimeOnly? OpenTime 
        {
            get => _dailyReport.OpenTime;
            set
            {
                _dailyReport.OpenTime = value;
                OnPropertyChanged();
            }
        }

        public TimeOnly? CloseTime 
        {
            get => _dailyReport.CloseTime;
            set
            {
                _dailyReport.CloseTime = value;
                OnPropertyChanged();
            }
        }

        public int UserId 
        {
            get => _dailyReport.UserId;
            set
            {
                _dailyReport.UserId = value;
                OnPropertyChanged();
            }
        }

        public double? Proceeds 
        {
            get => _dailyReport.Proceeds;
            set
            {
                _dailyReport.Proceeds = value;
                OnPropertyChanged();
            }
        }

        public double? FullTransit
        {
            get => _dailyReport.FullTransit;
            set
            {
                _dailyReport.FullTransit = value;
                OnPropertyChanged();
            }
        }

        public virtual AutoDreport? AutoDreport { get; set; }

        public virtual AutoDailyReportViewModel? AutoDreportVM { get; set; } = null;

        public virtual UserInfoViewModel UserInfoVM => new(_dailyReport.User.UserInfo!);

        public virtual ICollection<Order> Orders { get; set; } = [];

        public virtual User User { get; set; } = null!;
    }
}
