using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using netproject2.Commands;
using netproject2.Data;
using netproject2.Models;

namespace netproject2.ViewModels
{
    public class SignUpViewModel : BaseViewModel, IDataErrorInfo
    {
        private string _fullName;
        private string _email;
        private string _password;
        private readonly AppDbContext _dbContext;
        private readonly RelayCommand _registerCommand;

        public string FullName
        {
            get => _fullName;
            set
            {
                SetProperty(ref _fullName, value);
                _registerCommand.RaiseCanExecuteChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                SetProperty(ref _email, value);
                _registerCommand.RaiseCanExecuteChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
                _registerCommand.RaiseCanExecuteChanged();
            }
        }

        public ICommand RegisterCommand => _registerCommand;
        public ICommand CancelCommand { get; }

        public Action CloseAction { get; set; }

        public SignUpViewModel()
        {
            _dbContext = new AppDbContext();
            _registerCommand = new RelayCommand(RegisterUser, CanRegisterUser);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void RegisterUser(object parameter)
        {
            if (!IsValid) return;

            var existingUser = _dbContext.Students.FirstOrDefault(s => s.Email == Email);
            if (existingUser != null)
            {
                MessageBox.Show("This email is already registered.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Student newUser = new Student
            {
                FullName = FullName,
                Email = Email,
                Password = Password
            };

            _dbContext.Students.Add(newUser);
            _dbContext.SaveChanges();

            MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            CloseAction?.Invoke();
        }

        private void Cancel(object parameter)
        {
            CloseAction?.Invoke();
        }

        private bool CanRegisterUser(object parameter) => IsValid;

        // IDataErrorInfo implementation
        public string Error => null;

        public string this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case nameof(FullName):
                        if (string.IsNullOrWhiteSpace(FullName))
                            return "Full Name is required.";
                        break;
                    case nameof(Email):
                        if (string.IsNullOrWhiteSpace(Email))
                            return "Email is required.";
                        if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                            return "Invalid email format.";
                        break;
                    case nameof(Password):
                        if (string.IsNullOrWhiteSpace(Password))
                            return "Password is required.";
                        if (Password.Length < 8)
                            return "Password must be at least 8 characters long.";
                        if (!Regex.IsMatch(Password, @"[A-Za-z]") || !Regex.IsMatch(Password, @"[0-9]"))
                            return "Password must contain both letters and numbers.";
                        break;
                }
                return null;
            }
        }

        private bool IsValid => string.IsNullOrEmpty(this[nameof(FullName)]) &&
                                string.IsNullOrEmpty(this[nameof(Email)]) &&
                                string.IsNullOrEmpty(this[nameof(Password)]);
    }
}
