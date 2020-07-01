using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NurseMobile
{
    public class ConsultationViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Consultation> Consultations { get; set; }
        ConsultationService consultationService = new ConsultationService();
        public event PropertyChangedEventHandler PropertyChanged;

        public ConsultationViewModel()
        {
            Consultations = new ObservableCollection<Consultation>();
        }

        public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public async Task GetConsultations()
        {
            IEnumerable<Consultation> consultations = await consultationService.Get();

            while (Consultations.Any())
                Consultations.RemoveAt(Consultations.Count - 1);

            foreach (Consultation c in consultations)
                Consultations.Add(c);
        }

    }
}
