using System;
using MonkeyCache.LiteDB;
using Xamarin.Forms;

namespace DesafioVibe.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private void btnExitClicked(object sender, EventArgs e)
        {
            Barrel.Current.Empty(key: Constants.USER_KEY);
            Barrel.Current.Empty(key: Constants.USER_CPF);
            Navigation.PushAsync(new LoginPage());
        }
    }
}
