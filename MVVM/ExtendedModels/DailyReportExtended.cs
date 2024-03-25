﻿using Cashbox.Core;
using Cashbox.MVVM.ViewModels.Data;
using System.Windows;

namespace Cashbox.MVVM.Models
{
    public partial class DailyReport
    {
        public DailyReport() { }

        private static DailyReport? _currentShift = CashBoxDataContext.Context.DailyReports.FirstOrDefault(x => x.Data == DateOnly.FromDateTime(DateTime.Today) && x.UserId == UserViewModel.GetCurrentUser().Id);
        public static DailyReport? CurrentShift => _currentShift;

        public static async Task<DailyReportViewModel?> StartShift(DateOnly date, TimeOnly time)
        {
            if (CashBoxDataContext.Context.DailyReports.FirstOrDefault(x => x.Data == DateOnly.FromDateTime(DateTime.Today) && x.UserId == UserViewModel.GetCurrentUser().Id && x.CloseTime != null) != null)
            {
                MessageBox.Show("Смена закрыта, открыть ее можно будет на следующий день", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
                return null;
            }
            try
            {
                UserViewModel user = UserViewModel.GetCurrentUser();
                DailyReport dailyReport = new()
                {
                    Data = date,
                    OpenTime = time,
                    UserId = user.Id,
                };
                CashBoxDataContext.Context.Add(dailyReport);
                await CashBoxDataContext.Context.SaveChangesAsync();
                return new DailyReportViewModel(dailyReport);
            }
            catch (Exception ex)
            {
                AppCommand.ErrorMessage(ex.Message);
                return null;
            }

        }
        public static async Task<DailyReportViewModel?> EndShift(DateOnly date, TimeOnly? time, double Proceeds)
        {
            try
            {
                UserViewModel user = UserViewModel.GetCurrentUser();
                DailyReport DR = CashBoxDataContext.Context.DailyReports.FirstOrDefault(x => x.Data == date && x.UserId == user.Id);
                DR.CloseTime = time;
                DR.Proceeds = Proceeds;
                await MoneyBoxViewModel.UpdateMoney(Proceeds, 1);
                AutoDailyReportViewModel adreport = AutoDailyReportViewModel.GenEndShiftAuto(DR);
                await CashBoxDataContext.Context.SaveChangesAsync();
                return new(DR);
            }
            catch (Exception ex)
            {
                AppCommand.ErrorMessage(ex.Message);
                return new(null!);
            }
        }
    }
}