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
    internal class ForceVM : INotifyPropertyChanged
    {
        const int g = 10;

        private PageService navigation;
        public ForceVM(PageService navigation)
        {
            this.navigation = navigation;

            Search = new ObservableCollection<string>()
            {
                "F", "m", "k", "l", "my"
            };
            IsCollapsedF = "Collapsed";
            IsCollapsedM = "Collapsed";
            IsCollapsedK = "Collapsed";
            IsCollapsedL = "Collapsed";
            IsCollapsedMY = "Collapsed";

            SearchCommand = new RelayCommand<object>(SearchCommandExecuted, SearchCommandCanExecute);
            FindParamCommand = new RelayCommand<object>(FindParamExecute, FindParamCanExecute);
        }

        private ICommand searchCommand;
        public ICommand SearchCommand { get { return searchCommand; } set { searchCommand = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchCommand)));}}

        private void SearchCommandExecuted(object obj)
        {
            if (WhatSearch == "F")
            {
                Answer = $"{WhatSearch} = m / V => {M * g}";

            }
            else if (WhatSearch == "m")
            {
                Answer = $"{WhatSearch} = P * V => {F / g}";
            }
            else if (WhatSearch == "k")
            {
                Answer = $"{WhatSearch} = M / P => {F / L}";
            }
            else if (WhatSearch == "l")
            {
                Answer = $"{WhatSearch} = P * V => {F * K}";
            }
            else if (WhatSearch == "my")
            {
                Answer = $"{WhatSearch} = M / P => {F / F}";
            }
        }
        private bool SearchCommandCanExecute(object obj)
        {
            return true;
        }

        private ICommand findParamCommand;
        public ICommand FindParamCommand { get { return findParamCommand; } set { findParamCommand = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FindParamCommand))); } }
        private void FindParamExecute(object obj)
        {
            if (WhatSearch == "F")
            {
                IsCollapsedF = "Collapsed";
                IsCollapsedM = "Collapsed";
                IsCollapsedK = "Collapsed";
                IsCollapsedL = "Collapsed";
                IsCollapsedMY = "Collapsed";
            }
            else if (WhatSearch == "m")
            {
                IsCollapsedF = "Collapsed";
                IsCollapsedM = "Collapsed";
                IsCollapsedK = "Collapsed";
                IsCollapsedL = "Collapsed";
                IsCollapsedMY = "Collapsed";
            }
            else if (WhatSearch == "k")
            {
                IsCollapsedF = "Collapsed";
                IsCollapsedM = "Collapsed";
                IsCollapsedK = "Collapsed";
                IsCollapsedL = "Collapsed";
                IsCollapsedMY = "Collapsed";
            }
            else if (WhatSearch == "l")
            {
                IsCollapsedF = "Collapsed";
                IsCollapsedM = "Collapsed";
                IsCollapsedK = "Collapsed";
                IsCollapsedL = "Collapsed";
                IsCollapsedMY = "Collapsed";
            }
            else if (WhatSearch == "my")
            {
                IsCollapsedF = "Collapsed";
                IsCollapsedM = "Collapsed";
                IsCollapsedK = "Collapsed";
                IsCollapsedL = "Collapsed";
                IsCollapsedMY = "Collapsed";
            }
        }
        private bool FindParamCanExecute(object obj)
        {
            return true;
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

        private string _isCollapsedK;
        public string IsCollapsedK
        {
            get { return _isCollapsedK; }

            set
            {
                _isCollapsedK = value;
                OnPropertyChanged();
            }
        }

        private string _isCollapsedL;
        public string IsCollapsedL
        {
            get { return _isCollapsedL; }

            set
            {
                _isCollapsedL = value;
                OnPropertyChanged();
            }
        }

        private string _isCollapsedMY;
        public string IsCollapsedMY
        {
            get { return _isCollapsedMY; }

            set
            {
                _isCollapsedMY = value;
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

        private double k;
        public double K
        {
            get { return k; }
            set
            {
                k = value;
                OnPropertyChanged();
            }
        }

        private double l;
        public double L
        {
            get { return l; }
            set
            {
                l = value;
                OnPropertyChanged();
            }
        }

        private double my;
        public double My 
        {
            get { return my; }
            set
            {
                my = value;
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
