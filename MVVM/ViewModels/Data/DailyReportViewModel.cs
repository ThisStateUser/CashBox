﻿using Cashbox.Core;
using Cashbox.MVVM.Models;

namespace Cashbox.MVVM.ViewModels.Data
{
    public class DailyReportViewModel(DailyReport DailyReports) : ViewModelBase
    {
        private readonly DailyReport _dailyReport = DailyReports;

        public static DailyReportViewModel? GetCurrentShift() => DailyReport.CurrentShift;
        public static async Task<DailyReportViewModel?> StartShift(DateOnly date, TimeOnly time) => await DailyReport.StartShift(date, time);
        public static async Task<DailyReportViewModel?> EndShift(DateOnly date, TimeOnly? time, double processed, int userId) => await DailyReport.EndShift(date, time, processed, userId);
        public static async Task<List<DailyReportViewModel>> GetPeriodReports(DateOnly startDate, DateOnly endDate) => await DailyReport.GetPeriodReports(startDate, endDate);
        public static async Task<DailyReportViewModel?> GetReport(DateOnly date) => await DailyReport.GetReport(date);
        public static async Task<List<DailyReportViewModel>> GetNotCloseReports() => await DailyReport.GetNotCloseReports();

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
        public string? OpenTimeString => _dailyReport.OpenTime.ToString();
        public string? CloseTimeString 
        {
            get
            {
                if (_dailyReport.CloseTime == null)
                    return "Смена открыта";
                return _dailyReport.CloseTime.ToString();
            }
        }


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

        public double CashOnStart
        {
            get => _dailyReport.CashOnStart;
            set
            {
                _dailyReport.CashOnStart = value;
                OnPropertyChanged();
            }
        }

        public int RefundCount => _dailyReport.Refunds.Where(x => x.IsPurchased == true).Count();
        public int CrackCount => _dailyReport.Refunds.Where(x => x.IsPurchased == false && x.BuyDate == null).Count();
        public int DrawCount => _dailyReport.Refunds.Where(x => x.IsPurchased == false && x.BuyDate != null).Count();

        public virtual AutoDreport? AutoDreport { get; set; }

        public virtual AutoDailyReportViewModel? AutoDreportVM { get => new(_dailyReport.AutoDreport!); }

        public virtual UserInfoViewModel UserInfoVM => new(_dailyReport.User.UserInfo!);

        public virtual ICollection<Order> Orders { get => _dailyReport.Orders; }
        public virtual ICollection<Refund> Refunds { get => _dailyReport.Refunds; }
        public virtual User User { get => _dailyReport.User; }
    }
}
