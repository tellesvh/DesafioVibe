using Xamarin.Forms;
using DesafioVibe.Views;
using MonkeyCache.LiteDB;

namespace DesafioVibe
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Barrel.ApplicationId = "DesafioVibe";

            string userKey = Barrel.Current.Get<string>(Constants.USER_KEY);

            if (userKey != null)
            {
                MainPage = new NavigationPage(new ClientPage());
            } else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
