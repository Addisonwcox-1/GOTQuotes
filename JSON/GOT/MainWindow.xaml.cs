//Addie Cox

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GOT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //https://got-quotes.herokuapp.com/quotes

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(@"https://got-quotes.herokuapp.com/quotes").Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    Quote q = JsonConvert.DeserializeObject<Quote>(content);

                    TextBlock txt = new TextBlock();


                    //txt.Inlines.Add(@"https://got-quotes.herokuapp.com/quotes");
                    txt.Inlines.Add(new Italic(new Run("italic")));
                    txt.Inlines.Add(new Bold(new Run("bold")));

                    Content = txt;



                }
            }

        }
    }
}
