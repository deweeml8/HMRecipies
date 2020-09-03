using Xamarin.Forms;
using HMRecipies.Models;
using System.Collections.Generic;

namespace HMRecipies.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            GetRecipeList();
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
                return new Command(UpdateRecipe);
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
        public List<Recipe> listOfRecipes;
        public List<Recipe> ListOfRecipes
        {
            get { return listOfRecipes; }
            set
            {

                listOfRecipes = value;
                
            }
        }

        private void Logout()
        {
            App.IsUserLoggedIn = false;
            App.Current.MainPage.DisplayAlert("Logout Success", "You have successfully logout HM Recipes", "Ok");
            App.Current.MainPage = new Views.LoginView();

        }
        public void UpdateRecipe()
        {
            Helpers.UpdateRecipesHelper.GetRecipeJson();
            GetRecipeList();
        }
        public void GetRecipeList()
        {
            ListOfRecipes = Helpers.DatabaseHelper.GetAllData();
        }

    }
}
