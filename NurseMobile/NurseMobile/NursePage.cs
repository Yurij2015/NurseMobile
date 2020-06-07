using Xamarin.Forms;

namespace NurseMobile
{
    internal class NursePage : Page
    {
        private Nurse tempFriend;
        private ApplicationViewModel applicationViewModel;

        public NursePage(Nurse tempFriend, ApplicationViewModel applicationViewModel)
        {
            this.tempFriend = tempFriend;
            this.applicationViewModel = applicationViewModel;
        }
    }
}