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

// Caché Libraries
using InterSystems.Data.CacheClient;
using InterSystems.Data.CacheTypes;

// Postgree Libraries
using Npgsql;
using NpgsqlTypes;

// MySql Libraries
using MySql.Data.MySqlClient;
using MySql.Data.Types;
#endregion


namespace _004___Persistencia
{
    public class PNotaFiscalDevolucao
    {
        List<ENotaFiscalDevolucao> LstDevolucoesCsw = new List<ENotaFiscalDevolucao>();
        List<ENotaFiscalDevolucao> LstDevolucoesTtl = new List<ENotaFiscalDevolucao>();
        List<ENotaFiscalDevolucao> LstNotasDevolucoes = new List<ENotaFiscalDevolucao>();

        public List<ENotaFiscalDevolucao> ListarNotasDevolucaoCsw(string empresa, DateTime data)
        {
            CacheConnection conn = new PConnectionClass().CacheProduction();

            try
            {
                string query = @"SELECT 'D' AS TIPO,
                                        TO_CHAR(D.dataEmissao,'dd/MM/yyyy') AS EMISSAO,
                                        D.numeroNF AS NOTA,
                                        D.serieNF AS SERIE,
                                        D.vlrDevolvida AS VALOR,
                                        CAST(C.chaveNfe AS varchar(50)) AS CHAVE,
                                        Cli.codCliente AS COD_CLI,
                                        Cli.nome AS CLIENTE
                                    FROM Fat_Dev.NotaFiscalDevolucao D
                                    LEFT JOIN Est.NotaFiscalEntradaC C ON D.codEmpresa = C.codEmpresa AND D.codCliente = C.fornecedor
                                              AND D.dataEnt = C.dataEntrada AND D.serieNF = C.codSerie AND D.numeroNF = C.numDocumento
                                    LEFT JOIN Fat.Cliente Cli ON D.codCliente = Cli.codCliente AND D.codEmpresa = Cli.codEmpresa
                                    WHERE D.codEmpresa = @filial
                                    AND (D.serieNF <> 3 and D.serieNF <> 6)
                                    AND D.dataEmissao = TO_DATE('" + data + "','dd/MM/yyyy')";
                //TO_DATE('10/01/2019','dd/MM/yyyy')

                conn.Open();
                CacheCommand cmd = new CacheCommand(query, conn);
                cmd.Parameters.AddWithValue("@filial", empresa);
                //cmd.Parameters.AddWithValue("@data", data.ToShortTimeString());

                CacheDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ENotaFiscalDevolucao nfd = new ENotaFiscalDevolucao();
                        nfd.Tipo = dr["TIPO"].ToString();
                        nfd.Emissao = DateTime.Parse(dr["EMISSAO"].ToString());
                        nfd.NotaFiscal = int.Parse(dr["NOTA"].ToString());
                        nfd.Serie = int.Parse(dr["SERIE"].ToString());
                        nfd.Valor = decimal.Parse(dr["VALOR"].ToString());
                        nfd.Chave = dr["CHAVE"].ToString();
                        //nfd.Chave = dr[5].ToString();
                        nfd.CodigoCliente = int.Parse(dr["COD_CLI"].ToString());
                        nfd.NomeCliente = dr["CLIENTE"].ToString();

                        LstDevolucoesCsw.Add(nfd);
                    }
                }

                return LstDevolucoesCsw = LstDevolucoesCsw.OrderBy(x => x.NotaFiscal).ToList();
            }
            catch (CacheException csw)
            {
                throw csw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

    }
}
