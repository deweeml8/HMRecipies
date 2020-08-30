using System;
using Xamarin.Forms;

namespace HMRecipies.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
        }
        public Command LogoutCommand
        {
            get
            {
                return new Command(Logout);
            }
        }

        private void Logout()
        {
            App.IsUserLoggedIn = false;
            App.Current.MainPage.DisplayAlert("Logout Success", "You have successfully logout HM Recipes", "Ok");
            App.Current.MainPage = new Views.LoginView();

        }
    }
}
