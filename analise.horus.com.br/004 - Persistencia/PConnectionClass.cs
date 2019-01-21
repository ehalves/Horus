using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region // Bibliotecas para conexão com Banco de Dados
/// <summary>
/// Importação das bibliotecas de conexão com bancos de dados
/// </summary>
/// Bibliotecas para conexão com Intersystems Caché
using InterSystems.Data.CacheClient;
using InterSystems.Data.CacheTypes;

/// Biblioteca para conexão com Postgre
using Npgsql;

/// Bibliotecas para conexão com MySql
using MySql.Data.MySqlClient;
using MySql.Data.Types;
#endregion

namespace _004___Persistencia
{
    public class PConnectionClass
    {
        public CacheConnection CacheProduction()
        {
            try
            {
                CacheConnection CacheConnect = new CacheConnection
                {
                    ConnectionString = "Server = 192.168.100.15; "
                  + "Port = 1972; " + "Namespace = SISTEMAS; "
                  + "Password = #gsm84kyx#; " + "User ID = sallo;"
                };

                return CacheConnect;
            }
            catch (CacheException csw)
            {
                throw csw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
