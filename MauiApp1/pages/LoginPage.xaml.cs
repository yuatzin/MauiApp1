using MauiApp1.Generic;
using MauiApp1.Model;

namespace MauiApp1.pages;

public partial class LoginPage : ContentPage
{
    public LoginModel oLoginModel { get; set; }

    public LoginPage()
	{
		InitializeComponent();
		oLoginModel=new LoginModel();
		BindingContext = this;
	}
	private async void btnIngresar_Clicked(object sender, EventArgs e)
	{
		int idusuario = await ClientHttp.GetInt("https://localhost:7193/swagger/index.html", "/api/LoginPage/" + oLoginModel.nombreusuario
			+ "/" + oLoginModel.contra);
		if (idusuario == 0) {

			Application.Current.MainPage.DisplayAlert("Error", "Usuario o contraseña incorrecta", "Cancelar");
		}
		else {
			Application.Current.MainPage=new PrincipalPage();
        }


    }
}