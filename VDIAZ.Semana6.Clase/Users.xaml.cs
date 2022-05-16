using Newtonsoft.Json;
using System;
using VDIAZ.Semana6.Clase.Model;
using VDIAZ.Semana6.Clase.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VDIAZ.Semana6.Clase
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Users : ContentPage
    {
        private string url = Constant.Services.SERVICE_USERS;
        private RestExecutor restExecutor = new RestExecutor();

        private User user;
        private bool isNew = false;
        public Users(User user)
        {
            InitializeComponent();
            if (user == null)
            {
                isNew = true;
            } else
            {
                this.user = user;
                FillData(user);
            }
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                User user = BuildUser();

                string method = "POST";

                if (!isNew)
                {
                    method = "PUT";
                    url = url + "/" + user.Id.ToString();
                }

                string response = restExecutor.Execute(url,
                    method, JsonConvert.SerializeObject(user));
    
                DisplayAlert("App", "Guardado con éxito", "Aceptar");
            } catch (Exception exception){
                Console.Write(exception);
                DisplayAlert("App", "Error", "Aceptar");
            }
        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            try
            {
                User user = BuildUser();

                if (!isNew)
                {
                    url = url + "/" + user.Id.ToString();
                    string response = restExecutor.Execute(url,
                    "DELETE");
                }

                DisplayAlert("App", "Registro eliminado", "Aceptar");
            }
            catch (Exception exception)
            {
                Console.Write(exception);
                DisplayAlert("App", "Error", "Aceptar");
            }
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private User BuildUser()
        {
            User user = new User();
            user.Id = Convert.ToInt32(txtId.Text);
            user.Name = txtName.Text;
            user.BirthDate = txtBirthDate.Text;
            user.Gender = txtGender.Text;
            user.Height = Convert.ToDouble(txtHeight.Text);
            user.Weight = Convert.ToDouble(txtWeight.Text);
            user.Email = txtEmail.Text;
            return user;
        }

        private void FillData(User user)
        {
            txtId.Text = user.Id.ToString();
            txtName.Text = user.Name;
            txtBirthDate.Text = user.BirthDate;
            txtGender.Text = user.Gender;
            txtHeight.Text = user.Height.ToString();
            txtWeight.Text = user.Weight.ToString();
            txtEmail.Text = user.Email;
        }

    }
}