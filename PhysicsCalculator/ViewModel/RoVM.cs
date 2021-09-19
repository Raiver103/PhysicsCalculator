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
            IsEnabledP = true;
            IsEnabledM = true;
            IsEnabledV = true;
        }

        private RelayCommand searchCommand;
        public ICommand SearchCommand => searchCommand ??
               (searchCommand = new RelayCommand(obj =>
               {
                   if (WhatSearch == "p")
                   {
                       Answer = $"{WhatSearch} = m / V => {M / V}";

                   }
                   else if (WhatSearch == "m")
                   {
                       Answer = $"{WhatSearch} = P * V => {P * V}";
                   }
                   else if (WhatSearch == "V")
                   {
                       Answer = $"{WhatSearch} = M / P => {M / P}";
                   }
               }));

        private RelayCommand findParamCommand;
        public ICommand FindParamCommand => findParamCommand ??
               (findParamCommand = new RelayCommand(obj =>
               {
                   if (WhatSearch == "p")
                   {
                       IsEnabledP = true;
                       IsEnabledM = false;
                       IsEnabledV = false;
                   }
                   else if (WhatSearch == "m")
                   {
                       IsEnabledP = false;
                       IsEnabledM = true;
                       IsEnabledV = false;
                   }
                   else if (WhatSearch == "V")
                   {
                       IsEnabledP = false;
                       IsEnabledM = false;
                       IsEnabledV = true;
                   }
               }));

        private bool _isEnabledP;
        public bool IsEnabledP
        {
            get { return _isEnabledP; }

            set
            {
                _isEnabledP = value;
                OnPropertyChanged();
            }

        }

        private bool _isEnabledM;
        public bool IsEnabledM
        {
            get { return _isEnabledM; }

            set
            {
                _isEnabledM = value;
                OnPropertyChanged();
            }

        }

        private bool _isEnabledV;
        public bool IsEnabledV
        {
            get { return _isEnabledV; }

            set
            {
                _isEnabledV = value;
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
