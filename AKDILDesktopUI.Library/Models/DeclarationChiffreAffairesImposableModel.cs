using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Models
{
    public class DeclarationChiffreAffairesImposableModel
    {
        // [Code], [Designation], Base_imposable, Taxe_exigible, [Id_instance]
        public int Code { get; set; }
        public string Designation { get; set; }
        public double Base_imposable { get; set; }
        public double Taxe_exigible { get; set; }
        public int Id_instance { get; set; }
    }
}
