using RUThereYet.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace RUThereYet
{
    public partial class App : Application
    {
        static ILoginManager loginManager;
        public static bool IsUserLoggedIn { get; set; }

        public App()
        {
            MobileCenter.Start("android=a144ccbc-67d1-4d64-a5bd-c7dffa8fec0b;" +
                   "uwp={Your UWP App secret here};" +
                   "ios=fb89d881-69c7-4a8a-af97-e7e6924db00f",
                   typeof(Analytics), typeof(Crashes));

            InitializeComponent();

            //SetMainPage();
            //GetLoginPage(loginManager);
            ILoginManager ilm = loginManager;
            if (!IsUserLoggedIn)
            {
                //NavigationPage.SetHasNavigationBar(page, false);
                //MainPage = new NavigationPage(new LoginPage(ilm));
                var page = new LoginPage(ilm);
                NavigationPage.SetHasNavigationBar(page, false); // call this method every time before you push a page (no title bar)
                MainPage = new NavigationPage(page);


            }
            else
            {
                //MainPage = new NavigationPage(new RUThereYet.MainPage());
            }
        }

        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = Xamarin.Forms.Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Xamarin.Forms.Device.OnPlatform("tab_about.png",null,null)
                    },
                }
            };
            //GetLoginPage(loginManager);
        }
        public static Page GetLoginPage(ILoginManager ilm)
        {
            loginManager = ilm;
            return new LoginPage(ilm);
        }
        public static Page GetMainPage()
        {
            return new HomePage();
        }
        public static Page GetCreateAccountPage(ILoginManager ilm)
        {
            loginManager = ilm;
            return new CreateAccount(ilm);
        }
        public static Page GetForgotPassword(ILoginManager ilm)
        {
            loginManager = ilm;
            return new ForgotPassword(ilm);
        }
        public static void Logout()
        {
            loginManager.Logout();
        }
        public static void Login()
        {
            loginManager.Login();
        }
    }
}
