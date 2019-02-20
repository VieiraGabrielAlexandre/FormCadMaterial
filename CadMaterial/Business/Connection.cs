using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace CadMaterial.Business
{
    /*
     * 
     * Essa classe retorna um dataTable com a tabela selecionada;
     * 
     * Instruções:
     * 1 -> Gerar uma nova instancia com a tabela no constructor (exemplo: Connection material = new Connection("MM_MATERIAL_SP");
     * 2 -> Declarar um dataTable na classe local
     * 3 -> Utilizar a função loadDataTable() para criar uma nova conexão utilizando a tabela selecionada
     * 4 -> Utilizar a dataTable carregada para obter as informações selecionadas
     * 
     * 
     */
    class Connection
    {
        private String tableName;
        private String connString;
        private String Sql;

        public DataTable dataTable;

        public Connection(String tableName, String inputMethod = "*", String whereClause = " ") // Parametro opcional - permitir que selecione o tipo do SELECT
        {
            this.tableName = tableName;
            this.connString = "Driver={IBM DB2 ODBC DRIVER};hostname=LOCALHOST;" +
                "port=50000;database=PW_DATA;pwd=Password1;uid=userid;";

            this.Sql = "SELECT " + inputMethod + "FROM " + tableName + whereClause + ";"; // Cria a query
        }

        public DataTable loadDataTable()
        {
            using (OdbcConnection connection = new OdbcConnection(this.connString))
            {
                using (OdbcCommand odbcCommand = new OdbcCommand(Sql, connection))
                {
                    try
                    {
                        connection.Open();

                        using (OdbcDataReader dataReader = odbcCommand.ExecuteReader())
                        {
                            dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            dataReader.Close();
                        }
                    }
                    catch (OdbcException od)
                    {
                        MessageBox.Show("Erro! connstring usada -> " + this.connString + " Mensagem de erro: " + od.Message);

                    }
                    finally
                    {
                        connection.Close();
                    }
                }

                return dataTable;
                }
        }
       
    }
}
