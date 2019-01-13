using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mypro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : TabbedPage
    {
        ArrayList CourseInfo = new ArrayList();
        ArrayList Announcements = new ArrayList();
        ArrayList Assignments = new ArrayList();
        ArrayList News = new ArrayList();

        public TabbedPage1 (string item)
        {
            InitializeComponent();
            int id = DependencyService.Get<ISharPref>().getDersId(item);
            getDers(id);


        }

        void goBack_Clicked(Object sender, EventArgs e)
        {

            ((App)Application.Current).MainPage = new Page2();
        }

        async void getDers(int id)
        {
            HttpClient client = new HttpClient();
            
            string res = await client.GetStringAsync("http://ceng.eskisehir.edu.tr/Ders.aspx?dersId="+ id);
            var doc = new HtmlDocument();
            doc.LoadHtml(res);
            string index = "ContentPlaceHolder1_TreeView1t";
                           
            string tab = "CoInfo";
            for (int i = 0; i > -1; i++)
            {
                var element = doc.GetElementbyId(index + "" + i);

                if (element != null)
                {
                    if (!DependencyService.Get<ISharPref>().getElement(element.InnerText).Equals(""))
                    {
                        
                        if (element.InnerText.Equals("Course Info"))
                        {
                            tab = "CoInfo";
                            continue;
                        }
                        else if (element.InnerText.Equals("Announcements"))
                        {
                            tab = "Anno";
                            continue;
                        }
                        else if (element.InnerText.Equals("Assignments"))
                        {
                            tab = "Assi";
                            continue;
                        }
                        else
                        {
                            switch (tab)
                            {
                                case "CoInfo":
                                    Label label = new Label { Text= "- " + element.InnerText, Margin = new Thickness(5,3,5,0), FontSize=15, TextColor=Color.Black};
                                    var gest = new TapGestureRecognizer();
                                    gest.Tapped += (s, e) =>
                                    {
                                        string uriDevam = element.Attributes.AttributesWithName("href").FirstOrDefault().Value;
                                        uriDevam = String.Concat(uriDevam.Split(';'));
                                        uriDevam = uriDevam.Replace("amp", "");
                                        Device.OpenUri(new Uri("http://ceng.eskisehir.edu.tr/" + uriDevam));
                                    };
                                    label.GestureRecognizers.Add(gest);
                                    CoInfo.Children.Add(label);
                                    break;
                                case "Anno":
                                    label = new Label { Text = "- "+element.InnerText, Margin = new Thickness(5, 3, 5, 0), FontSize = 15, TextColor = Color.Black };
                                    gest = new TapGestureRecognizer();
                                    gest.Tapped += (s, e) =>
                                    {
                                        string uriDevam = element.Attributes.AttributesWithName("href").FirstOrDefault().Value;
                                        uriDevam = String.Concat(uriDevam.Split(';'));
                                        uriDevam = uriDevam.Replace("amp", "");
                                        Device.OpenUri(new Uri("http://ceng.eskisehir.edu.tr/" + uriDevam));
                                    };
                                    label.GestureRecognizers.Add(gest);
                                    Anno.Children.Add(label);
                                    break;
                                case "Assi":
                                    label = new Label { Text = "- " + element.InnerText, Margin = new Thickness(5, 3, 5, 0), FontSize = 15, TextColor = Color.Black };
                                    gest = new TapGestureRecognizer();
                                    gest.Tapped += (s, e) =>
                                    {
                                        string uriDevam = element.Attributes.AttributesWithName("href").FirstOrDefault().Value;
                                        uriDevam = String.Concat(uriDevam.Split(';'));
                                        uriDevam = uriDevam.Replace("amp", "");
                                        Device.OpenUri(new Uri("http://ceng.eskisehir.edu.tr/" + uriDevam));
                                    };
                                    label.GestureRecognizers.Add(gest);
                                    Assi.Children.Add(label);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (element.InnerText.Equals("Course Info"))
                        {
                            tab = "CoInfo";
                            continue;
                        }
                        else if (element.InnerText.Equals("Announcements"))
                        {
                            tab = "Anno";
                            continue;
                        }
                        else if (element.InnerText.Equals("Assignments"))
                        {
                            tab = "Assi";
                            continue;
                        }
                        else
                        {
                            Label label = new Label { Text = "- "+element.InnerText, Margin = new Thickness(5, 3, 5, 0), FontSize = 15, TextColor = Color.Black };
                            TapGestureRecognizer gest = new TapGestureRecognizer();
                            gest.Tapped += (s, e) =>
                            {
                                string uriDevam = element.Attributes.AttributesWithName("href").FirstOrDefault().Value;
                                uriDevam = String.Concat(uriDevam.Split(';'));
                                uriDevam = uriDevam.Replace("amp", "");
                                Device.OpenUri(new Uri("http://ceng.eskisehir.edu.tr/" + uriDevam));
                            };
                            label.GestureRecognizers.Add(gest);
                            Newss.Children.Add(label);
                            DependencyService.Get<ISharPref>().setElement(element.InnerText, "a");
                        }
                        
                        
                    }

                }
                else break;
            }
        }
    }
}