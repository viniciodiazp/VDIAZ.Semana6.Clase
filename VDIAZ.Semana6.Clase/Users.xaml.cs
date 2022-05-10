using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using VDIAZ.Semana6.Clase.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;

namespace VDIAZ.Semana6.Clase
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Users : ContentPage
    {
        private const string url = "http://172.20.10.7:8080/api/users";
        private readonly WebClient client = new WebClient();
        private ObservableCollection<User> data;

        private Users user;
        bool isNew = false;
        public Users(Users user)
        {
            if (user == null)
            {
                isNew = true;
            } else
            {
                this.user = user;
            }
            InitializeComponent();

        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                user.Id = Convert.ToInt32(txtId.Text);
                user.Name = txtName.Text;
                user.BirthDate = txtBirthDate.Text;
                user.Gender = txtGender.Text;
                user.Height = Convert.ToDouble(txtHeight.Text);
                user.Weight = Convert.ToDouble(txtWeight.Text);
                user.Email = txtEmail.Text;

                var payload = new System.Collections.Specialized.NameValueCollection();

                payload.Add("id", txtId.Text);
                payload.Add("email", txtEmail.Text);
                payload.Add("name", txtName.Text);
                payload.Add("gender", txtGender.Text);
                payload.Add("birthDate", txtBirthDate.Text);
                payload.Add("height", txtHeight.Text);
                payload.Add("weight", txtWeight.Text);

                client.Headers.Add("Content-Type", "application/json");
                
                client.UploadValues(url, "POST", payload);
                DisplayAlert("App", "Guardado con éxito", "Aceptar");
            } catch (Exception exception){
                Console.Write(exception);
                DisplayAlert("App", "Error", "Aceptar");
            }
        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {

        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {

        }
    }
}