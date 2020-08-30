using System;
using HMRecipies.Models;

using Xamarin.Forms;
namespace HMRecipies.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                SetProperty(ref _username, value);
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                EnableLogin = value != String.Empty;
                SetProperty(ref _password, value);
            }
        }
        private bool _enableLogin;
        public bool EnableLogin
        {
            get { return _enableLogin; }
            set
            {
                SetProperty(ref _enableLogin, value);
            }
        }
        private string _loginMessage;
        public string LoginMessage
        {
            get { return _loginMessage; }
            set
            {
                SetProperty(ref _loginMessage, value);
            }
        }
        public LoginViewModel()
        {
            

        }
        bool AreCredentialsCorrect(User user)
        {
            return user.Username == Constants.Constants.adimUsername  && user.Password == Constants.Constants.adminPassword;
        }
        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }

        private void Login()
        {
            var user = new User
            {
                Username = Username,
                Password = Password
            };

            if (AreCredentialsCorrect(user))
            {
                App.IsUserLoggedIn = true;
                App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                App.Current.MainPage = new NavigationPage(new Views.HomeView()) {
                    BarBackgroundColor = Color.FromHex("#FFFFFF"),
                    BarTextColor = Color.White
                };

            }
            else
            {
                App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct U sername and Password", "OK");
                LoginMessage = "Login failed";
                Password = string.Empty;
            }
        }
    }
}
