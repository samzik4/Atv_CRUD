using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atv_crud.Models
{
    public class Caixa
    {
        public int IdCaixa { get; set; }
        public double saldoInicial { get; set; }
        public double totalEntradas { get; set; }
        public double totalSaidas { get; set; }
        public string status { get; set; }
        public double saldoFinal { get; set; }
        public int IdFuncionario { get; set; }

    }
}
