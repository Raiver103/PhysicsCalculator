using PhysicsCalculator.Services;
using PhysicsCalculator.View;
using PhysicsCalculator.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input; 

namespace PhysicsCalculator.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    { 
        private PageService navigation;
        public MainWindowVM(PageService navigation)
        { 
            navigation.OnPageChanged += page => CurrentPage = page;
            navigation.Navigate(new StartPage());
            this.navigation = navigation;

            GoToBack = new RelayCommand<object>(GoToBackExecute, GoToBackCanExecute);
        } 

        private Page currentPage;
        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }

        private ICommand goToBack;
        public ICommand GoToBack { get { return goToBack; } set { goToBack = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GoToBack))); } }

        private void GoToBackExecute(object obj)
        {
            navigation.GoToBack();
        }

        private bool GoToBackCanExecute(object obj)
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
