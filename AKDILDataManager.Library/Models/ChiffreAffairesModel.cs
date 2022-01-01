using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDataManager.Library.Models
{
    public class ChiffreAffairesModel
    {
        //[Code], [Num_facture], [Date_facture], [Client], [Objet], [Montant_HT], [Taux], [Montant_TVA], [Montant_TTC], [Mode_reglement], [Date_reglement], [Id_instance]  
        public int Code { get; set; }
        public int Num_facture { get; set; }
        public DateTime Date_facture { get; set; }
        public string Client { get; set; }
        public string Objet { get; set; }
        public double Montant_HT { get; set; }
        public int Taux { get; set; }
        public double Montant_TVA { get; set; }
        public double Montant_TTC { get; set; }
        public string Mode_reglement { get; set; }
        public DateTime Date_reglement { get; set; }
        public int Id_instance { get; set; }
    }
}
