using PhysicsCalculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsCalculator
{
    class ViewModelLocator
    {
        public MainWindowVM MainVM => Dependency.Resolve<MainWindowVM>();
        public VelocitieVM VelocitieVM => Dependency.Resolve<VelocitieVM>();
        public StartVM StartVM => Dependency.Resolve<StartVM>();
        public RoVM RoVM => Dependency.Resolve<RoVM>();
        public ForceVM ForceVM => Dependency.Resolve<ForceVM>();
        public PressureVM PressureVM => Dependency.Resolve<PressureVM>();
    }
}
