using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mypro
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            
            buttonCancel.Clicked += async (object sender, EventArgs e) => {

                
                if (Device.OS == TargetPlatform.Android)
                {
                    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                }


            };

            buttonForgot.Clicked += async (object sender, EventArgs e) => {


                Device.OpenUri(new Uri("https://www.anadolu.edu.tr/e-posta/sifre-islemleri"));


            };
            buttonLogin.Clicked += async (object sender, EventArgs e) => {

                ((App)Application.Current).MainPage = new Page1();


            };
        }
    }
}
