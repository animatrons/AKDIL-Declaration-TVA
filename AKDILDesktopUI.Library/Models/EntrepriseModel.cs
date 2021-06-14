using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Models
{
    public class EntrepriseModel
    {
        public int Id { get; set; }
        public string Raison_sociale { get; set; }
        public string Forme_juridique { get; set; }
        public string Objet { get; set; }
        public int IF { get; set; }
        public int ICE { get; set; }
        public string RC { get; set; }
        public string TP { get; set; }
        public string CIN { get; set; }
        public string Siege_sociale { get; set; }
        public string Ville { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
    }
}
