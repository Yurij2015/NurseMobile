using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace NurseMobile
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        bool initialized = false;   // была ли начальная инициализация
        Nurse selectedFriend;  // выбранный друг
        private bool isBusy;    // идет ли загрузка с сервера

        public ObservableCollection<Nurse> Nurses { get; set; }
        NursesService nursesService = new NursesService();
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateNurseCommand { protected set; get; }
        public ICommand DeleteNurseCommand { protected set; get; }
        public ICommand SaveNurseCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        public INavigation Navigation { get; set; }

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
                OnPropertyChanged("IsLoaded");
            }
        }
        public bool IsLoaded
        {
            get { return !isBusy; }
        }

        public ApplicationViewModel()
        {
            Nurses = new ObservableCollection<Nurse>();
            IsBusy = false;
            CreateNurseCommand = new Command(CreateNurse);
            DeleteNurseCommand = new Command(DeleteNurse);
            SaveNurseCommand = new Command(SaveNurse);
            BackCommand = new Command(Back);
        }

        public Nurse SelectedNurse
        {
            get { return selectedFriend; }
            set
            {
                if (selectedFriend != value)
                {
                    Nurse tempFriend = new Nurse()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        SecontName = value.SecontName,
                    };
                    selectedFriend = null;
                    OnPropertyChanged("SelectedFriend");
                    Navigation.PushAsync(new NursePage(tempFriend, this));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private async void CreateNurse()
        {
            await Navigation.PushAsync(new NursePage(new Nurse(), this));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }

        public async Task GetNurses()
        {
            if (initialized == true) return;
            IsBusy = true;
            IEnumerable<Nurse> nurses = await nursesService.Get();

            // очищаем список
            //Friends.Clear();
            while (Nurses.Any())
                Nurses.RemoveAt(Nurses.Count - 1);

            // добавляем загруженные данные
            foreach (Nurse f in nurses)
                Nurses.Add(f);
            IsBusy = false;
            initialized = true;
        }
        private async void SaveNurse(object nurseObject)
        {
            Nurse nurse = nurseObject as Nurse;
            if (nurse != null)
            {
                IsBusy = true;
                // редактирование
                if (nurse.Id > 0)
                {
                    Nurse updatedFriend = await nursesService.Update(nurse);
                    // заменяем объект в списке на новый
                    if (updatedFriend != null)
                    {
                        int pos = Nurses.IndexOf(updatedFriend);
                        Nurses.RemoveAt(pos);
                        Nurses.Insert(pos, updatedFriend);
                    }
                }
                // добавление
                else
                {
                    Nurse addedFriend = await nursesService.Add(nurse);
                    if (addedFriend != null)
                        Nurses.Add(addedFriend);
                }
                IsBusy = false;
            }
            Back();
        }
        private async void DeleteNurse(object nurseObject)
        {
            Nurse nurse = nurseObject as Nurse;
            if (nurse != null)
            {
                IsBusy = true;
                Nurse deletedNurse = await nursesService.Delete(nurse.Id);
                if (deletedNurse != null)
                {
                    Nurses.Remove(deletedNurse);
                }
                IsBusy = false;
            }
            Back();
        }
    }
}