using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AKDILTVADesktopUI.EventModels;
using Caliburn.Micro;

namespace AKDILTVADesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogInEvent>
    {
        public IEventAggregator _events;
        public EntrepriseViewModel _entrepriseVM;
        public SimpleContainer _container;

        // Using constructor injection
        public ShellViewModel(IEventAggregator events, EntrepriseViewModel entrepriseVM,
            SimpleContainer container)
        {
            _events = events;
            _entrepriseVM = entrepriseVM;
            _container = container;

            _events.Subscribe(this);

            ActivateItem(_container.GetInstance<LoginViewModel>()); // initiate and clean up the login vm for next time
        }

        public void Handle(LogInEvent message)
        {
            ActivateItem(_entrepriseVM);
        }
    }
}
