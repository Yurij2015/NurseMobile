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
    public partial class СonsultationPage : ContentPage
    {

        //public Consultation Model { get; private set; }
        //public ConsultationViewModel ViewModel { get; private set; }
        ConsultationViewModel viewModel;
        public СonsultationPage()
        {
            InitializeComponent();
            viewModel = new ConsultationViewModel();
            BindingContext = viewModel;

        }

        protected override async void OnAppearing()
        {
            await viewModel.GetConsultations();
            base.OnAppearing();
        }

    }
}