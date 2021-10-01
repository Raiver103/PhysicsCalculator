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
                "Fтяж", "Fтр", "P", "m", "k", "l", "my"
            };

            IsCollapsedFtg = "Collapsed";
            IsCollapsedFtr = "Collapsed";
            IsCollapsedM = "Collapsed";
            IsCollapsedK = "Collapsed";
            IsCollapsedL = "Collapsed";
            IsCollapsedMY = "Collapsed";

            IsCollapsedAll = "Collapsed";

            SearchCommand = new RelayCommand<object>(SearchCommandExecuted, SearchCommandCanExecute);
            FindParamCommand = new RelayCommand<object>(FindParamExecute, FindParamCanExecute);
        }

        private ICommand searchCommand;
        public ICommand SearchCommand { get { return searchCommand; } 
            set { searchCommand = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchCommand)));}}

        private void SearchCommandExecuted(object obj)
        {
            if (WhatSearch == "Fтяж")
            {
                Answer = $"{WhatSearch} = m * g => {M * g}Н";
            }
            else if (WhatSearch == "Fтр")
            {
                Answer = $"{WhatSearch} = my * Fтяж => {MY * Ftg}Н";
            }
            if (WhatSearch == "P")
            {
                Answer = $"{WhatSearch} = m * g => {M * g}Н";
            }
            else if (WhatSearch == "m")
            {
                Answer = $"{WhatSearch} = Fтяж / g => {Ftg / g}кг";
            }
            else if (WhatSearch == "k")
            {
                Answer = $"{WhatSearch} = Fтяж / l => {Ftg / L}Н/м";
            }
            else if (WhatSearch == "l")
            {
                Answer = $"{WhatSearch} = Fтяж / k => {Ftg / K}м";
            }
            else if (WhatSearch == "my")
            {
                Answer = $"{WhatSearch} = Fтяж / Fтр => {Ftg / Ftr}";
            }
        }

        private bool SearchCommandCanExecute(object obj)
        {
            return true;
        }

        private ICommand findParamCommand;
        public ICommand FindParamCommand { get { return findParamCommand; } 
            set { findParamCommand = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FindParamCommand))); } }

        private void FindParamExecute(object obj)
        {
            if (WhatSearch == "Fтяж")
            {
                IsCollapsedFtg = "Collapsed";
                IsCollapsedFtr = "Collapsed";
                IsCollapsedM = "Visible";
                IsCollapsedK = "Collapsed";
                IsCollapsedL = "Collapsed";
                IsCollapsedMY = "Collapsed";

                IsCollapsedAll = "Visible";
            }
            else if (WhatSearch == "Fтр")
            {
                IsCollapsedFtg = "Visible";
                IsCollapsedFtr = "Collapsed";
                IsCollapsedM = "Collapsed";
                IsCollapsedK = "Collapsed";
                IsCollapsedL = "Collapsed";
                IsCollapsedMY = "Visible";

                IsCollapsedAll = "Visible";
            }
            else if (WhatSearch == "P")
            {
                IsCollapsedFtg = "Collapsed";
                IsCollapsedFtr = "Collapsed";
                IsCollapsedM = "Visible";
                IsCollapsedK = "Collapsed";
                IsCollapsedL = "Collapsed";
                IsCollapsedMY = "Collapsed";

                IsCollapsedAll = "Visible";
            }
            else if (WhatSearch == "m")
            {
                IsCollapsedFtg = "Visible";
                IsCollapsedFtr = "Collapsed";
                IsCollapsedM = "Collapsed";
                IsCollapsedK = "Collapsed";
                IsCollapsedL = "Collapsed";
                IsCollapsedMY = "Collapsed";

                IsCollapsedAll = "Visible";
            }
            else if (WhatSearch == "k")
            {
                IsCollapsedFtg = "Visible";
                IsCollapsedFtr = "Collapsed";
                IsCollapsedM = "Collapsed";
                IsCollapsedK = "Collapsed";
                IsCollapsedL = "Visible";
                IsCollapsedMY = "Collapsed";

                IsCollapsedAll = "Visible";
            }
            else if (WhatSearch == "l")
            {
                IsCollapsedFtg = "Visible";
                IsCollapsedFtr = "Collapsed";
                IsCollapsedM = "Collapsed";
                IsCollapsedK = "Visible";
                IsCollapsedL = "Collapsed";
                IsCollapsedMY = "Collapsed";
                 
                IsCollapsedAll = "Visible";
            }
            else if (WhatSearch == "my")
            {
                IsCollapsedFtg = "Visible";
                IsCollapsedFtr = "Visible";
                IsCollapsedM = "Collapsed";
                IsCollapsedK = "Collapsed";
                IsCollapsedL = "Collapsed";
                IsCollapsedMY = "Collapsed";
                 
                IsCollapsedAll = "Visible";
            }
        }

        private bool FindParamCanExecute(object obj)
        {
            return true;
        }

        private string _isCollapsedFtg;
        public string IsCollapsedFtg
        {
            get { return _isCollapsedFtg; }

            set
            {
                _isCollapsedFtg = value;
                OnPropertyChanged();
            }
        }

        private string _isCollapsedFtr;
        public string IsCollapsedFtr
        {
            get { return _isCollapsedFtr; }

            set
            {
                _isCollapsedFtr = value;
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

        private double ftg;
        public double Ftg
        {
            get { return ftg; }
            set
            {
                ftg = value;
                OnPropertyChanged();
            }
        }

        private double ftr;
        public double Ftr
        {
            get { return ftr; }
            set
            {
                ftr = value;
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
        public double MY 
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
