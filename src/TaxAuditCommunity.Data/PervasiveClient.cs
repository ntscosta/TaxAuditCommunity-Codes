using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Pervasive.Data.SqlClient;
using TaxAuditCommunity.Domain.Prosoft;

namespace TaxAuditCommunity.Data
{
    public class PervasiveClient
    {
        public PervasiveClient(string conn)
        {
            Connection = conn;
        }
        private readonly string Connection;

        public List<Empresas> Empresas { get; protected set; }
        public PsqlException PsqlException { get; protected set; }

        public void LoadCadastro()
        {
            PsqlConnection psqlConnection = new PsqlConnection(Connection);
            try
            {
                psqlConnection.Open();

                PsqlCommand command = new PsqlCommand();
                string sql = "select codigobtr as Codigo, razsoc as Razao, cnpjcpf as CNPJ, inscest as IE from prg_empresa_btr order by codigobtr";
                command.CommandText = sql;
                command.Connection = psqlConnection;
                PsqlDataAdapter adapter = new PsqlDataAdapter(command);
                DataSet dataSet = new DataSet("Prosoft");
                adapter.Fill(dataSet, "Empresas");
                Empresas = new List<Empresas>();
                foreach (DataRow row in dataSet.Tables["Empresas"].Rows)
                {

                    Empresas.Add(new Empresas
                    {
                        Codigo = ((string)row.ItemArray[0]).TrimEnd(),
                        Razao = ((string)row.ItemArray[1]).TrimEnd(),
                        CNPJ = ((string)row.ItemArray[2]).TrimEnd(),
                        IE = ((string)row.ItemArray[3]).TrimEnd()
                    });
                }

                psqlConnection.Close();

            }
            catch(PsqlException ex)
            {

            }
            catch(Exception ex)
            {

            }
            finally
            {
                if (psqlConnection.State == System.Data.ConnectionState.Open)
                    psqlConnection.Close();
            }

        }
    }
}
