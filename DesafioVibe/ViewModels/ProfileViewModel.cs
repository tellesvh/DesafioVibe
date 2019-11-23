using System;
using System.ComponentModel;
using System.Globalization;
using DesafioVibe.Views;
using DesafioVibe.Webservice;
using MonkeyCache.LiteDB;
using Xamarin.Forms;

namespace DesafioVibe.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        RestService _restService;

        public ProfileViewModel()
        {
            _restService = new RestService();
            GetInfo();
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }

        private string cpf;
        public string CPF
        {
            get { return cpf; }
            set
            {
                cpf = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CPF"));
            }
        }

        private string birthday;
        public string Birthday
        {
            get { return birthday; }
            set
            {
                birthday = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Birthday"));
            }
        }

        private async void GetInfo()
        {
            UserResponse userResponse = await _restService.GetUserInfo();
            Name = userResponse.Name;
            CPF = string.Format(@"{0:000\.000\.000-00}", long.Parse(userResponse.CPF));
            Birthday = DateTime.Parse(userResponse.Birthday).ToShortDateString();
        }

        public Command ExitCommand
        {
            get
            {
                return new Command(Exit);
            }
        }

        private void Exit()
        {
            Barrel.Current.Empty(key: Constants.USER_KEY);
            Barrel.Current.Empty(key: Constants.USER_CPF);
            Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

    }
}
