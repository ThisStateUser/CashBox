﻿using Cashbox.Core;
using Cashbox.Core.Commands;
using Cashbox.MVVM.Models;
using Cashbox.MVVM.ViewModels.Data;
using Cashbox.Service;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace Cashbox.MVVM.ViewModels
{
    public class LoadingViewModel : ViewModelBase
    {
        #region Props

        private string _title = string.Empty;
        [Required(AllowEmptyStrings = false)]
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        private int _maxProgress = 0;
        public int MaxProgress
        {
            get => _maxProgress;
            set => Set(ref _maxProgress, value);
        }

        private Visibility _elementProgress = Visibility.Visible;
        public Visibility ElementProgress
        {
            get => _elementProgress;
            set => Set(ref _elementProgress, value);
        }

        private Visibility _elementError = Visibility.Collapsed;
        public Visibility ElementError
        {
            get => _elementError;
            set => Set(ref _elementError, value);
        }

        private int _progressLoadingApp = 0;
        public int ProgressLoadingApp
        {
            get => _progressLoadingApp;
            set => Set(ref _progressLoadingApp, value);
        }

        private string _progressLoadingAppText = string.Empty;
        [Required(AllowEmptyStrings = false)]
        public string ProgressLoadingAppText
        {
            get => _progressLoadingAppText;
            set => Set(ref _progressLoadingAppText, value);
        }

        #endregion

        #region Navigation
        private INavigationService? _navigationService;
        public INavigationService? NavigationService
        {
            get => _navigationService;
            set => Set(ref _navigationService, value);
        }
        #endregion

        #region ChechApp
        public async Task<bool> CheckApp(int maxProg)
        {
            MaxProgress = maxProg;
            int mainDelay = 100;
            int secondDelay = 300;

            SetStatus("Поиск базы данных...", "loading", 1);
            if (CashBoxDataContext.Context.Database.EnsureCreated())
            {
                SetStatus("Создаю новую базу данных", "loading", 1);
                await Task.Delay(secondDelay);
            }
            await Task.Delay(mainDelay);

            SetStatus("Проверка таблицы \"Roles\"", "loading", 2);
            if (!CashBoxDataContext.Context.Roles.Any())
            {
                SetStatus("Заполняю таблицу \"Roles\" ", "loading", 2);
                await RoleViewModel.GetRoles();
                await Task.Delay(secondDelay);
            }
            await Task.Delay(mainDelay);

            SetStatus("Проверка таблицы \"PaymentMethod\"", "loading", 3);
            if (CashBoxDataContext.Context.PaymentMethods.Count() != 3)
            {
                SetStatus("Заполняю таблицу \"PaymentMethod\" ", "loading", 3);
                await PaymentMethodViewModel.GetMethods();
                await Task.Delay(secondDelay);
            }
            await Task.Delay(mainDelay);

            SetStatus("Проверка таблицы \"Users\"", "loading", 4);
            if (!CashBoxDataContext.Context.Users.Any())
            {
                SetStatus("Создаю администратора по умолчанию", "loading", 4);
                await UserViewModel.CreateUser(111111, "Name", "Surname", "Patronymic", "location", "phone", (await RoleViewModel.GetRoles())[0]);
                await Task.Delay(secondDelay);
                AppCommand.InfoMessage("Пин-Код: 111111 \nЕго можно изменить позже во вкладке пользователи.", "Данные администратора");
            }
            await Task.Delay(mainDelay);

            SetStatus("Проверка таблицы \"UserInfo\"", "loading", 5);
            if (!CashBoxDataContext.Context.UserInfos.Any())
            {
                SetStatus("Некорректно заполнена таблица \"UserInfo\" ", "error");
                return false;
            }
            await Task.Delay(mainDelay);

            SetStatus("Проверка таблицы \"AppSetting\" и \"MoneyBox\"", "loading", 6);
            if (!CashBoxDataContext.Context.AppSettings.Any() && !CashBoxDataContext.Context.MoneyBoxes.Any())
            {
                SetStatus("Создаю настройки по умолчанию", "loading", 6);
                await AppSettingsViewModel.CreateSetting();
                await MoneyBoxViewModel.CreateBox();
                await Task.Delay(secondDelay);
                AppCommand.InfoMessage("Зарплата за выход: 1000 ₽ \nДенег в кассе: 0 \nЭти данные можно изменить позже в настройках приложения.", "Данные приложения");
            }
            await Task.Delay(mainDelay);

            SetStatus("Загрузка базы данных в локальный кэш", "loading", 7);
            CashBoxDataContext.Context.AppSettings.Load();
            CashBoxDataContext.Context.AuthHistories.Load();
            CashBoxDataContext.Context.AutoDreports.Load();
            CashBoxDataContext.Context.ComingProducts.Load();
            CashBoxDataContext.Context.DailyReports.Load();
            CashBoxDataContext.Context.MoneyBoxes.Load();
            CashBoxDataContext.Context.Orders.Load();
            CashBoxDataContext.Context.OrderProducts.Load();
            CashBoxDataContext.Context.PaymentMethods.Load();
            CashBoxDataContext.Context.Products.Load();
            CashBoxDataContext.Context.ProductCategories.Load();
            CashBoxDataContext.Context.Refunds.Load();
            CashBoxDataContext.Context.Roles.Load();
            CashBoxDataContext.Context.Stocks.Load();
            CashBoxDataContext.Context.UserInfos.Load();
            CashBoxDataContext.Context.Users.Load();
            await Task.Delay(mainDelay);

            await Task.Delay(mainDelay);
            SetStatus("Запуск", "loading", 8);
            await Task.Delay(mainDelay);

            return true;
        }

        public void SetStatus(string checkElement, string status, int progress = 0)
        {
            ProgressLoadingApp = progress;
            ProgressLoadingAppText = checkElement;
            switch (status)
            {
                case "loading":
                    ElementProgress = Visibility.Visible;
                    ElementError = Visibility.Collapsed;
                    break;
                default:
                    Title = "Ошибка";
                    ElementProgress = Visibility.Collapsed;
                    ElementError = Visibility.Visible;
                    break;
            }
        }
        #endregion

        #region Commands
        public RelayCommand CloseApplicationCommand { get; set; }
        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion


        public LoadingViewModel(INavigationService navService)
        {
            CloseApplicationCommand = new RelayCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            Title = "Загрузка приложения";
            Task.Run(async () =>
            {
                try
                {
                    bool result = await CheckApp(8);
                    if (!result)
                        return;
                    NavigationService = navService;
                    NavigationService.NavigateTo<AuthViewModel>();
                }
                catch (AggregateException)
                {
                    SetStatus("База данных не найдена", "error");
                    return;
                }
                catch (Exception ex)
                {
                    AppCommand.ErrorMessage($"{ex.InnerException} \n{ex.Message} \n{ex.Source} \n{ex.HResult} \n{ex.Data}");
                    SetStatus("Критическая ошибка", "error");
                }
            });
        }
    }
}
