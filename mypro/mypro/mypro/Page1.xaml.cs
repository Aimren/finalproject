using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mypro
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{

        private ArrayList dersList = new ArrayList();

        public Page1 ()
		{
			InitializeComponent ();

            int index = DependencyService.Get<ISharPref>().getIndex("index");
            for(int i = 0; i < index; i++)
            {
                string item = DependencyService.Get<ISharPref>().getItem(i+"");
                dersList.Add(item);
            }
            addPickItems();
        }

        async void addPickItems()
        {
            HttpClient client = new HttpClient();

            string res = await client.GetStringAsync("http://ceng.eskisehir.edu.tr/Dersler.aspx");

            var doc = new HtmlDocument();
            doc.LoadHtml(res);

            

            var els = doc.GetElementbyId("ContentPlaceHolder1_tblDersler").Descendants("a");

            foreach (var element in els)
            {
                myPicker.Items.Add(element.InnerText);
                string dersIdS = element.Attributes.AttributesWithName("href").FirstOrDefault().Value;
                dersIdS = dersIdS.Substring(dersIdS.IndexOf("dersId=") + 7);
                int dersId;
                Int32.TryParse(dersIdS, out dersId);
                DependencyService.Get<ISharPref>().setDersId(element.InnerText, dersId);
                //result += (element.Attributes.AttributesWithName("href").FirstOrDefault().Value + "   " + element.InnerText + "\n\n");
            }
            
        }

        void PickerCtl_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (myPicker != null && myPicker.SelectedIndex <= myPicker.Items.Count)
            {
                var selecteditem = myPicker.Items[myPicker.SelectedIndex];
               // ((App)Application.Current).MainPage = new TabbedPage1();
            }
        }


        void OnDersEkle_Clicked(object sender, EventArgs e)
        {
            
            if(myPicker.SelectedIndex != -1)
            {
                dersList.Add(myPicker.SelectedItem);
                int index = DependencyService.Get<ISharPref>().getIndex("index");
                DependencyService.Get<ISharPref>().setItem(index + "", myPicker.SelectedItem.ToString());
                DependencyService.Get<ISharPref>().setIndex("index", ++index);
                DisplayAlert("Course", myPicker.SelectedItem.ToString() + " added succesfuly", "ok");
            }
            
        }

        void OnDersSil_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<ISharPref>().clearShar();
        }

        void OnDersGoster_Clicked(object sender, EventArgs e)
        {
            ((App)Application.Current).MainPage = new Page2();
        }
        

    }
}