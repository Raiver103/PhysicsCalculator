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
            IsCollapsedV = "Collapsed";
            IsCollapsedS = "Collapsed";
            IsCollapsedT = "Collapsed";
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
                       Answer = $"{WhatSearch} = S / v => {S / V}";
                   }
               }));

        private RelayCommand findParamCommand;
        public ICommand FindParamCommand => findParamCommand ??
               (findParamCommand = new RelayCommand(obj =>
               {
                   if (WhatSearch == "v")
                   {  
                       IsCollapsedV = "Collapsed";
                       IsCollapsedS = "Visible";
                       IsCollapsedT = "Visible";
                   }
                   else if (WhatSearch == "S")
                   {  
                       IsCollapsedV = "Visible";
                       IsCollapsedS = "Collapsed";
                       IsCollapsedT = "Visible";
                   }
                   else if (WhatSearch == "t")
                   { 
                       IsCollapsedV = "Visible";
                       IsCollapsedS = "Visible";
                       IsCollapsedT = "Collapsed";
                   }
               }));

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

        private string _isCollapsedT;
        public string IsCollapsedT
        {
            get { return _isCollapsedT; }

            set
            {
                _isCollapsedT = value;
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
