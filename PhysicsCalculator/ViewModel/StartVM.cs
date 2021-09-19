using PhysicsCalculator.Services;
using PhysicsCalculator.View;
using PhysicsCalculator.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhysicsCalculator.ViewModel
{
    internal class StartVM : INotifyPropertyChanged
    {
        private PageService navigation;
        public StartVM(PageService navigation)
        {
            this.navigation = navigation;
        }

        private RelayCommand goToVelocitiePage;
        public ICommand GoToVelocitiePage => goToVelocitiePage ??
               (goToVelocitiePage = new RelayCommand(obj =>
               {
                   navigation.Navigate(new VelocitiePage());
               })); 
        
        private RelayCommand goToRoPage;
        public ICommand GoToRoPage => goToRoPage ??
               (goToRoPage = new RelayCommand(obj =>
               {
                   navigation.Navigate(new RoPage());
               }));

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
