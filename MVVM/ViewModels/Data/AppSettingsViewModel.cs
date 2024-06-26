﻿using Cashbox.Core;
using Cashbox.MVVM.Models;

namespace Cashbox.MVVM.ViewModels.Data
{
    public class AppSettingsViewModel(AppSettings appSettings) : ViewModelBase
    {
        private readonly AppSettings _appSettings = appSettings;

        public static async Task<bool> EditSetting(int salary = 0) => await AppSettings.EditSetting(salary);
        public static async Task<bool> CreateSetting() => await AppSettings.CreateSetting();
        public static AppSettings Settings => AppSettings.Settings;

        public int Id => _appSettings.Id;

        public int Salary
        {
            get => _appSettings.Salary;
            set
            {
                _appSettings.Salary = value;
                OnPropertyChanged();
            }
        }
    }
}
