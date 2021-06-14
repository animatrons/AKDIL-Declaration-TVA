using AKDILDesktopUI.Library.Api;
using AKDILDesktopUI.Library.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKDILTVADesktopUI.ViewModels
{
    public class EntrepriseViewModel : Screen
    {
        IEntrepriseEndpoint _entrepriseEndpoint;

        public EntrepriseViewModel(IEntrepriseEndpoint entrepriseEndpoint)
        {
            _entrepriseEndpoint = entrepriseEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadEntreprises(); // Load the entreprises when the view is loaded
        }

        private async Task LoadEntreprises()
        {
            var entrepriseList = await _entrepriseEndpoint.GetAll(); // The GetAll entreprises method is async, and we cant run a async method in the constructor 
            SelectEntreprise = new BindingList<EntrepriseModel>(entrepriseList);
        }

        private BindingList<EntrepriseModel> _selectEntreprise;

        public BindingList<EntrepriseModel> SelectEntreprise
        {
            get { return _selectEntreprise; }
            set 
            { 
                _selectEntreprise = value;
                NotifyOfPropertyChange(() => SelectEntreprise);
            }
        }


    }
}
