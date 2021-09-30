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
            GoToRoPage = new RelayCommand<object>(GoToRoPageExecute, GoToRoPageCanExecute);
            GoToVelocitiePage = new RelayCommand<object>(GoToVelocitiePageExecute, GoToVelocitiePageCanExecute);
            GoToForcePage = new RelayCommand<object>(GoToForcePageExecute, GoToForcePageCanExecute);
        }
          
        private ICommand goToVelocitiePage;
        public ICommand GoToVelocitiePage { get { return goToVelocitiePage; } set { goToVelocitiePage = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(goToVelocitiePage))); } }

        private void GoToVelocitiePageExecute(object obj)
        {
            navigation.Navigate(new VelocitiePage());
        }
        private bool GoToVelocitiePageCanExecute(object obj)
        {
            return true;
        }

        private ICommand goToRoPage;
        public ICommand GoToRoPage { get { return goToRoPage; } set { goToRoPage = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GoToRoPage))); }}

        private void GoToRoPageExecute(object obj)
        {
            navigation.Navigate(new RoPage());
        }
        private bool GoToRoPageCanExecute(object obj)
        {
            return true;
        }

        private ICommand goToForcePage;
        public ICommand GoToForcePage { get { return goToForcePage; } 
            set { goToForcePage = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GoToForcePage))); } }

        private void GoToForcePageExecute(object obj)
        {
            navigation.Navigate(new ForcePage());
        }
        private bool GoToForcePageCanExecute(object obj)
        {
            return true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
