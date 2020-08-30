using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;
using Xamarin.Essentials;
using HMRecipies.Helpers;
using Autofac;
using System.Linq;

namespace HMRecipies
{
    public partial class App : Application
    {
        public static IContainer container;
        static readonly ContainerBuilder builder = new ContainerBuilder();
        public static bool IsUserLoggedIn { get; set; }
        public App()
        {
            InitializeComponent();
            SetupIOC();

            ThemeManager.ChangeTheme();
            
            if (!IsUserLoggedIn)
                MainPage = new Views.LoginView();
            else
                MainPage = new Views.HomeView();
        }
        private void SetupIOC()
        {
            RegisterAllViewModels();
            if (container == null)
                container = builder.Build();
        }
        private void RegisterAllViewModels() =>
            GetType().Assembly.GetTypes()
                      .Where(type => type.IsClass)
                      .Where(type => type.Name.EndsWith("ViewModel"))
                      .ForEach(viewModelType => builder.RegisterType(viewModelType).AsSelf().AsImplementedInterfaces());



        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
