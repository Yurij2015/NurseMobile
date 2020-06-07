using Xamarin.Forms;

namespace NurseMobile
{
    public partial class NursesList : ContentPage
    {
        ApplicationViewModel viewModel;
        public NursesList()
        {
            InitializeComponent();
            viewModel = new ApplicationViewModel();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetNurses();
            base.OnAppearing();
        }
    }
}