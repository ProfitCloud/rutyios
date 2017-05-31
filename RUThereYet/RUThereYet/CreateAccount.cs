using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace RUThereYet
{
    public class CreateAccount : ContentPage
    {
        public CreateAccount(ILoginManager ilm)
        {
            this.BackgroundColor = Color.FromHex("007579");
            this.BackgroundImage = "loginBack2.png";
            var button = new Button
            {
                Text = "Register",
                BackgroundColor = Color.FromHex("007579"),
                BorderColor = Color.FromHex("FFFFFF"),
                BorderWidth = 2,
                TextColor = Color.FromHex("FFFFFF"),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            var registerButton = new Button
            {
                Text = "Cancel",
                BackgroundColor = Color.FromHex("007579"),
                BorderColor = Color.FromHex("FFFFFF"),
                BorderWidth = 2,
                TextColor = Color.FromHex("FFFFFF"),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            registerButton.Clicked += OnRegisterButtonClicked;

            var usernameField = new Entry
            {
                Text = "Choose a Username",
                BackgroundColor = Color.FromHex("5ebcaa"),
                TextColor = Color.FromHex("FFFFFF")
            };
            var passwordField = new Entry
            {
                Text = "Choose a Password",
                BackgroundColor = Color.FromHex("5ebcaa"),
                TextColor = Color.FromHex("FFFFFF")
            };
            var confirmPasswordField = new Entry
            {
                Text = "Confirm Password",
                BackgroundColor = Color.FromHex("5ebcaa"),
                TextColor = Color.FromHex("FFFFFF")
            };

            var emailAddressField = new Entry
            {
                Text = "Enter Your Email",
                BackgroundColor = Color.FromHex("5ebcaa"),
                TextColor = Color.FromHex("FFFFFF")
            };

            var mobileNumberField = new Entry
            {
                Text = "Enter Your Mobile Number",
                BackgroundColor = Color.FromHex("5ebcaa"),
                TextColor = Color.FromHex("FFFFFF")
            };

            //usernameField.Completed += (s, e) =>
            usernameField.Focused += (s, e) =>
            {
                //DisplayAlert("UI Error", "Clicked into Field.", "OK");
                if (usernameField.Text == "Choose a Username")
                {
                    usernameField.Text = "";
                }
            };
            passwordField.Focused += (s, e) =>
            {
                //DisplayAlert("UI Error", "Clicked into Field.", "OK");
                if (passwordField.Text == "Choose a Password")
                {
                    passwordField.Text = "";
                }
            };
            confirmPasswordField.Focused += (s, e) =>
            {
                //DisplayAlert("UI Error", "Clicked into Field.", "OK");
                if (confirmPasswordField.Text == "Confirm Password")
                {
                    confirmPasswordField.Text = "";
                }
            };
            emailAddressField.Focused += (s, e) =>
            {
                //DisplayAlert("UI Error", "Clicked into Field.", "OK");
                if (emailAddressField.Text == "Enter Your Email")
                {
                    emailAddressField.Text = "";
                }
            };
            mobileNumberField.Focused += (s, e) =>
            {
                //DisplayAlert("UI Error", "Clicked into Field.", "OK");
                if (mobileNumberField.Text == "Enter Your Mobile Number")
                {
                    mobileNumberField.Text = "";
                }
            };
            button.Clicked += (sender, e) =>
            {
                //ilm.ShowMainPage();
                if (usernameField.Text == "" || usernameField.Text == "Choose a Username")
                {
                    DisplayAlert("Create Error", "Please enter you username and try again.", "OK");
                }
                else if (passwordField.Text == "" || passwordField.Text == "Choose a Password")
                {
                    DisplayAlert("Create Error", "Please enter you password and try again.", "OK");
                }
                else if (emailAddressField.Text == "" || emailAddressField.Text == "Enter Your Email")
                {
                    DisplayAlert("Create Error", "Sorry an account already exists with that email address.", "OK");
                }
                else
                {
                    //string loginStatus =  App.Login(usernameField, passwordField);
                    DisplayAlert("Create Error", "Sorry an account already exists with that email address.", "OK");
                }

            };

            async void OnRegisterButtonClicked(object sender, EventArgs e)
            {
                //ilm.ShowMainPage();
                //CreateAccount createAccount = new CreateAccount();
                // this. = new NavigationPage(createAccount);
                //ilm.ShowMainPage();
                //ilm.Login();
                await Navigation.PopToRootAsync();
            };

            this.Content = new ScrollView
            {
                HorizontalOptions = LayoutOptions.Fill,
                Orientation = ScrollOrientation.Vertical,


                Content = new StackLayout
                {
                    Padding = new Thickness(6, 0, 6, 6),
                    Children = {
                    new Image { Source = "logoPin.png" },
                   // new Image { Source = "logoChat.png" },
					//new Label { Text = "Username" },
					usernameField,
					//new Label { Text = "Password" },
					passwordField,
                    confirmPasswordField,
                    emailAddressField,
                    mobileNumberField,
                    button,
                    registerButton
                }
                }

            };

        }
    }
}
