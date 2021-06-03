using AKDILTVADesktopUI.ViewModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AKDILTVADesktopUI
{
    public class Bootstrapper : BootstrapperBase
    {
        // Dependency injecttion using SimpleContaner from caliburn.micro (vid tutorial) https://www.youtube.com/watch?v=Q5ciBOoMt8U&list=PLLWMQd6PeGY0bEMxObA6dtYXuJOGfxSPx&index=7&ab_channel=IAmTimCoreyIAmTimCorey

        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container.Instance(_container);

            _container // this ties the interface to the implementation
                .Singleton<IWindowManager, WindowManager>() // handling windows
                .Singleton<IEventAggregator, EventAggregator>(); // pass event messaging trhough out the application // a singleton creates onne instance of the class for the life of the application or the scope of the container

            // wiring up viewModels to views
            // using a reflection here, it will cause a small performance hit at startup
            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
