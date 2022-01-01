using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Models
{
    public class VentilationDeductionsModel
    {
        // [Code], [Num_facture], [Date_facture], [Fournisseur], [IF_fournisseur],[Biens_services], [Montant_HT], [Taux], [Montant_TVA], [Montant_TTC], [Libelle_paiment], [Date_paiment], [Mode_paiment], [ICE], [Id_instance]
        public int Code { get; set; }
        public int Num_facture { get; set; }
        public DateTime Date_facture { get; set; }
        public string Fournisseur { get; set; }
        public int IF_fournisseur { get; set; }
        public string Biens_services { get; set; }
        public double Montant_HT { get; set; }
        public int Taux { get; set; }
        public double Montant_TVA { get; set; }
        public double Montant_TTC { get; set; }
        public string Libelle_paiment { get; set; }
        public DateTime Date_paiment { get; set; }
        public string Mode_paiment { get; set; }
        public int ICE { get; set; }
        public int Id_instance { get; set; }
    }
}
