using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DesafioVibe.Views
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void btnProfileClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }
    }
}
