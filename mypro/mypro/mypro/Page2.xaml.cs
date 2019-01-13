using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mypro
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page2 : ContentPage
	{
        private ArrayList dersList = new ArrayList();

        public Page2 ()
		{
			InitializeComponent ();

            int index = DependencyService.Get<ISharPref>().getIndex("index");
            for (int i = 0; i < index; i++)
            {
                
                string item = DependencyService.Get<ISharPref>().getItem(i + "");
                dersList.Add(item);

                var label = new Label { Text ="- " + item, TextDecorations = TextDecorations.Underline , FontSize=20, TextColor = Color.Black };
                label.Margin = new Thickness(5, 0, 0, 0);
                
                var gest = new TapGestureRecognizer();
                gest.Tapped += (s, e) =>
                {
                    ((App)Application.Current).MainPage = new TabbedPage1(item);
                };
                label.GestureRecognizers.Add(gest);
                holderStack.Children.Add(label);
                
            }

            var But = new Button { Text = "BACK",HeightRequest=40,CornerRadius=7,TextColor= Color.White, VerticalOptions=LayoutOptions.EndAndExpand };
            But.BackgroundColor = Color.FromHex("#b30012");
            But.Margin = new Thickness(50, 0, 50, 7);
            But.Clicked += (s, e) =>
            {
                ((App)Application.Current).MainPage = new Page1();
            };

            outStack.Children.Add(But);
        }

	}
}