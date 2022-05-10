using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using VDIAZ.Semana6.Clase.Model;
using Xamarin.Forms;

namespace VDIAZ.Semana6.Clase
{
    public partial class MainPage : ContentPage
    {
        private const string url = "http://172.20.10.7:8080/api/users";
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

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            User user = (User) lsUSers.SelectedItem;
            DisplayAlert("tapped", "Selected: " + user.Name, "Ok");
        }

        private async void btnNew_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Users(null));
        }
    }
}
