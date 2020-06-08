using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NurseMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiagnosticPage : ContentPage
    {
        public DiagnosticPage()
        {
            InitializeComponent();
        }


        void button_Clicked(object sender, EventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = urlEntry.Text };
            // или так
            // webView.Source = urlEntry.Text;
        }

    }
}