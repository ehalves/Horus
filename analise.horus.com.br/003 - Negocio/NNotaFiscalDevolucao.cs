using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region // Dependências do projeto
/// <summary>
/// Dependências do projeto
/// </summary>
using _002___Entidade;
using _004___Persistencia;
#endregion

namespace _003___Negocio
{
    public class NNotaFiscalDevolucao
    {
        List<ENotaFiscalDevolucao> LstDevolucoesCsw = new List<ENotaFiscalDevolucao>();
        List<ENotaFiscalDevolucao> LstDevolucoesTtl = new List<ENotaFiscalDevolucao>();
        List<ENotaFiscalDevolucao> LstNotasDevolucoes = new List<ENotaFiscalDevolucao>();

        public List<ENotaFiscalDevolucao> ListarNotasDevolucaoCsw(string empresa, DateTime data)
        {
            try
            {
                LstDevolucoesCsw = new PNotaFiscalDevolucao().ListarNotasDevolucaoCsw(empresa, data);
                return LstDevolucoesCsw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string[] Devolucoes(string filial, DateTime data)
        {
            try
            {
                ListarNotasDevolucaoCsw(filial, data);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string[] dev = new string[4];
            if (LstDevolucoesCsw.Count > 0)
            {
                dev[0] = filial;
                dev[1] = LstDevolucoesCsw[0].Emissao.ToShortDateString();
                dev[2] = LstDevolucoesCsw.Count().ToString();
                dev[3] = LstDevolucoesCsw.Sum(x => x.Valor).ToString("C");
            }

            return dev;
        }
    }
}
