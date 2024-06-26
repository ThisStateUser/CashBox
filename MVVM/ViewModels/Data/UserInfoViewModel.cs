﻿using Cashbox.Core;
using Cashbox.MVVM.Models;
using System.Windows;
using System.Windows.Media;

namespace Cashbox.MVVM.ViewModels.Data
{
    public class UserInfoViewModel : ViewModelBase
    {
        private readonly UserInfo _userInfo;
        public UserInfoViewModel(UserInfo userInfo)
        {
            _userInfo = userInfo;
            Role = new RoleViewModel(userInfo.Role);
            SetFullName();
        }

        public static async Task<UserInfoViewModel> DeactivateUser(int userId) => await UserInfo.DeactivateUser(userId);
        public static async Task<UserInfoViewModel> ActivateUser(int userId) => await UserInfo.ActivateUser(userId);

        public void SetFullName()
        {
            FullName = $"{_userInfo.Surname} {_userInfo.Name} {_userInfo.Patronymic}";
            ShortName = $"{_userInfo.Surname} {_userInfo.Name[0]}. {_userInfo.Patronymic[0]}.";
        }

        private string _fullName = string.Empty;
        public string FullName
        {
            get => _fullName;
            private set => Set(ref _fullName, value);
        }

        private string _shortName = string.Empty;
        public string ShortName
        {
            get => _shortName;
            private set => Set(ref _shortName, value);
        }

        public int UserId => _userInfo.UserId;

        public string Name
        {
            get => _userInfo.Name;
            set
            {
                _userInfo.Name = value;
                SetFullName();
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get => _userInfo.Surname;
            set
            {
                _userInfo.Surname = value;
                SetFullName();
                OnPropertyChanged();
            }
        }

        public string Patronymic
        {
            get => _userInfo.Patronymic;
            set
            {
                _userInfo.Patronymic = value;
                SetFullName();
                OnPropertyChanged();
            }
        }

        public string Location
        {
            get => _userInfo.Location;
            set
            {
                _userInfo.Location = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get => _userInfo.Phone;
            set
            {
                _userInfo.Phone = value;
                OnPropertyChanged();
            }
        }

        public bool IsActive
        {
            get => _userInfo.IsActive;
            set
            {
                _userInfo.IsActive = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush BackGround
        {
            get
            {
                if (IsActive)
                    return (SolidColorBrush)Application.Current.Resources["BasicW"];
                return (SolidColorBrush)Application.Current.Resources["HoverW"];

            }
        }

        public double Salary
        {
            get => _userInfo.Salary;
            set
            {
                _userInfo.Salary = value;
                OnPropertyChanged();
            }
        }

        public int RoleId
        {
            get => _userInfo.RoleId;
            set
            {
                _userInfo.RoleId = value;
                OnPropertyChanged();
            }
        }

        public RoleViewModel RoleVM
        {
            get => new(_userInfo.Role);
            set
            {
                _userInfo.RoleId = value.Id;
                OnPropertyChanged();
            }
        }

        public RoleViewModel Role { get; }
    }
}
