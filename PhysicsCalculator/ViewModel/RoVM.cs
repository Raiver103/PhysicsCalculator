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
    internal class RoVM : INotifyPropertyChanged
    {
        private PageService navigation;
        public RoVM(PageService navigation)
        {
            this.navigation = navigation; 
            
            Search = new ObservableCollection<string>()
            {
                "p", "m", "V"
            };

            IsCollapsedAll = "Collapsed";
            IsCollapsedP = "Collapsed";
            IsCollapsedM = "Collapsed";
            IsCollapsedV = "Collapsed";

            SearchCommand = new RelayCommand<object>(SearchCommandExecuted, SearchCommandCanExecute);
            FindParamCommand = new RelayCommand<object>(FindParamExecute, FindParamCanExecute);
        }

        private ICommand searchCommand;
        public ICommand SearchCommand { get { return searchCommand; } 
            set { searchCommand = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchCommand))); }}
        private void SearchCommandExecuted(object obj)
        {
            if (WhatSearch == "p")
            {
                Answer = $"{WhatSearch} = m / V => {M / V}кг/м3";
            }
            else if (WhatSearch == "m")
            {
                Answer = $"{WhatSearch} = P * V => {P * V}кг";
            }
            else if (WhatSearch == "V")
            {
                Answer = $"{WhatSearch} = M / P => {M / P}м3";
            }
        }

        private bool SearchCommandCanExecute(object obj)
        {
            return true;
        }

        private ICommand findParamCommand;
        public ICommand FindParamCommand { get { return findParamCommand; }
            set { findParamCommand = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FindParamCommand))); }}
        private void FindParamExecute(object obj)
        {
            if (WhatSearch == "p")
            {
                IsCollapsedAll = "Visible";
                IsCollapsedP = "Collapsed";
                IsCollapsedM = "Visible";
                IsCollapsedV = "Visible";
            }
            else if (WhatSearch == "m")
            {
                IsCollapsedAll = "Visible";
                IsCollapsedP = "Visible";
                IsCollapsedM = "Collapsed";
                IsCollapsedV = "Visible";
            }
            else if (WhatSearch == "V")
            {
                IsCollapsedAll = "Visible";
                IsCollapsedP = "Visible";
                IsCollapsedM = "Visible";
                IsCollapsedV = "Collapsed";
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

        private string _isCollapsedM;
        public string IsCollapsedM
        {
            get { return _isCollapsedM; }

            set
            {
                _isCollapsedM = value;
                OnPropertyChanged();
            }
        }

        private string _isCollapsedV;
        public string IsCollapsedV
        {
            get { return _isCollapsedV; }

            set
            {
                _isCollapsedV = value;
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

        private double p;
        public double P
        {
            get { return p; }
            set
            {
                p = value;
                OnPropertyChanged();
            }
        }

        private double m;
        public double M
        {
            get { return m; }
            set
            {
                m = value;
                OnPropertyChanged();
            }
        }

        private double v;
        public double V
        {
            get { return v; }
            set
            {
                v = value;
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
