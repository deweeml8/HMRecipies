using System;
using System.Net;
using Newtonsoft.Json;
using Xamarin.Forms;
using HMRecipies.Models;


namespace HMRecipies.ViewModels
{
    public class HomeViewModel : BaseViewModel
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
        public Command UpdateCommand
        {
            get
            {
                return new Command(GetDataAsync);
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                SetProperty(ref _message, value);
            }
        }
        private void Logout()
        {
            App.IsUserLoggedIn = false;
            App.Current.MainPage.DisplayAlert("Logout Success", "You have successfully logout HM Recipes", "Ok");
            App.Current.MainPage = new Views.LoginView();

        }
        public void GetDataAsync()
        {
            Helpers.UpdateRecipesHelper.GetRecipeJson();
        }
        
    }
}
