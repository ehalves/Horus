using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using _002___Entidade;
using _003___Negocio;

namespace _001___Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnListar_Click(object sender, EventArgs e)
        {
            string filial = TxtFilial.Text;
            DateTime data = DateTime.Parse(TxtData.Text);

            string[] dev = new NNotaFiscalDevolucao().Devolucoes(filial, data);

            LblFilial.Text = dev[0];
            LblData.Text = dev[1];
            LblQtdeNotas.Text = dev[2];
            LblValorNotas.Text = dev[3];
        }
    }
}