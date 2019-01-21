using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002___Entidade
{
    public class ENotaFiscalDevolucao
    {
        public string Tipo { get; set; }
        public DateTime Emissao { get; set; }
        public int NotaFiscal { get; set; }
        public int Serie { get; set; }
        public decimal Valor { get; set; }
        public string Chave { get; set; }
        public int CodigoCliente { get; set; }
        public string NomeCliente { get; set; }
    }
}
