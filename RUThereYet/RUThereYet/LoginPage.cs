using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace RUThereYet
{
    public class LoginPage : ContentPage
    {
        public LoginPage(ILoginManager ilm)
        {

            this.BackgroundColor = Color.FromHex("007579");
            this.BackgroundImage = "loginBack22x.png";

            var button = new Button
            {
                Text = "Login",
                BackgroundColor = Color.FromHex("007579"),
                BorderColor = Color.FromHex("FFFFFF"),
                BorderWidth = 2,
                TextColor = Color.FromHex("FFFFFF"),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            var registerButton = new Button
            {
                Text = "Create Account",
                BackgroundColor = Color.FromHex("007579"),
                BorderColor = Color.FromHex("FFFFFF"),
                BorderWidth = 2,
                TextColor = Color.FromHex("FFFFFF"),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            registerButton.Clicked += OnRegisterButtonClicked;

            var forgotButton = new Button
            {
                Text = "Forgot Account Details",
                BackgroundColor = Color.FromHex("007579"),
                BorderColor = Color.FromHex("FFFFFF"),
                BorderWidth = 2,
                TextColor = Color.FromHex("FFFFFF"),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            var usernameField = new Entry
            {
                Text = "Username",
                BackgroundColor = Color.FromHex("5ebcaa"),
                TextColor = Color.FromHex("FFFFFF")
            };
            var passwordField = new Entry
            {
                Text = "Password",
                BackgroundColor = Color.FromHex("5ebcaa"),
                TextColor = Color.FromHex("FFFFFF")
            };

            //usernameField.Completed += (s, e) =>
            usernameField.Focused += (s, e) =>
            {
                //DisplayAlert("UI Error", "Clicked into Field.", "OK");
                if (usernameField.Text == "Username")
                {
                    usernameField.Text = "";
                }
            };
            passwordField.Focused += (s, e) =>
            {
                //DisplayAlert("UI Error", "Clicked into Field.", "OK");
                if (passwordField.Text == "Password")
                {
                    passwordField.Text = "";
                }
            };
            button.Clicked += (sender, e) => {
                //ilm.ShowMainPage();
                if (usernameField.Text == "" || usernameField.Text == "Username")
                {
                    DisplayAlert("Login Error", "Please enter you username and try again.", "OK");
                }
                else if (passwordField.Text == "" || passwordField.Text == "Password")
                {
                    DisplayAlert("Login Error", "Please enter you password and try again.", "OK");
                }
                else
                {
                    //string loginStatus =  App.Login(usernameField, passwordField);
                    DisplayAlert("Login Error", "Your username and password are incorrect, please try again.", "OK");
                }


            };

            //async registerButton.Clicked += (sender, e) =>
            async void OnRegisterButtonClicked(object sender, EventArgs e)
            {
                //ilm.ShowMainPage();
                var page = new CreateAccount(ilm);
                NavigationPage.SetHasNavigationBar(page, false);
                //CreateAccount createAccount = new CreateAccount(ilm);
                // this. = new NavigationPage(createAccount);
                //ilm.ShowCreateAccountPage();
                await Navigation.PushAsync(page);
            };

            forgotButton.Clicked += (sender, e) =>
            {
                //ilm.ShowMainPage();
                //CreateAccount createAccount = new CreateAccount();
                // this. = new NavigationPage(createAccount);
                ilm.ShowForgotPassword();
            };

            this.Content = new ScrollView
            {
                HorizontalOptions = LayoutOptions.Fill,
                Orientation = ScrollOrientation.Vertical,


                Content = new StackLayout
                {
                    Spacing = 3,
                    Padding = new Thickness(3, 0, 3, 3),
                    Children = {
                    new Image { Source = "logoPin2x.png", Scale = 0.75  },
                    new Image { Source = "logoChat2x.png", Scale = 0.75  },
					//new Label { Text = "Username" },
					usernameField,
					//new Label { Text = "Password" },
					passwordField,
                    button,
                    registerButton,
                    forgotButton
                }
                }

            };

        }
    }
}
