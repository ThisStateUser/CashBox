﻿using Cashbox.Core;
using Cashbox.Core.Commands;
using Cashbox.MVVM.ViewModels.Data;
using Cashbox.Service;
using System.Windows;

namespace Cashbox.MVVM.ViewModels.Employee
{
    public class EMainViewModel : ViewModelBase
    {
        #region Props

        public static UserViewModel? User { get => Models.User.CurrentUser; }
        #region isBoolView
        private bool _isShiftView = true;
        public bool IsShiftView
        {
            get => _isShiftView;
            set => Set(ref _isShiftView, value);
        }

        private bool _isCashRegisterView = false;
        public bool IsCashRegisterView
        {
            get => _isCashRegisterView;
            set
            {
                if (value == true && User.DailyReports.FirstOrDefault(x => x.Data == DateOnly.FromDateTime(DateTime.Today) && x.CloseTime == null) == null)
                {
                    AppCommand.WarningMessage("Смена не открыта");
                    return;
                }
                _isCashRegisterView = value;
            }
        }
        #endregion

        #endregion

        #region Commands

        public RelayCommand NavigateSubViewCommand { get; set; }
        private bool CanNavigateSubViewCommandExecute(object p) => true;
        private void OnNavigateSubViewCommandExecuted(object p)
        {
            if (IsShiftView)
                SubNavigationService?.NavigateTo<ShiftViewModel>();
            if (IsCashRegisterView)
                SubNavigationService?.NavigateTo<CashRegisterViewModel>();
        }

        public RelayCommand LogOutCommand { get; set; }
        private bool CanLogOutCommandExecute(object p) => true;
        private void OnLogOutCommandExecuted(object p)
        {
            if (AppCommand.QuestionMessage("Вы уверены, что хотите выйти?") == MessageBoxResult.Yes)
            {
                UserViewModel.LogOut();
                NavigationService?.NavigateTo<AuthViewModel>();
            }
        }

        #endregion

        #region Navigation

        public override void OnLoad()
        {
            IsShiftView = true;
            IsCashRegisterView = false;
            NavigateSubViewCommand.Execute(this);
        }

        private ISubNavigationService? _subNavigationService;
        public ISubNavigationService? SubNavigationService
        {
            get => _subNavigationService;
            set => Set(ref _subNavigationService, value);
        }

        private INavigationService? _NavigationService;
        public INavigationService? NavigationService
        {
            get => _NavigationService;
            set => Set(ref _NavigationService, value);
        }

        #endregion

        public EMainViewModel(ISubNavigationService subNavService, INavigationService navService)
        {
            SubNavigationService = subNavService;
            NavigationService = navService;
            NavigateSubViewCommand = new RelayCommand(OnNavigateSubViewCommandExecuted, CanNavigateSubViewCommandExecute);
            NavigateSubViewCommand.Execute(this);
            LogOutCommand = new RelayCommand(OnLogOutCommandExecuted, CanLogOutCommandExecute);
        }
    }
}
