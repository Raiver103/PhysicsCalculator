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
using System.Windows.Input;

namespace PhysicsCalculator.ViewModel
{
    class VelocitieVM : INotifyPropertyChanged
    { 

        private PageService navigation;
        public VelocitieVM(PageService navigation)
        { 
            this.navigation = navigation; Search = new ObservableCollection<string>()
            {
                "v", "S", "t"
            };
            IsEnabledV = true;
            IsEnabledS = true;
            IsEnabledT = true;
        }

        private RelayCommand searchCommand;
        public ICommand SearchCommand => searchCommand ??
               (searchCommand = new RelayCommand(obj =>
               {
                   if (WhatSearch == "v")
                   {
                       Answer = $"{WhatSearch} = S / t => {S / T}";

                   }
                   else if (WhatSearch == "S")
                   {
                       Answer = $"{WhatSearch} = v * t => {V * T}";
                   }
                   else if (WhatSearch == "t")
                   {
                       Answer = $"{WhatSearch} = v / S => {V / S}";
                   }
               }));

        private RelayCommand findParamCommand;
        public ICommand FindParamCommand => findParamCommand ??
               (findParamCommand = new RelayCommand(obj =>
               {
                   if (WhatSearch == "v")
                   {
                       IsEnabledV = true;
                       IsEnabledS = false;
                       IsEnabledT = false;
                   }
                   else if (WhatSearch == "S")
                   {
                       IsEnabledV = false;
                       IsEnabledS = true;
                       IsEnabledT = false;
                   }
                   else if (WhatSearch == "t")
                   {
                       IsEnabledV = false;
                       IsEnabledS = false;
                       IsEnabledT = true;
                   }
               }));

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

        private bool _isEnabledS;
        public bool IsEnabledS
        {
            get { return _isEnabledS; }

            set
            {
                _isEnabledS = value;
                OnPropertyChanged();
            }
        }

        private bool _isEnabledT;
        public bool IsEnabledT
        {
            get { return _isEnabledT; }

            set
            {
                _isEnabledT = value;
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

        private double t;
        public double T
        {
            get { return t; }
            set
            {
                t = value;
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
