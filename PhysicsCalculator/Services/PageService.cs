using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PhysicsCalculator.Services
{
    public class PageService
    {
        public event Action<Page> OnPageChanged;

        public void Navigate(Page page)
        {
            OnPageChanged.Invoke(page);
            history.Push(page.GetType());
        }

        public PageService()
        {
            history = new Stack<Type>();
        }

        public Stack<Type> history;
        public bool CanGoToBack => history.Skip(1).Any();
        internal void GoToBack()
        {
            history.Pop();
            var page = history.Peek();
            OnPageChanged.Invoke((Page)Activator.CreateInstance(page));
        }
    }
}
