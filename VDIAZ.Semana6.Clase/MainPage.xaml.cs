using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using VDIAZ.Semana6.Clase.Model;
using Xamarin.Forms;
using VDIAZ.Semana6.Clase.Utils;

namespace VDIAZ.Semana6.Clase
{
    public partial class MainPage : ContentPage
    {
        private string url = Constant.Services.SERVICE_USERS;
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<User> data;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(url);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(content);
            data = new ObservableCollection<User>(users);
            lsUSers.ItemsSource = data;
        }

        private async void ViewCell_Tapped(object sender, EventArgs e)
        {
            User user = (User) lsUSers.SelectedItem;
            if (user != null)
            {
                await Navigation.PushAsync(new Users(user));
            }
            //DisplayAlert("tapped", "Selected: " + user.Name, "Ok");
        }

        private async void btnNew_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Users(null));
        }
    }
}
