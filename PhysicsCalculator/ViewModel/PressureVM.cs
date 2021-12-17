using PhysicsCalculator.Services;
using PhysicsCalculator.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhysicsCalculator.ViewModel
{
    internal class PressureVM : INotifyPropertyChanged
    {
        private PageService navigation;
        public PressureVM(PageService navigation)
        {
            this.navigation = navigation;

            Search = new ObservableCollection<string>()
            {
                "p", "F", "S"
            };

            SearchCommand = new RelayCommand<object>(SearchCommandExecuted, SearchCommandCanExecute);
            FindParamCommand = new RelayCommand<object>(FindParamExecute, FindParamCanExecute);
        }

        private ICommand searchCommand;
        public ICommand SearchCommand
        {
            get { return searchCommand; }
            set { searchCommand = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchCommand))); }
        }
        private void SearchCommandExecuted(object obj)
        {
            if (WhatSearch == "p")
            {
                Answer = $"{WhatSearch} = F / S => {F / S}кг/м3";
            }
            else if (WhatSearch == "F")
            {
                Answer = $"{WhatSearch} = P * S => { P * S }кг";
            }
            else if (WhatSearch == "S")
            {
                Answer = $"{WhatSearch} = P / F => {P / F}м3";
            }
        }

        private bool SearchCommandCanExecute(object obj)
        {
            return true;
        }

        private ICommand findParamCommand;
        public ICommand FindParamCommand
        {
            get { return findParamCommand; }
            set { findParamCommand = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FindParamCommand))); }
        }
        private void FindParamExecute(object obj)
        {
            if (WhatSearch == "p")
            {
                IsCollapsedAll = "Visible";
                IsCollapsedP = "Collapsed";
                IsCollapsedF = "Visible";
                IsCollapsedS = "Visible";
            }
            else if (WhatSearch == "F")
            {
                IsCollapsedAll = "Visible";
                IsCollapsedP = "Visible";
                IsCollapsedF = "Collapsed";
                IsCollapsedS = "Visible";
            }
            else if (WhatSearch == "S")
            {
                IsCollapsedAll = "Visible";
                IsCollapsedP = "Visible";
                IsCollapsedF = "Visible";
                IsCollapsedS = "Collapsed";
            }
        }


        private bool FindParamCanExecute(object obj)
        {
            return true;
        }

        private string _isCollapsedP;
        public string IsCollapsedP
        {
            get { return _isCollapsedP; }

            set
            {
                _isCollapsedP = value;
                OnPropertyChanged();
            }
        }

        private string _isCollapsedF;
        public string IsCollapsedF
        {
            get { return _isCollapsedF; }

            set
            {
                _isCollapsedF = value;
                OnPropertyChanged();
            }
        }

        private string _isCollapsedS;
        public string IsCollapsedS
        {
            get { return _isCollapsedS; }

            set
            {
                _isCollapsedS = value;
                OnPropertyChanged();
            }
        }

        private string _isCollapsedAll;
        public string IsCollapsedAll
        {
            get { return _isCollapsedAll; }

            set
            {
                _isCollapsedAll = value;
                OnPropertyChanged();
            }
        }

        private double P;
        public double p
        {
            get { return P; }

            set
            {
                P = value;
                OnPropertyChanged();
            }
        }

        private double f;
        public double F
        {
            get { return f; }

            set
            {
                f = value;
                OnPropertyChanged();
            }
        }

        private double s;
        public double S
        {
            get { return s; }

            set
            {
                s = value;
                OnPropertyChanged();
            }
        }

        private string answer;
        public string Answer
        {
            get { return answer; }
            set
            {
                answer = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> search;
        public ObservableCollection<string> Search
        {
            get { return search; }
            set
            {
                search = value;
                OnPropertyChanged();
            }
        }

        private string whatSearch;
        public string WhatSearch
        {
            get { return whatSearch; }
            set
            {
                whatSearch = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
