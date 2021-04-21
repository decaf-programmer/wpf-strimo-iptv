using Caliburn.Micro;
using StrimoUI.Components.Dialogs.AlertDialog;
using StrimoUI.Components.Dialogs.References;
using StrimoUI.Components.ViewModels;
using StrimoUI.Pages.ViewModels.Content;
using StrimoUI.Pages.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StrimoUI
{
    public class Bootstrapper:BootstrapperBase
    {
        private SimpleContainer simpleContainer;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            simpleContainer = new SimpleContainer();

            simpleContainer.Singleton<IWindowManager, WindowManager>();
            simpleContainer.Singleton<IEventAggregator, EventAggregator>();
            simpleContainer.Singleton<IDialogService, DialogService>();

            simpleContainer.PerRequest<ShellViewModel>();
            simpleContainer.PerRequest<LoginConductorViewModel>();
            simpleContainer.PerRequest<LoginPageViewModel>();
            simpleContainer.PerRequest<AlertDialogViewModel>();
            simpleContainer.PerRequest<LoadAccountViewModel>();
            simpleContainer.PerRequest<SelectAccountViewModel>();
            simpleContainer.PerRequest<ContentConductorViewModel>();
            simpleContainer.PerRequest<HomeViewModel>();
            simpleContainer.PerRequest<NavigationItemViewModel>();
            simpleContainer.PerRequest<DashboardViewModel>();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return simpleContainer.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return simpleContainer.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            base.BuildUp(instance);
        }
    }
}
