using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDataManager.Library.Models
{
    public class DeclarationChiffreAffairesTotalModel
    {
        //[Code], [Designation], [Montant], [Id_instance]
        public int Code { get; set; }
        public string Designation { get; set; }
        public double Montant { get; set; }
        public int Id_instance { get; set; }
    }
}
