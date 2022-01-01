using AKDILDesktopUI.Library.Api;
using AKDILDesktopUI.Library.Models;
using AKDILTVADesktopUI.EventModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AKDILTVADesktopUI.ViewModels
{
    public class EntrepriseViewModel : Screen, IHandle<SelectEntrepriseEvent>, IHandle<SelectedEntrepriseYearModel>, IHandle<SelectedEntrepriseMonthModel>/*, SelectedEntrepriseYearModel INotifyPropertyChanged*/
    {
        IEntrepriseEndpoint _entrepriseEndpoint;
        IEntrepriseYearEndpoint _entrepriseYearEndpoint;
        IEntrepriseMonthEndpoint _entrepriseMonthEndpoint;
        IVentilationDeductionsEndpoint _ventilationDeductionsEndpoint;
        IChiffreAffairesEndpoint _chiffreAffairesEndpoint;
        IDeclarationChiffreAffairesTotalEndpoint _declarationChiffreAffairesTotalEndpoint;
        IDeclarationChiffreAffairesImposableEndpoint _declarationChiffreAffairesImposableEndpoint;
        IDeclarationDeductionsEndpoint _declarationDeductionsEndpoint;
        IEventAggregator _events;

        public EntrepriseViewModel(IEntrepriseEndpoint entrepriseEndpoint, IEntrepriseYearEndpoint entrepriseYearEndpoint, IEntrepriseMonthEndpoint entrepriseMonthEndpoint,
            IDeclarationChiffreAffairesImposableEndpoint declarationChiffreAffairesImposableEndpoint, IDeclarationDeductionsEndpoint declarationDeductionsEndpoint,
            IChiffreAffairesEndpoint chiffreAffairesEndpoint, IVentilationDeductionsEndpoint ventilationDeductionsEndpoint, IDeclarationChiffreAffairesTotalEndpoint declarationChiffreAffairesTotalEndpoint, IEventAggregator events)
        {
            _entrepriseEndpoint = entrepriseEndpoint;
            _entrepriseYearEndpoint = entrepriseYearEndpoint;
            _entrepriseMonthEndpoint = entrepriseMonthEndpoint;
            _ventilationDeductionsEndpoint = ventilationDeductionsEndpoint;
            _chiffreAffairesEndpoint = chiffreAffairesEndpoint;
            _declarationChiffreAffairesTotalEndpoint = declarationChiffreAffairesTotalEndpoint;
            _declarationChiffreAffairesImposableEndpoint = declarationChiffreAffairesImposableEndpoint;
            _declarationDeductionsEndpoint = declarationDeductionsEndpoint;
            _events = events;

            _events.Subscribe(this);
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

        // Select entreprise event
        public async void Handle(SelectEntrepriseEvent message)
        {
            RaisonField = _selectedEntreprise.Raison_sociale;
            FormeField = _selectedEntreprise.Forme_juridique;
            ObjetField = _selectedEntreprise.Objet;
            IFField = _selectedEntreprise.IF.ToString();
            ICEField = _selectedEntreprise.ICE.ToString();
            RCField = _selectedEntreprise.RC;
            TPField = _selectedEntreprise.TP;
            CINField = _selectedEntreprise.CIN;
            SiegeField = _selectedEntreprise.Siege_sociale;
            VilleField = _selectedEntreprise.Ville;
            TelField = _selectedEntreprise.Tel;
            EmailField = _selectedEntreprise.Email;

            var yearList = await _entrepriseYearEndpoint.GetAllById(_selectedEntreprise.Id);
            SelectEntrepriseYear = new BindingList<EntrepriseYearModel>(yearList);
        }
        // Select year event
        public async void Handle(SelectedEntrepriseYearModel message)
        {
            AnneeField = (SelectedEntrepriseYear?.Annee.ToString());
            EDField = SelectedEntrepriseYear?.Encaissement_debit;
            MTField = SelectedEntrepriseYear?.Mois_trimestre;
            CreditField = SelectedEntrepriseYear?.Credit_N1.ToString();

            if (!(SelectedEntrepriseYear is null))
            {
                var monthList = await _entrepriseMonthEndpoint.GetAllById(SelectedEntrepriseYear.Id);
                SelectEntrepriseMonth = new BindingList<EntrepriseMonthModel>(monthList);
            }
            else
            {
                SelectEntrepriseMonth = new BindingList<EntrepriseMonthModel>();
            }
        }
        // Select month event
        public async void Handle(SelectedEntrepriseMonthModel message)
        {
            if (!(SelectedEntrepriseMonth is null))
            {
                var dedcutionsTable = await _ventilationDeductionsEndpoint.GetAllById(SelectedEntrepriseMonth.Id);
                var chiffreAffairesTable = await _chiffreAffairesEndpoint.GetAllById(SelectedEntrepriseMonth.Id);
                var daclarationCATotal = await _declarationChiffreAffairesTotalEndpoint.GetAllById(SelectedEntrepriseMonth.Id);
                var declarationCAImposable = await _declarationChiffreAffairesImposableEndpoint.GetAllById(SelectedEntrepriseMonth.Id);
                var declarationDeduction = await _declarationDeductionsEndpoint.GetAllById(SelectedEntrepriseMonth.Id);

                DedcutionsTable = new BindingList<VentilationDeductionsModel>(dedcutionsTable);
                ChiffreAffairesTable = new BindingList<ChiffreAffairesModel>(chiffreAffairesTable);
                DeclarationCATable = new BindingList<DeclarationChiffreAffairesTotalModel>(daclarationCATotal);
                DeclarationCAImposableTable = new BindingList<DeclarationChiffreAffairesImposableModel>(declarationCAImposable);
                DeclarationDeductionsTable = new BindingList<DeclarationDeductionsModel>(declarationDeduction);
            }
            else
            {
                DedcutionsTable = new BindingList<VentilationDeductionsModel>();
                ChiffreAffairesTable = new BindingList<ChiffreAffairesModel>();
                DeclarationCATable = new BindingList<DeclarationChiffreAffairesTotalModel>();
                DeclarationCAImposableTable = new BindingList<DeclarationChiffreAffairesImposableModel>();
                DeclarationDeductionsTable = new BindingList<DeclarationDeductionsModel>();
            }
        }

        // The drop down list of the entreprises
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
        // Year
        private BindingList<EntrepriseYearModel> _selectEntrepriseYear;

        public BindingList<EntrepriseYearModel> SelectEntrepriseYear
        {
            get { return _selectEntrepriseYear; }
            set 
            { 
                _selectEntrepriseYear = value; 
                NotifyOfPropertyChange(() => SelectEntrepriseYear);
            }
        }
        // Month
        private BindingList<EntrepriseMonthModel> _selectEntrepriseMonth;

        public BindingList<EntrepriseMonthModel> SelectEntrepriseMonth
        {
            get { return _selectEntrepriseMonth; }
            set 
            {
                _selectEntrepriseMonth = value; 
                NotifyOfPropertyChange(() => SelectEntrepriseMonth);
            }
        }

        
        // Dedcutions table
        private BindingList<VentilationDeductionsModel> _dedcutionsTable;

        public BindingList<VentilationDeductionsModel> DedcutionsTable
        {
            get { return _dedcutionsTable; }
            set 
            { 
                _dedcutionsTable = value; 
                NotifyOfPropertyChange(() => DedcutionsTable);
            }
        }
        // Chiffre Affaires Table
        private BindingList<ChiffreAffairesModel> _chiffreAffairesTable;

        public BindingList<ChiffreAffairesModel> ChiffreAffairesTable
        {
            get { return _chiffreAffairesTable; }
            set 
            { 
                _chiffreAffairesTable = value; 
                NotifyOfPropertyChange(() => ChiffreAffairesTable);
            }
        }
        // Declaration CA total table
        private BindingList<DeclarationChiffreAffairesTotalModel> _declarationCATotal;

        public BindingList<DeclarationChiffreAffairesTotalModel> DeclarationCATable
        {
            get { return _declarationCATotal; }
            set 
            { 
                _declarationCATotal = value;
                NotifyOfPropertyChange(() => DeclarationCATable);
            }
        }
        // Declaration CA imposable table
        private BindingList<DeclarationChiffreAffairesImposableModel> _declarationCAImposable;

        public BindingList<DeclarationChiffreAffairesImposableModel> DeclarationCAImposableTable
        {
            get { return _declarationCAImposable; }
            set
            {
                _declarationCAImposable = value;
                NotifyOfPropertyChange(() => DeclarationCAImposableTable);
            }
        }
        // Declaration deductions
        private BindingList<DeclarationDeductionsModel> _declarationDeductionsTable;

        public BindingList<DeclarationDeductionsModel> DeclarationDeductionsTable
        {
            get { return _declarationDeductionsTable; }
            set 
            { 
                _declarationDeductionsTable = value; 
                NotifyOfPropertyChange(() => DeclarationDeductionsTable);
            }
        }


        // The currently selected entreprise from the drop down list
        private EntrepriseModel _selectedEntreprise;

        public EntrepriseModel SelectedEntreprise
        {
            get { return _selectedEntreprise; }
            set 
            { 
                _selectedEntreprise = value;
                _events.PublishOnUIThread(new SelectEntrepriseEvent()); // Trigger an event when selecting an item from the dropdown list
                NotifyOfPropertyChange(() => SelectedEntreprise);
            }
        }

        // selected Year
        private EntrepriseYearModel _entrepriseEntrepriseYear;

        public EntrepriseYearModel SelectedEntrepriseYear
        {
            get { return _entrepriseEntrepriseYear; }
            set 
            { 
                _entrepriseEntrepriseYear = value;
                _events.PublishOnUIThread(new SelectedEntrepriseYearModel()); // Trigger an event when selecting an item from the dropdown list SelectedEntrepriseMonthModel
                NotifyOfPropertyChange(() => SelectedEntrepriseYear);
            }
        }
        // selected Year
        private EntrepriseMonthModel _selectedEntrepriseMonth;

        public EntrepriseMonthModel SelectedEntrepriseMonth
        {
            get { return _selectedEntrepriseMonth; }
            set 
            { 
                _selectedEntrepriseMonth = value;
                _events.PublishOnUIThread(new SelectedEntrepriseMonthModel());
                NotifyOfPropertyChange(() => SelectedEntrepriseMonth);
            }
        }



        // Entreprise identification fields:


        private string _raisonField;

        public string RaisonField
        {
            get { return _raisonField; }
            set 
            { 
                _raisonField = value;
                NotifyOfPropertyChange(() => RaisonField);
            }
        }

        private string _formeField;

        public string FormeField
        {
            get { return _formeField; }
            set 
            { 
                _formeField = value;
                NotifyOfPropertyChange(() => FormeField);
            }
        }

        private string _objetField;

        public string ObjetField
        {
            get { return _objetField; }
            set 
            { 
                _objetField = value;
                NotifyOfPropertyChange(() => ObjetField);
            }
        }

        private string _iFField;

        public string IFField
        {
            get { return _iFField; }
            set 
            { 
                _iFField = value; 
                NotifyOfPropertyChange(() => IFField);
            }
        }

        private string _iCEField;

        public string ICEField
        {
            get { return _iCEField; }
            set 
            { 
                _iCEField = value;
                NotifyOfPropertyChange(() => ICEField);
            }
        }

        private string _rCField;

        public string RCField
        {
            get { return _rCField; }
            set 
            { 
                _rCField = value; 
                NotifyOfPropertyChange(() => RCField);
            }
        }

        private string _tPField;

        public string TPField
        {
            get { return _tPField; }
            set 
            { 
                _tPField = value; 
                NotifyOfPropertyChange(() => TPField);
            }
        }

        private string _cINField;

        public string CINField
        {
            get { return _cINField; }
            set 
            { 
                _cINField = value;
                NotifyOfPropertyChange(() => CINField);
            }
        }

        private string _siegeField;

        public string SiegeField
        {
            get { return _siegeField; }
            set 
            { 
                _siegeField = value; 
                NotifyOfPropertyChange(() => SiegeField);
            }
        }

        private string _villeField;

        public string VilleField
        {
            get { return _villeField; }
            set 
            { 
                _villeField = value; 
                NotifyOfPropertyChange(() => VilleField);
            }
        }

        private string _telField;

        public string TelField
        {
            get { return _telField; }
            set 
            { 
                _telField = value; 
                NotifyOfPropertyChange(() => TelField);
            }
        }

        private string _emailField;

        public string EmailField
        {
            get { return _emailField; }
            set 
            { 
                _emailField = value; 
                NotifyOfPropertyChange(() => EmailField);
            }
        }

        // Year field

        private string _anneeField;

        public string AnneeField
        {
            get { return _anneeField; }
            set 
            { 
                _anneeField = value; 
                NotifyOfPropertyChange(() => AnneeField);
            }
        }

        private string _eDField;

        public string EDField
        {
            get { return _eDField; }
            set
            {
                _eDField = value;
                NotifyOfPropertyChange(() => EDField);
            }
        }

        private string _mTField;

        public string MTField
        {
            get { return _mTField; }
            set
            {
                _mTField = value;
                NotifyOfPropertyChange(() => MTField);
            }
        }

        private string _creditField;

        public string CreditField
        {
            get { return _creditField; }
            set
            {
                _creditField = value;
                NotifyOfPropertyChange(() => CreditField);
            }
        }

    }
}
