using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDataManager.Library.Models
{
    public class EntrepriseYearModel
    {
        public int Id { get; set; }
        public int Id_entreprise { get; set; }
        public double Credit_N1 { get; set; }
        public int Annee { get; set; }
        public string Encaissement_debit { get; set; }
        public string Mois_trimestre { get; set; }
    }
}
