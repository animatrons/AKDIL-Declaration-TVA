using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Models
{
    public class DeclarationDeductionsModel
    {
        // [Code], Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance
        public int Code { get; set; }
        public string Designation { get; set; }
        public int Taux { get; set; }
        public double TVA { get; set; }
        public int Prorata { get; set; }
        public double TVA_dedcutible { get; set; }
        public int Id_instance { get; set; }
    }
}
