using System;
using DesafioVibe.ViewModels;
using MonkeyCache.LiteDB;
using Xamarin.Forms;

namespace DesafioVibe.Views
{
    public partial class ProfilePage : ContentPage
    {
        ProfileViewModel profileViewModel;
        public ProfilePage()
        {
            profileViewModel = new ProfileViewModel();
            InitializeComponent();
            BindingContext = profileViewModel;
        }
    }
}
