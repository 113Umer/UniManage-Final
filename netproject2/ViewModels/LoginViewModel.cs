using System.Linq;
using System.Windows;
using System.Windows.Input;
using netproject2.Commands;
using netproject2.Data;
using netproject2.Models;
using netproject2.Views;

namespace netproject2.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _email;
        private string _password;
        private readonly AppDbContext _dbContext;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }


        public LoginViewModel()
        {
            _dbContext = new AppDbContext(); // Assuming AppDbContext is properly configured
            LoginCommand = new RelayCommand(Login);
            //RegisterCommand = new RelayCommand(RegisterUser);
            RegisterCommand = new RelayCommand(OpenSignUpView);


        }
        private void OpenSignUpView(object parameter)
        {
            var signUpView = new SignUp();
            signUpView.Show();
        }
        // Register user logic from register button with only pswd and email
        /*
        private void RegisterUser(object parameter)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Email and password cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check if user already exists
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Email == Email);
            if (existingUser != null)
            {
                MessageBox.Show("User already exists. Please try logging in.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create a new user
            var newUser = new User
            {
                Email = Email,
                Password = Password // In production, hash the password before saving
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            // Navigate to SubjectsView
            var subjectsView = new SubjectsView(newUser); // Pass the new user
            subjectsView.Show();
            Application.Current.Windows[0].Close();



        }
        */
        private void Login()
        {
            // Check the database for the user credentials
            var user = _dbContext.Students.FirstOrDefault(u => u.Email == Email && u.Password == Password);

            if (user != null)
            {
                // If user is found, pass the user object to SubjectsView
                var subjectsView = new SubjectsView(user);
                subjectsView.Show();

                // Close the login window
                Application.Current.Windows[0].Close();
            }
            else
            {
                // Display an error message
                MessageBox.Show("Invalid email or password. Please try again.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
